using Financas.Dominio.Model;
using MediatR;

namespace Financas.Dominio.Handler.Commands
{
    public class CriarCategoriaCommand : IRequest<Categoria>
    {
        public string Descricao { get; set; }
        public int? IdCategoriaPai { get; set; }
    }
}
