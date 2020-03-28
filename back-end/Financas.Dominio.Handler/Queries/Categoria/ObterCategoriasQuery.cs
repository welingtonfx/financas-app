using MediatR;
using System.Collections.Generic;

namespace Financas.Dominio.Handler.Handlers.Categoria
{
    public class ObterCategoriasQuery : IRequest<List<Model.Categoria>>
    {
    }
}
