using AutoMapper;
using Financas.Dominio.Handler.Commands.MeioPagamento;
using Financas.Infra.Interface.Repositorio;
using Financas.Interface.Repositorio;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers.MeioPagamento
{
    public class ExcluirMeioPagamentoHandler : HandlerBase, IRequestHandler<ExcluirMeioPagamentoCommand>
    {
        private readonly IMapper mapper;
        private readonly IMeioPagamentoRepositorio meioPagamentoRepositorio;

        public ExcluirMeioPagamentoHandler(IUnitOfWork unitOfWork,
            IMapper mapper,
            IMeioPagamentoRepositorio meioPagamentoRepositorio) : base(unitOfWork)
        {
            this.mapper = mapper;
            this.meioPagamentoRepositorio = meioPagamentoRepositorio;
        }

        public async Task<Unit> Handle(ExcluirMeioPagamentoCommand request, CancellationToken cancellationToken)
        {
            using (var uow = unitOfWork)
            {
                await meioPagamentoRepositorio.Excluir(request.Id);
                uow.PersistirTransacao();
                return Unit.Value;
            }
        }
    }
}
