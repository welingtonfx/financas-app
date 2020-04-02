using MediatR;
using System.Collections.Generic;

namespace Financas.Dominio.Handler.Queries.MeioPagamento
{
    public class ObterMeioPagamentoQuery : IRequest<List<Model.MeioPagamento>>
    {
    }
}
