using System;

namespace Financas.Dominio.Handler.Commands.Transacao
{
    public class TransacaoDetalheCommand
    {
        public int? Id { get; set; }
        public int? IdTransacao { get; set; }
        public int IdMeioPagamento { get; set; }
        public int IdConta { get; set; }
        public DateTime DataEfetivacao { get; set; }
        public decimal Valor { get; set; }
    }
}
