using AutoMapper;
using Financas.Dominio.Handler.Commands.Categoria;
using Financas.Infra.Interface.Repositorio;
using Financas.Interface.Repositorio;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers.Categoria
{
    public class CriarCategoriaHandler : HandlerBase, IRequestHandler<CriarCategoriaCommand, Model.Categoria>
    {
        private readonly IMapper mapper;
        private readonly ICategoriaRepositorio categoriaRepositorio;

        public CriarCategoriaHandler(IUnitOfWork unitOfWork,
            IMapper mapper,
            ICategoriaRepositorio categoriaRepositorio) : base(unitOfWork)
        {
            this.mapper = mapper;
            this.categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<Model.Categoria> Handle(CriarCategoriaCommand request, CancellationToken cancellationToken)
        {
            using (var uow = unitOfWork)
            {
                var resultado = await categoriaRepositorio.Inserir(mapper.Map<Model.Categoria>(request));
                uow.PersistirTransacao();

                return resultado;
            }
        }
    }
}
