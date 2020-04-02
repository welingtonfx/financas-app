using Financas.Dominio.Model;
using Financas.Infra.Interface.Repositorio;
using Financas.Interface.Repositorio;

namespace Financas.Infra.EF.Repositorio.Repositorio
{
    public class CategoriaRepositorio : RepositorioBase<Categoria>, ICategoriaRepositorio
    {
        public CategoriaRepositorio(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
