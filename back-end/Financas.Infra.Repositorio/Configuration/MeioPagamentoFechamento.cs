using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financas.Infra.Repositorio.Configuration
{
    public class MeioPagamentoFechamento : IEntityTypeConfiguration<MeioPagamentoFechamento>
    {
        public void Configure(EntityTypeBuilder<MeioPagamentoFechamento> builder)
        {
            builder.ToTable("meiopagamentofechamento");
        }
    }
}
