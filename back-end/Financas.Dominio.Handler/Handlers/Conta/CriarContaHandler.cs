using AutoMapper;
using Financas.Dominio.Handler.Commands.Conta;
using Financas.Infra.Interface.Repositorio;
using Financas.Interface.Repositorio;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers.Conta
{
    public class CriarContaHandler : IRequestHandler<CriarContaCommand, Model.Conta>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IContaRepositorio contaRepositorio;

        public CriarContaHandler(IUnitOfWork unitOfWork,
            IMapper mapper,
            IContaRepositorio contaRepositorio)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.contaRepositorio = contaRepositorio;
        }

        public async Task<Model.Conta> Handle(CriarContaCommand request, CancellationToken cancellationToken)
        {
            using (var uow = unitOfWork)
            {
                var resultado = await contaRepositorio.Inserir(mapper.Map<Model.Conta>(request));
                uow.PersistirTransacao();

                return resultado;
            }
        }
    }
}
