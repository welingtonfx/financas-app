using Financas.Dominio.Interface;
using System.Collections.Generic;

namespace Financas.Dominio.Model
{
    public class Categoria : BaseEntidade
    {
        public string Descricao { get; set; }
        public int? IdCategoriaPai { get; set; }

        public List<Transacao> Transacoes { get; set; }
    }
}
