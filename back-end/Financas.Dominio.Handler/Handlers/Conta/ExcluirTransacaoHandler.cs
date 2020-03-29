using Financas.Dominio.Handler.Commands.Conta;
using Financas.Infra.Interface.Repositorio;
using Financas.Interface.Repositorio;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers.Conta
{
    public class ExcluirContaHandler : AsyncRequestHandler<ExcluirContaCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IContaRepositorio contaRepositorio;

        public ExcluirContaHandler(IUnitOfWork unitOfWork,
            IContaRepositorio contaRepositorio)
        {
            this.unitOfWork = unitOfWork;
            this.contaRepositorio = contaRepositorio;
        }

        protected override async Task Handle(ExcluirContaCommand request, CancellationToken cancellationToken)
        {
            using (var uow = unitOfWork)
            {
                await contaRepositorio.Excluir(request.Id);
                uow.PersistirTransacao();
            }
        }
    }
}
