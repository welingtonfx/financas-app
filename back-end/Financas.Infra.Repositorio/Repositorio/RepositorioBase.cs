using Financas.Dominio.Model;
using Financas.Infra.Interface.Repositorio;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financas.Infra.Repositorio.Repositorio
{
    public class RepositorioBase<T> : IRepositorio<T>
        where T: BaseEntidade, new()
    {
        protected readonly FinancasContext contexto;
        private DbSet<T> entidades;

        public RepositorioBase()
        {
            this.contexto = new FinancasContext(); ;
            entidades = contexto.Set<T>();
        }

        public async Task<IEnumerable<T>> Obter()
        {
            return entidades.AsEnumerable();
        }

        public async Task<T> ObterPorId(int id)
        {
            return entidades.SingleOrDefault(s => s.Id == id);
        }

        public async Task<T> Inserir (T entidade)
        {
            entidades.Add(entidade);
            contexto.SaveChanges();
            return entidade;
        }

        public async Task<T> Alterar(T entidade)
        {
            entidades.Update(entidade);
            contexto.SaveChanges();
            return entidade;
        }

        public async Task Excluir(int id)
        {
            contexto.Remove(new T() { Id = id });
            contexto.SaveChanges();
        }
    }
}
