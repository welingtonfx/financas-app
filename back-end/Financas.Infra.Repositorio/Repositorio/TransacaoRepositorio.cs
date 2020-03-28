using Financas.Dominio.Model;
using Financas.Interface.Repositorio;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financas.Infra.Repositorio.Repositorio
{
    public class TransacaoRepositorio : ITransacaoRepositorio
    {
        public async Task<IEnumerable<Transacao>> Obter()
        {
            using (var context = new FinancasContext())
            {
                return context
                    .Transacoes
                    .ToList();
            }
        }

        public async Task<Transacao> ObterPorId(int id)
        {
            using (var context = new FinancasContext())
            {
                return context
                    .Transacoes
                    .FirstOrDefault(p => p.Id == id);
            }
        }

        public async Task<Transacao> Inserir(Transacao entidade)
        {
            using (var context = new FinancasContext())
            {
                context.Add(entidade);
                await context.SaveChangesAsync();

                return entidade;
            }
        }

        public async Task<Transacao> Alterar(Transacao entidade)
        {
            using (var context = new FinancasContext())
            {
                context.Update(entidade);
                await context.SaveChangesAsync();

                return entidade;
            }
        }

        public async Task Excluir(int id)
        {
            using (var context = new FinancasContext())
            {
                context.Remove(new Transacao() { Id = id });
                await context.SaveChangesAsync();
            }
        }
    }
}
