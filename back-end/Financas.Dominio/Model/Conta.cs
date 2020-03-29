using Financas.Dominio.Interface;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financas.Dominio.Model
{
    public class Conta : BaseEntidade
    {
        public int IdContaTipo { get; set; }
        
        [ForeignKey("IdContaTipo")]
        public ContaTipo ContaTipo { get; set; }
        
        public string Descricao { get; set; }
    }
}
