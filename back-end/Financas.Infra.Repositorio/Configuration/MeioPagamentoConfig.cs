using Financas.Dominio.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financas.Infra.Repositorio.Configuration
{
    public class MeioPagamentoConfig : IEntityTypeConfiguration<MeioPagamento>
    {
        public void Configure(EntityTypeBuilder<MeioPagamento> builder)
        {
            builder.ToTable("meiopagamento", "public");
        }
    }
}
