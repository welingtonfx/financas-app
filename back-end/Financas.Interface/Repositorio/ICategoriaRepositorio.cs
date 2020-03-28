using Financas.Dominio.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Financas.Interface.Repositorio
{
    public interface ICategoriaRepositorio
    {
        Task<IEnumerable<Categoria>> Obter();
        Task<Categoria> ObterPorId(int id);
        Task<Categoria> Inserir(Categoria entidade);
        Task<Categoria> Alterar(Categoria entidade);
        Task Excluir(int id);
    }
}
