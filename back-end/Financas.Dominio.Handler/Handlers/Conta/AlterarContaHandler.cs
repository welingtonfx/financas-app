using Financas.Dominio.Handler.Commands.Conta;
using Financas.Interface.Repositorio;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers.Conta
{
    public class AlterarContaHandler : IRequestHandler<AlterarContaCommand, Model.Conta>
    {
        private readonly IContaRepositorio contaRepositorio;

        public AlterarContaHandler(IContaRepositorio contaRepositorio)
        {
            this.contaRepositorio = contaRepositorio;
        }

        public async Task<Model.Conta> Handle(AlterarContaCommand request, CancellationToken cancellationToken)
        {
            var conta = await contaRepositorio.ObterPorId(request.Id) ?? new Model.Conta();

            MapearDadosConta(conta, request);

            return await contaRepositorio.Alterar(conta);
        }

        private void MapearDadosConta(Model.Conta conta, AlterarContaCommand request)
        {
            conta.IdContaTipo = request.IdContaTipo;
            conta.Descricao = request.Descricao;
        }
    }
}
