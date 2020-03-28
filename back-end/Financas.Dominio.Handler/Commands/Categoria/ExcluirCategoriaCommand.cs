using MediatR;

namespace Financas.Dominio.Handler.Commands.Categoria
{
    public class ExcluirCategoriaCommand : IRequest
    {
        public int Id { get; set; }
    }
}
