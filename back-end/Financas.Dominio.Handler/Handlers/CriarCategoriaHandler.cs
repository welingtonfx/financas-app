using Financas.Dominio.Handler.Commands;
using Financas.Dominio.Model;
using Financas.Interface.Repositorio;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers
{
    public class CriarCategoriaHandler : IRequestHandler<CriarCategoriaCommand, Categoria>
    {
        private readonly ICategoriaRepositorio categoriaRepositorio;

        public CriarCategoriaHandler(ICategoriaRepositorio categoriaRepositorio)
        {
            this.categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<Categoria> Handle(CriarCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = this.CriarCategoria(request);
            return await categoriaRepositorio.CriarCategoria(categoria);
        }

        private Categoria CriarCategoria(CriarCategoriaCommand request)
        {
            var categoria = new Categoria();
            categoria.Descricao = request.Descricao;
            categoria.IdCategoriaPai = request.IdCategoriaPai;
            return categoria;
        }
    }
}
