using Financas.Dominio.Handler.Queries.Transacao;
using Financas.Interface.Repositorio;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers.Transacao
{
    public class ObterTransacoesHandler : IRequestHandler<ObterTransacoesQuery, List<Model.Transacao>>
    {
        private readonly ITransacaoRepositorio transacaoRepositorio;

        public ObterTransacoesHandler(ITransacaoRepositorio transacaoRepositorio)
        {
            this.transacaoRepositorio = transacaoRepositorio;
        }

        public async Task<List<Model.Transacao>> Handle(ObterTransacoesQuery request, CancellationToken cancellationToken)
        {
            var resultado = await transacaoRepositorio.ObterTransacoes();
            return resultado.ToList();
        }
    }
}
