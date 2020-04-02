using AutoMapper;
using Financas.Dominio.Handler.Commands.MeioPagamento;
using Financas.Infra.Interface.Repositorio;
using Financas.Interface.Repositorio;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers.MeioPagamento
{
    public class CriarMeioPagamentoHandler : HandlerBase, IRequestHandler<CriarMeioPagamentoCommand, Model.MeioPagamento>
    {
        private readonly IMapper mapper;
        private readonly IMeioPagamentoRepositorio meioPagamentoRepositorio;

        public CriarMeioPagamentoHandler(IUnitOfWork unitOfWork,
            IMapper mapper,
            IMeioPagamentoRepositorio meioPagamentoRepositorio) : base(unitOfWork)
        {
            this.mapper = mapper;
            this.meioPagamentoRepositorio = meioPagamentoRepositorio;
        }

        public async Task<Model.MeioPagamento> Handle(CriarMeioPagamentoCommand request, CancellationToken cancellationToken)
        {
            using (var uow = unitOfWork)
            {
                var resultado = await meioPagamentoRepositorio.Inserir(mapper.Map<Model.MeioPagamento>(request));
                uow.PersistirTransacao();

                return resultado;
            }
        }
    }
}
