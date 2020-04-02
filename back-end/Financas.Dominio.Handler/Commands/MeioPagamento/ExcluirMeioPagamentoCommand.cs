using MediatR;

namespace Financas.Dominio.Handler.Commands.MeioPagamento
{
    public class ExcluirMeioPagamentoCommand : IRequest
    {
        public int Id { get; set; }
    }
}
