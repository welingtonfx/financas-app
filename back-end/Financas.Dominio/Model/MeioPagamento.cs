using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financas.Dominio.Model
{
    public class MeioPagamento : BaseEntidade
    {
        public string Descricao { get; set; }
        public int IdMeioPagamentoTipo { get; set; }

        [ForeignKey("IdMeioPagamentoTipo ")]
        public MeioPagamentoTipo MeioPagamentoTipo { get; set; }

        public int? IdContaPadrao { get; set; }
        [ForeignKey("IdContaPadrao")]
        public Conta ContaPadrao { get; set; }

        public int? DiaEfetivacaoPagamento { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
