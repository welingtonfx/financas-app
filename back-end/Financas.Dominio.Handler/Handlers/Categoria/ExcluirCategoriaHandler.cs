using Financas.Dominio.Handler.Commands.Categoria;
using Financas.Infra.Interface.Repositorio;
using Financas.Interface.Repositorio;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers.Categoria
{
    public class ExcluirCategoriaHandler : AsyncRequestHandler<ExcluirCategoriaCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICategoriaRepositorio categoriaRepositorio;

        public ExcluirCategoriaHandler(IUnitOfWork unitOfWork,
            ICategoriaRepositorio categoriaRepositorio)
        {
            this.unitOfWork = unitOfWork;
            this.categoriaRepositorio = categoriaRepositorio;
        }

        protected override async Task Handle(ExcluirCategoriaCommand request, CancellationToken cancellationToken)
        {
            using (var uow = unitOfWork)
            {
                await categoriaRepositorio.Excluir(request.Id);
                uow.PersistirTransacao();
            }
        }
    }
}
