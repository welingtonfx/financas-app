using Financas.Dominio.Model;
using MediatR;

namespace Financas.Dominio.Handler.Commands
{
    public class AlterarCategoriaCommand : IRequest<Categoria>
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int? IdCategoriaPai { get; set; }
    }
}
