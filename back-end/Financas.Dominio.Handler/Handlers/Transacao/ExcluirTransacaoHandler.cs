using Financas.Dominio.Handler.Commands.Transacao;
using Financas.Infra.Interface.Repositorio;
using Financas.Interface.Repositorio;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers.Transacao
{
    public class ExcluirTransacaoHandler : HandlerBase, IRequestHandler<ExcluirTransacaoCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ITransacaoRepositorio transacaoRepositorio;

        public ExcluirTransacaoHandler(IUnitOfWork unitOfWork,
            ITransacaoRepositorio transacaoRepositorio) : base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.transacaoRepositorio = transacaoRepositorio;
        }

        public async Task<Unit> Handle(ExcluirTransacaoCommand request, CancellationToken cancellationToken)
        {
            using (var uow = unitOfWork)
            {
                await transacaoRepositorio.Excluir(request.Id);
                uow.PersistirTransacao();
                return Unit.Value;
            }
        }
    }
}
