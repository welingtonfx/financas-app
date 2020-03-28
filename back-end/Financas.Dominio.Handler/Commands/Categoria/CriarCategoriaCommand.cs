using MediatR;

namespace Financas.Dominio.Handler.Commands.Categoria
{
    public class CriarCategoriaCommand : IRequest<Model.Categoria>
    {
        public string Descricao { get; set; }
        public int? IdCategoriaPai { get; set; }
    }
}
