using Financas.Dominio.Handler.Commands.Transacao;
using Financas.Interface.Repositorio;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers.Transacao
{
    public class CriarTransacaoHandler : IRequestHandler<CriarTransacaoCommand, Model.Transacao>
    {
        private readonly ITransacaoRepositorio transacaoRepositorio;

        public CriarTransacaoHandler(ITransacaoRepositorio transacaoRepositorio)
        {
            this.transacaoRepositorio = transacaoRepositorio;
        }

        public async Task<Model.Transacao> Handle(CriarTransacaoCommand request, CancellationToken cancellationToken)
        {
            var transacao = this.CriarTransacao(request);
            return await transacaoRepositorio.CriarTransacao(transacao);
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
