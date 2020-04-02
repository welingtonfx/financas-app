using Financas.Dominio.Handler.Queries.MeioPagamento;
using Financas.Interface.Repositorio;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers.MeioPagamento
{
    public class ObterMeiosPagamentoHandler : IRequestHandler<ObterMeioPagamentoQuery, List<Model.MeioPagamento>>
    {
        private readonly IMeioPagamentoRepositorio meioPagamentoRepositorio;

        public ObterMeiosPagamentoHandler(IMeioPagamentoRepositorio meioPagamentoRepositorio)
        {
            this.meioPagamentoRepositorio = meioPagamentoRepositorio;
        }

        public async Task<List<Model.MeioPagamento>> Handle(ObterMeioPagamentoQuery request, CancellationToken cancellationToken)
        {
            var resultado = await meioPagamentoRepositorio.Obter();
            return resultado.ToList();
        }
    }
}
