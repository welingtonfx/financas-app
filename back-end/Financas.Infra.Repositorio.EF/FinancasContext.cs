using Financas.Dominio.Model;
using Financas.Infra.Repositorio.EF.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Financas.Infra.Repositorio.EF
{
    public class FinancasContext : DbContext
    {
        public FinancasContext()
        {

        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<TransacaoTipo> TrancacaoTipos { get; set; }
        public DbSet<ContaTipo> ContaTipos { get; set; }
        public DbSet<Conta> Contas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=financas;User Id=postgres;Password=wellfx200;").UseLowerCaseNamingConvention();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaConfig());
            modelBuilder.ApplyConfiguration(new TransacaoConfig());
            modelBuilder.ApplyConfiguration(new ContaConfig());
        }
    }
}
