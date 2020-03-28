using Financas.Dominio.Handler.Commands.Conta;
using Financas.Interface.Repositorio;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers.Conta
{
    public class ExcluirContaHandler : AsyncRequestHandler<ExcluirContaCommand>
    {
        private readonly IContaRepositorio contaRepositorio;

        public ExcluirContaHandler(IContaRepositorio contaRepositorio)
        {
            this.contaRepositorio = contaRepositorio;
        }

        protected override async Task Handle(ExcluirContaCommand request, CancellationToken cancellationToken)
        {
            await contaRepositorio.Excluir(request.Id);
        }
    }
}
