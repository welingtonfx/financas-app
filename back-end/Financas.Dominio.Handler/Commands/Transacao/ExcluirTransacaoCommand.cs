using MediatR;

namespace Financas.Dominio.Handler.Commands.Transacao
{
    public class ExcluirTransacaoCommand : IRequest
    {
        public int Id { get; set; }
    }
}
