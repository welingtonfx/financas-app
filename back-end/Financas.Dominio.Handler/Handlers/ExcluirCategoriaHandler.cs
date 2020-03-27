using Financas.Dominio.Handler.Commands;
using Financas.Interface.Repositorio;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers
{
    public class ExcluirCategoriaHandler : IRequestHandler<ExcluirCategoriaCommand>
    {
        private readonly ICategoriaRepositorio categoriaRepositorio;

        public ExcluirCategoriaHandler(ICategoriaRepositorio categoriaRepositorio)
        {
            this.categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<Unit> Handle(ExcluirCategoriaCommand request, CancellationToken cancellationToken)
        {
         
            await categoriaRepositorio.ExcluirCategoria(request.Id);
            return Unit.Value;
        }
    }
}
