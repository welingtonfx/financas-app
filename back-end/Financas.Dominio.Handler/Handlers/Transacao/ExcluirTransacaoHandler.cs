using Financas.Dominio.Handler.Commands.Transacao;
using Financas.Infra.Interface.Repositorio;
using Financas.Interface.Repositorio;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers.Transacao
{
    public class ExcluirTransacaoHandler : AsyncRequestHandler<ExcluirTransacaoCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ITransacaoRepositorio transacaoRepositorio;

        public ExcluirTransacaoHandler(IUnitOfWork unitOfWork,
            ITransacaoRepositorio transacaoRepositorio)
        {
            this.unitOfWork = unitOfWork;
            this.transacaoRepositorio = transacaoRepositorio;
        }

        protected override async Task Handle(ExcluirTransacaoCommand request, CancellationToken cancellationToken)
        {
            using (var uow = unitOfWork)
            {
                await transacaoRepositorio.Excluir(request.Id);
            }
        }
    }
}
