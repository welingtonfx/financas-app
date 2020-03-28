using Financas.Dominio.Handler.Commands.Conta;
using Financas.Interface.Repositorio;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers.Conta
{
    public class CriarContaHandler : IRequestHandler<CriarContaCommand, Model.Conta>
    {
        private readonly IContaRepositorio contaRepositorio;

        public CriarContaHandler(IContaRepositorio contaRepositorio)
        {
            this.contaRepositorio = contaRepositorio;
        }

        public async Task<Model.Conta> Handle(CriarContaCommand request, CancellationToken cancellationToken)
        {
            var conta = this.CriarConta(request);
            return await contaRepositorio.Inserir(conta);
        }

        private Model.Conta CriarConta(CriarContaCommand request)
        {
            var conta = new Model.Conta();
            conta.Descricao = request.Descricao;
            conta.IdContaTipo = request.IdContaTipo;
            return conta;
        }
    }
}
