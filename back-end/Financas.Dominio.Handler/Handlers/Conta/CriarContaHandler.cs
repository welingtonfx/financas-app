using Financas.Dominio.Handler.Commands.Conta;
using Financas.Infra.Interface.Repositorio;
using Financas.Interface.Repositorio;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers.Conta
{
    public class CriarContaHandler : IRequestHandler<CriarContaCommand, Model.Conta>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IContaRepositorio contaRepositorio;

        public CriarContaHandler(IUnitOfWork unitOfWork,
            IContaRepositorio contaRepositorio)
        {
            this.unitOfWork = unitOfWork;
            this.contaRepositorio = contaRepositorio;
        }

        public async Task<Model.Conta> Handle(CriarContaCommand request, CancellationToken cancellationToken)
        {
            using (var uow = unitOfWork)
            {
                var conta = this.CriarConta(request);
                var resultado = await contaRepositorio.Inserir(conta);
                uow.PersistirTransacao();

                return resultado;
            }
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
