using Financas.Dominio.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Financas.Interface.Repositorio
{
    public interface ICategoriaRepositorio
    {
        Task<IEnumerable<Categoria>> ObterCategorias();
    }
}
