using MediatR;

namespace Financas.Dominio.Handler.Commands.Categoria
{
    public class AlterarCategoriaCommand : IRequest<Model.Categoria>
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int? IdCategoriaPai { get; set; }
    }
}
