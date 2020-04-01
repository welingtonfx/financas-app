using MediatR;
using System;
using System.Collections.Generic;

namespace Financas.Dominio.Handler.Commands.Transacao
{
    public class CriarTransacaoCommand : IRequest<Model.Transacao>
    {
        public int? IdCategoria { get; set; }
        public int IdTransacaoTipo { get; set; }
        public int IdMeioPagamento { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataTransacao { get; set; }
        public string Observacoes { get; set; }

        public List<TransacaoDetalheCommand> Detalhes { get; set; }
    }
}
