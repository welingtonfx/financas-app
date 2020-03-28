using Financas.Dominio.Handler.Commands.Categoria;
using Financas.Interface.Repositorio;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers.Categoria
{
    public class AlterarCategoriaHandler : IRequestHandler<AlterarCategoriaCommand, Model.Categoria>
    {
        private readonly ICategoriaRepositorio categoriaRepositorio;
        public AlterarCategoriaHandler(ICategoriaRepositorio categoriaRepositorio)
        {
            this.categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<Model.Categoria> Handle(AlterarCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = await categoriaRepositorio.ObterPorId(request.Id) ?? new Model.Categoria();

            MapearDadosCategoria(categoria, request);

            return await categoriaRepositorio.Alterar(categoria);
        }

        private void MapearDadosCategoria(Model.Categoria categoria, AlterarCategoriaCommand request)
        {
            categoria.Descricao = request.Descricao;
            categoria.IdCategoriaPai = request.IdCategoriaPai;
        }
    }
}
