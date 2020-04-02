using Financas.Dominio.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financas.Infra.Repositorio.EF.Configuration
{
    public class TransacaoDetalheConfig : IEntityTypeConfiguration<TransacaoDetalhe>
    {
        public void Configure(EntityTypeBuilder<TransacaoDetalhe> builder)
        {
            builder.ToTable("transacaoconfig", "public");
        }
    }
}
