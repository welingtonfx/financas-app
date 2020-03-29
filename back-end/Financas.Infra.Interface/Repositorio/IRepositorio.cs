using Financas.Dominio.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Financas.Infra.Interface.Repositorio
{
    public interface IRepositorio<T>
        where T : IIdentificador
    {
        Task<IEnumerable<T>> Obter();
        Task<T> ObterPorId(int id);
        Task<T> Inserir(T entidade);
        Task<T> Alterar(T entidade);
        Task Excluir(int id);
    }
}
