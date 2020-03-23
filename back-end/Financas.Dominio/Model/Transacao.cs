using System;

namespace Financas.Dominio.Model
{
    public class Transacao
    {
        public int Id { get; set; }
        
        public int? IdCategoria { get; set; }
        public Categoria Categoria { get; set; }

        public int IdTransacaoTipo { get; set; }
        public TransacaoTipo TransacaoTipo { get; set; }

        public DateTime DataTransacao { get; set; }
        public string Observacoes { get; set; }
    }
}
