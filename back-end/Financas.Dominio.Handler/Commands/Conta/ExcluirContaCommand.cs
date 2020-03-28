using MediatR;

namespace Financas.Dominio.Handler.Commands.Conta
{
    public class ExcluirContaCommand : IRequest
    {
        public int Id { get; set; }
    }
}
