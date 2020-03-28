using Financas.Dominio.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Financas.Interface.Repositorio
{
    public interface ICategoriaRepositorio
    {
        Task<IEnumerable<Categoria>> ObterCategorias();
        Task<Categoria> ObterCategoriaPorId(int id);
        Task<Categoria> CriarCategoria(Categoria categoria);
        Task<Categoria> AlterarCategoria(Categoria categoria);
        Task ExcluirCategoria(int id);
    }
}
