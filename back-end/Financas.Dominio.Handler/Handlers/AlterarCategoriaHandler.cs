using Financas.Dominio.Handler.Commands;
using Financas.Dominio.Model;
using Financas.Interface.Repositorio;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers
{
    public class AlterarCategoriaHandler : IRequestHandler<AlterarCategoriaCommand, Categoria>
    {
        private readonly ICategoriaRepositorio categoriaRepositorio;
        public AlterarCategoriaHandler(ICategoriaRepositorio categoriaRepositorio)
        {
            this.categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<Categoria> Handle(AlterarCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = this.CriarCategoria(request);
            return await categoriaRepositorio.AlterarCategoria(categoria);
        }

        private Categoria CriarCategoria(AlterarCategoriaCommand request)
        {
            var categoria = new Categoria();
            categoria.Id = request.Id;
            categoria.Descricao = request.Descricao;
            categoria.IdCategoriaPai = request.IdCategoriaPai;
            return categoria;
        }
    }
}
