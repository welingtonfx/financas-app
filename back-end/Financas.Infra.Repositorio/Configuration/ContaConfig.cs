using Financas.Dominio.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financas.Infra.Repositorio.Configuration
{
    public class ContaConfig : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.ToTable("conta", "public");
        }
    }
}
