using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financas.Dominio.Model
{
    public class Transacao : BaseEntidade
    {
        public int? IdCategoria { get; set; }

        [ForeignKey("IdCategoria")]
        public Categoria Categoria { get; set; }

        public int IdTransacaoTipo { get; set; }

        [ForeignKey("IdTransacaoTipo")]
        public TransacaoTipo TransacaoTipo { get; set; }

        public int IdMeioPagamento { get; set; }

        [ForeignKey("IdMeioPagamento")]
        public MeioPagamento MeioPagamento { get; set; }

        public decimal ValorTotal { get; set; }
        public DateTime DataTransacao { get; set; }
        public string Observacoes { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }

        public List<TransacaoDetalhe> Detalhes { get; set; }
    }
}
