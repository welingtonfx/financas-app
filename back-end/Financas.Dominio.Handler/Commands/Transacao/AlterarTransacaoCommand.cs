using MediatR;
using System;

namespace Financas.Dominio.Handler.Commands.Transacao
{
    public class AlterarTransacaoCommand : IRequest<Model.Transacao>
    {
        public int Id { get; set; }
        public int? IdCategoria { get; set; }
        public int IdTransacaoTipo { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataTransacao { get; set; }
        public string Observacoes { get; set; }
    }
}
