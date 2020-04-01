using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financas.Dominio.Model
{
    public class TransacaoDetalhe : BaseEntidade
    {
        public int IdTransacao { get; set; }
        
        [ForeignKey("IdTransacao")]
        public Transacao Transacao { get; set; }

        public int IdMeioPagamento { get; set; }
        [ForeignKey("IdMeioPagamento")]
        public MeioPagamento MeioPagamento { get; set; }

        public int IdConta { get; set; }
        [ForeignKey("IdConta")]
        public Conta Conta { get; set; }

        public DateTime DataEfetivacao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
