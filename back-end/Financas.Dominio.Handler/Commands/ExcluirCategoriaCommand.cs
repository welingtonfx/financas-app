using MediatR;

namespace Financas.Dominio.Handler.Commands
{
    public class ExcluirCategoriaCommand : IRequest
    {
        public int Id { get; set; }
    }
}
