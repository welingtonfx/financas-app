using Financas.Dominio.Model;
using Financas.Interface.Repositorio;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financas.Infra.Repositorio.Repositorio
{
    public class TransacaoRepositorio : ITransacaoRepositorio
    {
        public async Task<IEnumerable<Transacao>> ObterTransacoes()
        {
            using (var context = new FinancasContext())
            {
                return context
                    .Transacoes
                    .ToList();
            }
        }

        public async Task<Transacao> ObterTransacaoPorId(int id)
        {
            using (var context = new FinancasContext())
            {
                return context
                    .Transacoes
                    .FirstOrDefault(p => p.Id == id);
            }
        }

        public async Task<Transacao> CriarTransacao(Transacao transacao)
        {
            using (var context = new FinancasContext())
            {
                context.Add(transacao);
                await context.SaveChangesAsync();

                return transacao;
            }
        }

        public async Task<Transacao> AlterarTransacao(Transacao transacao)
        {
            using (var context = new FinancasContext())
            {
                context.Update(transacao);
                await context.SaveChangesAsync();

                return transacao;
            }
        }

        public async Task ExcluirTransacao(int id)
        {
            using (var context = new FinancasContext())
            {
                context.Remove(new Transacao() { Id = id });
                await context.SaveChangesAsync();
            }
        }
    }
}
