using MediatR;

namespace Financas.Dominio.Handler.Commands.MeioPagamento
{
    public class CriarMeioPagamentoCommand : IRequest<Model.MeioPagamento>
    {
        public string Descricao { get; set; }
        public int IdMeioPagamentoTipo { get; set; }
        public int? DiaEfetivacaoPagamento { get; set; }
        public int? IdContaPadrao { get; set; }
    }
}
