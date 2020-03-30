using AutoMapper;
using Financas.Dominio.Handler.PipelineBehaviors;
using Financas.Infra.Interface.Repositorio;
using Financas.Infra.Repositorio;
using Financas.Infra.Repositorio.Repositorio;
using Financas.Interface.Repositorio;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace Financas.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc().AddNewtonsoftJson();

            ConfigureServicesCors(services);
            ConfigureServicesSwagger(services);
            ConfigureServicesAutoMapper(services);

            // Injeções
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddTransient<ICategoriaRepositorio, CategoriaRepositorio>();
            services.AddTransient<ITransacaoRepositorio, TransacaoRepositorio>();
            services.AddTransient<IContaRepositorio, ContaRepositorio>();
            services.AddScoped(typeof(IRepositorio<>), typeof(RepositorioBase<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(FinancasContext));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddMediatR(AppDomain.CurrentDomain.Load("Financas.Dominio.Handler"));
            services.AddValidatorsFromAssembly(AppDomain.CurrentDomain.Load("Financas.Dominio.Handler"));
        }

        private void ConfigureServicesCors(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
        }

        private void ConfigureServicesSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "Finanças",
                        Version = "v1",
                        Description = "APIs - Finanças",
                        Contact = new OpenApiContact
                        {
                            Name = "Welington",
                            Url = new Uri("https://github.com/welingtonfx")
                        }
                    });
            });

            services.AddSwaggerGenNewtonsoftSupport();
        }

        private void ConfigureServicesAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.Load("Financas.Dominio.Handler"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("AllowAllOrigins");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "apis");
            });
        }
    }
}
