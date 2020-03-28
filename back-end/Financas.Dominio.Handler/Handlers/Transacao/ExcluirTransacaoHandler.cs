using Financas.Dominio.Handler.Commands.Transacao;
using Financas.Interface.Repositorio;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers.Transacao
{
    public class ExcluirTransacaoHandler : AsyncRequestHandler<ExcluirTransacaoCommand>
    {
        private readonly ITransacaoRepositorio transacaoRepositorio;

        public ExcluirTransacaoHandler(ITransacaoRepositorio transacaoRepositorio)
        {
            this.transacaoRepositorio = transacaoRepositorio;
        }

        protected override async Task Handle(ExcluirTransacaoCommand request, CancellationToken cancellationToken)
        {
            await transacaoRepositorio.ExcluirTransacao(request.Id);
        }
    }
}
