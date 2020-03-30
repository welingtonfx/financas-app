using Financas.Dominio.Handler.Commands.Categoria;
using Financas.Infra.Interface.Repositorio;
using Financas.Interface.Repositorio;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers.Categoria
{
    public class ExcluirCategoriaHandler : HandlerBase, IRequestHandler<ExcluirCategoriaCommand>
    {
        private readonly ICategoriaRepositorio categoriaRepositorio;

        public ExcluirCategoriaHandler(IUnitOfWork unitOfWork,
            ICategoriaRepositorio categoriaRepositorio) : base(unitOfWork)
        {
            this.categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<Unit> Handle(ExcluirCategoriaCommand request, CancellationToken cancellationToken)
        {
            using (var uow = unitOfWork)
            {
                await categoriaRepositorio.Excluir(request.Id);
                uow.PersistirTransacao();
                return Unit.Value;
            }
        }
    }
}
