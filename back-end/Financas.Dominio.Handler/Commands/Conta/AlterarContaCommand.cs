using MediatR;

namespace Financas.Dominio.Handler.Commands.Conta
{
    public class AlterarContaCommand : IRequest<Model.Conta>
    {
        public int Id { get; set; }
        public int IdContaTipo { get; set; }
        public string Descricao { get; set; }
    }
}
