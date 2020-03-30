using Financas.Dominio.Handler.Commands.Conta;
using Financas.Infra.Interface.Repositorio;
using Financas.Interface.Repositorio;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers.Conta
{
    public class ExcluirContaHandler : HandlerBase, IRequestHandler<ExcluirContaCommand>
    {
        private readonly IContaRepositorio contaRepositorio;

        public ExcluirContaHandler(IUnitOfWork unitOfWork,
            IContaRepositorio contaRepositorio) : base(unitOfWork)
        {
            this.contaRepositorio = contaRepositorio;
        }

        public async Task<Unit> Handle(ExcluirContaCommand request, CancellationToken cancellationToken)
        {
            using (var uow = unitOfWork)
            {
                await contaRepositorio.Excluir(request.Id);
                uow.PersistirTransacao();
                return Unit.Value;
            }
        }
    }
}
