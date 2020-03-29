using Financas.Dominio.Handler.Commands.Transacao;
using Financas.Infra.Interface.Repositorio;
using Financas.Interface.Repositorio;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers.Transacao
{
    public class AlterarTransacaoHandler : IRequestHandler<AlterarTransacaoCommand, Model.Transacao>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ITransacaoRepositorio transacaoRepositorio;

        public AlterarTransacaoHandler(IUnitOfWork unitOfWork,
            ITransacaoRepositorio transacaoRepositorio)
        {
            this.unitOfWork = unitOfWork;
            this.transacaoRepositorio = transacaoRepositorio;
        }

        public async Task<Model.Transacao> Handle(AlterarTransacaoCommand request, CancellationToken cancellationToken)
        {
            using (var uow = unitOfWork)
            {
                var transacao = await transacaoRepositorio.ObterPorId(request.Id) ?? new Model.Transacao();

                MapearDadosTransacao(transacao, request);

                var resultado = await transacaoRepositorio.Alterar(transacao);
                uow.PersistirTransacao();

                return resultado;
            }
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
