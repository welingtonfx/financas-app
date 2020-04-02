using MediatR;

namespace Financas.Dominio.Handler.Commands.Conta
{
    public class CriarContaCommand : IRequest<Model.Conta>
    {
        public int IdContaTipo { get; set; }
        public string Descricao { get; set; }
    }
}
