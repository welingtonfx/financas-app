using Financas.Dominio.Model;
using Financas.Interface.Repositorio;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financas.Infra.Repositorio.Repositorio
{
    public class ContaRepositorio : IContaRepositorio
    {
        public async Task<IEnumerable<Conta>> Obter()
        {
            using (var context = new FinancasContext())
            {
                return context
                    .Contas
                    .ToList();
            }
        }

        public async Task<Conta> ObterPorId(int id)
        {
            using (var context = new FinancasContext())
            {
                return context
                    .Contas
                    .FirstOrDefault(p => p.Id == id);
            }
        }

        public async Task<Conta> Inserir(Conta entidade)
        {
            using (var context = new FinancasContext())
            {
                context.Add(entidade);
                await context.SaveChangesAsync();

                return entidade;
            }
        }

        public async Task<Conta> Alterar(Conta entidade)
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
                context.Remove(new Conta() { Id = id });
                await context.SaveChangesAsync();
            }
        }
    }
}
