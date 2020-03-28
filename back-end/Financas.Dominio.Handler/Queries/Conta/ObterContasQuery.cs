using MediatR;
using System.Collections.Generic;

namespace Financas.Dominio.Handler.Queries.Conta
{
    public class ObterContasQuery : IRequest<List<Model.Conta>>
    {
    }
}
