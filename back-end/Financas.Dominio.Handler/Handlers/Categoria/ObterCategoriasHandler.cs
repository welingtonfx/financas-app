using Financas.Interface.Repositorio;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers.Categoria
{
    public class ObterCategoriasHandler : IRequestHandler<ObterCategoriasQuery, List<Model.Categoria>>
    {
        private readonly ICategoriaRepositorio categoriaRepositorio;

        public ObterCategoriasHandler(ICategoriaRepositorio categoriaRepositorio)
        {
            this.categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<List<Model.Categoria>> Handle(ObterCategoriasQuery request, CancellationToken cancellationToken)
        {
            var resultado = await categoriaRepositorio.ObterCategorias();
            return resultado.ToList();
        }
    }
}
