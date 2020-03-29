using AutoMapper;
using Financas.Dominio.Handler.Commands.Transacao;
using Financas.Infra.Interface.Repositorio;
using Financas.Interface.Repositorio;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers.Transacao
{
    public class CriarTransacaoHandler : IRequestHandler<CriarTransacaoCommand, Model.Transacao>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ITransacaoRepositorio transacaoRepositorio;

        public CriarTransacaoHandler(IUnitOfWork unitOfWork,
            IMapper mapper,
            ITransacaoRepositorio transacaoRepositorio)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.transacaoRepositorio = transacaoRepositorio;
        }

        public async Task<Model.Transacao> Handle(CriarTransacaoCommand request, CancellationToken cancellationToken)
        {
            using (var uow = unitOfWork)
            {
                var resultado = await transacaoRepositorio.Inserir(mapper.Map<Model.Transacao>(request));
                uow.PersistirTransacao();

                return resultado;
            }
        }
    }
}
