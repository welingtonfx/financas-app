using Financas.Dominio.Handler.Commands.Categoria;
using Financas.Interface.Repositorio;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers.Categoria
{
    public class CriarCategoriaHandler : IRequestHandler<CriarCategoriaCommand, Model.Categoria>
    {
        private readonly ICategoriaRepositorio categoriaRepositorio;

        public CriarCategoriaHandler(ICategoriaRepositorio categoriaRepositorio)
        {
            this.categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<Model.Categoria> Handle(CriarCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = this.CriarCategoria(request);
            return await categoriaRepositorio.CriarCategoria(categoria);
        }

        private Model.Categoria CriarCategoria(CriarCategoriaCommand request)
        {
            var categoria = new Model.Categoria();
            categoria.Descricao = request.Descricao;
            categoria.IdCategoriaPai = request.IdCategoriaPai;
            return categoria;
        }
    }
}
