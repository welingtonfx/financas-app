using Financas.Dominio.Model;
using MediatR;
using System.Collections.Generic;

namespace Financas.Dominio.Handler.Handlers
{
    public class ObterCategoriasQuery : IRequest<List<Categoria>>
    {
    }
}
