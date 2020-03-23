using System.Collections.Generic;

namespace Financas.Dominio.Model
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int? IdCategoriaPai { get; set; }

        public List<Transacao> Transacoes { get; set; }
    }
}
