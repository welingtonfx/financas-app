using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.Dominio.Model
{
    public class MeioPagamentoTipo : BaseEntidade
    {
        public string Descricao { get; set; }
        public bool EfetivacaoPagamentoImediata { get; set; }
        public bool EfetivacaoPagamentoProgramada { get; set; }
    }
}
