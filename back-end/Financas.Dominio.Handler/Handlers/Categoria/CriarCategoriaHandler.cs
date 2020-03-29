using Financas.Dominio.Handler.Commands.Categoria;
using Financas.Infra.Interface.Repositorio;
using Financas.Interface.Repositorio;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers.Categoria
{
    public class CriarCategoriaHandler : IRequestHandler<CriarCategoriaCommand, Model.Categoria>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICategoriaRepositorio categoriaRepositorio;

        public CriarCategoriaHandler(IUnitOfWork unitOfWork,
            ICategoriaRepositorio categoriaRepositorio)
        {
            this.unitOfWork = unitOfWork;
            this.categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<Model.Categoria> Handle(CriarCategoriaCommand request, CancellationToken cancellationToken)
        {
            using (var uow = unitOfWork)
            {
                var categoria = this.CriarCategoria(request);
                var resultado = await categoriaRepositorio.Inserir(categoria);
                uow.PersistirTransacao();

                return resultado;
            }
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
