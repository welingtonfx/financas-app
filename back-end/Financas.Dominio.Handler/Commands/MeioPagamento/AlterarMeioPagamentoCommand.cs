using MediatR;

namespace Financas.Dominio.Handler.Commands.MeioPagamento
{
    public class AlterarMeioPagamentoCommand : IRequest<Model.MeioPagamento>
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int IdMeioPagamentoTipo { get; set; }
        public int? DiaEfetivacaoPagamento { get; set; }
        public int? IdContaPadrao { get; set; }
    }
}
