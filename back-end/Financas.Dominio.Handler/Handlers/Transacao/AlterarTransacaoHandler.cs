using Financas.Dominio.Handler.Commands.Transacao;
using Financas.Interface.Repositorio;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers.Transacao
{
    public class AlterarTransacaoHandler : IRequestHandler<AlterarTransacaoCommand, Model.Transacao>
    {
        private readonly ITransacaoRepositorio transacaoRepositorio;

        public AlterarTransacaoHandler(ITransacaoRepositorio transacaoRepositorio)
        {
            this.transacaoRepositorio = transacaoRepositorio;
        }

        public async Task<Model.Transacao> Handle(AlterarTransacaoCommand request, CancellationToken cancellationToken)
        {
            var transacao = await transacaoRepositorio.ObterTransacaoPorId(request.Id) ?? new Model.Transacao();

            MapearDadosTransacao(transacao, request);

            return await transacaoRepositorio.AlterarTransacao(transacao);
        }

        private void MapearDadosTransacao(Model.Transacao transacao, AlterarTransacaoCommand request)
        {
            transacao.IdCategoria = request.IdCategoria;
            transacao.IdTransacaoTipo = request.IdTransacaoTipo;
            transacao.Valor = request.Valor;
            transacao.DataTransacao = request.DataTransacao;
            transacao.Observacoes = request.Observacoes;
        }
    }
}
