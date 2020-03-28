using System.ComponentModel.DataAnnotations.Schema;

namespace Financas.Dominio.Model
{
    public class Conta
    {
        public int Id { get; set; }

        public int IdContaTipo { get; set; }
        
        [ForeignKey("IdContaTipo")]
        public ContaTipo ContaTipo { get; set; }
        
        public string Descricao { get; set; }
    }
}
