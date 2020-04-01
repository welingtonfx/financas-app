using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financas.Dominio.Model
{
    public class MeioPagamentoFechamento : BaseEntidade
    {
        public int IdMeioPagamento { get; set; }
        
        [ForeignKey("IdMeioPagamento")]
        public MeioPagamento MeioPagamento { get; set; }

        public int MesReferencia { get; set; }
        public int AnoReferencia { get; set; }
        public DateTime DataFechamento { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
