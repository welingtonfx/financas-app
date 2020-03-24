using Financas.Dominio.Model;
using Financas.Interface.Repositorio;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Financas.Dominio.Handler.Handlers
{
    public class ObterCategoriasHandler : IRequestHandler<ObterCategoriasQuery, List<Categoria>>
    {
        private readonly ICategoriaRepositorio categoriaRepositorio;

        public ObterCategoriasHandler(ICategoriaRepositorio categoriaRepositorio)
        {
            this.categoriaRepositorio = categoriaRepositorio;
    }

        public async Task<List<Categoria>> Handle(ObterCategoriasQuery request, CancellationToken cancellationToken)
        {
            var resultado = await categoriaRepositorio.ObterCategorias();
            return resultado.ToList();
        }
    }
}
