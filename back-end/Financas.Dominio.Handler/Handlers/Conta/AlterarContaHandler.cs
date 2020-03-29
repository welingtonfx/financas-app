using Financas.Dominio.Handler.Commands.Conta;
using Financas.Infra.Interface.Repositorio;
using Financas.Interface.Repositorio;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers.Conta
{
    public class AlterarContaHandler : IRequestHandler<AlterarContaCommand, Model.Conta>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IContaRepositorio contaRepositorio;

        public AlterarContaHandler(IUnitOfWork unitOfWork,
            IContaRepositorio contaRepositorio)
        {
            this.unitOfWork = unitOfWork;
            this.contaRepositorio = contaRepositorio;
        }

        public async Task<Model.Conta> Handle(AlterarContaCommand request, CancellationToken cancellationToken)
        {
            using (var uow = unitOfWork)
            {
                var conta = await contaRepositorio.ObterPorId(request.Id) ?? new Model.Conta();

                MapearDadosConta(conta, request);

                var resultado = await contaRepositorio.Alterar(conta);
                uow.PersistirTransacao();

                return resultado;
            }
        }

        private void MapearDadosConta(Model.Conta conta, AlterarContaCommand request)
        {
            conta.IdContaTipo = request.IdContaTipo;
            conta.Descricao = request.Descricao;
        }
    }
}
