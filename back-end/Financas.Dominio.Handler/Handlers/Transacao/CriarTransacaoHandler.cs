using Financas.Dominio.Handler.Commands.Transacao;
using Financas.Infra.Interface.Repositorio;
using Financas.Interface.Repositorio;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers.Transacao
{
    public class CriarTransacaoHandler : IRequestHandler<CriarTransacaoCommand, Model.Transacao>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ITransacaoRepositorio transacaoRepositorio;

        public CriarTransacaoHandler(IUnitOfWork unitOfWork,
            ITransacaoRepositorio transacaoRepositorio)
        {
            this.unitOfWork = unitOfWork;
            this.transacaoRepositorio = transacaoRepositorio;
        }

        public async Task<Model.Transacao> Handle(CriarTransacaoCommand request, CancellationToken cancellationToken)
        {
            using (var uow = unitOfWork)
            {
                var transacao = this.CriarTransacao(request);
                var resultado = await transacaoRepositorio.Inserir(transacao);
                uow.PersistirTransacao();

                return resultado;
            }
        }

        private Model.Transacao CriarTransacao(CriarTransacaoCommand request)
        {
            var transacao = new Model.Transacao();
            transacao.IdCategoria = request.IdCategoria;
            transacao.IdTransacaoTipo = request.IdTransacaoTipo;
            transacao.Valor = request.Valor;
            transacao.DataTransacao = request.DataTransacao;
            transacao.Observacoes = request.Observacoes;
            return transacao;
        }
    }
}
