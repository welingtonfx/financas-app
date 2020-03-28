using Financas.Dominio.Handler.Queries.Conta;
using Financas.Interface.Repositorio;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers.Conta
{
    public class ObterContasHandler : IRequestHandler<ObterContasQuery, List<Model.Conta>>
    {
        private readonly IContaRepositorio contaRepositorio;

        public ObterContasHandler(IContaRepositorio contaRepositorio)
        {
            this.contaRepositorio = contaRepositorio;
        }

        public async Task<List<Model.Conta>> Handle(ObterContasQuery request, CancellationToken cancellationToken)
        {
            var resultado = await contaRepositorio.Obter();
            return resultado.ToList();
        }
    }
}
