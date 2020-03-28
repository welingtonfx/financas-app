using Financas.Dominio.Handler.Commands.Categoria;
using Financas.Interface.Repositorio;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers.Categoria
{
    public class ExcluirCategoriaHandler : AsyncRequestHandler<ExcluirCategoriaCommand>
    {
        private readonly ICategoriaRepositorio categoriaRepositorio;

        public ExcluirCategoriaHandler(ICategoriaRepositorio categoriaRepositorio)
        {
            this.categoriaRepositorio = categoriaRepositorio;
        }

        protected override async Task Handle(ExcluirCategoriaCommand request, CancellationToken cancellationToken)
        {
            await categoriaRepositorio.ExcluirCategoria(request.Id);
        }
    }
}
