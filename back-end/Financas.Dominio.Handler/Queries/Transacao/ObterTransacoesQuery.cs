using MediatR;
using System.Collections.Generic;

namespace Financas.Dominio.Handler.Queries.Transacao
{
    public class ObterTransacoesQuery : IRequest<List<Model.Transacao>>
    {
    }
}
