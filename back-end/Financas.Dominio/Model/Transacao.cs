using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financas.Dominio.Model
{
    public class Transacao
    {
        public int Id { get; set; }
        
        public int? IdCategoria { get; set; }
        [ForeignKey("IdCategoria")]
        public Categoria Categoria { get; set; }

        public int IdTransacaoTipo { get; set; }
        [ForeignKey("IdTransacaoTipo")]
        public TransacaoTipo TransacaoTipo { get; set; }

        public decimal Valor { get; set; }
        public DateTime DataTransacao { get; set; }
        public string Observacoes { get; set; }
    }
}
