using Financas.Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Financas.Infra.Interface.Repositorio
{
    public interface IRepositorio<T>
        where T : IIdentificador
    {
        Task<IEnumerable<T>> Obter();
        Task<IEnumerable<T>> Obter(Expression<Func<T, bool>> filtro = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] propriedadesInclude);
        Task<T> ObterPorId(int id);
        Task Inserir(IEnumerable<T> entidades);
        Task<T> Inserir(T entidade);
        Task Alterar(IEnumerable<T> entidades);
        Task<T> Alterar(T entidade);
        Task Excluir(IEnumerable<int> ids);
        Task Excluir(int id);
    }
}
