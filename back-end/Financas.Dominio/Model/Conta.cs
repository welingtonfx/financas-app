using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financas.Dominio.Model
{
    public class Conta : BaseEntidade
    {
        public int IdContaTipo { get; set; }
        
        [ForeignKey("IdContaTipo")]
        public ContaTipo ContaTipo { get; set; }
        
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }

        public void PreencherDataCriacao()
        {
            this.DataCriacao = DateTime.Now;
        }

        public void PreencherDataAlteracao()
        {
            this.DataAlteracao = DateTime.Now;
        }
    }
}
