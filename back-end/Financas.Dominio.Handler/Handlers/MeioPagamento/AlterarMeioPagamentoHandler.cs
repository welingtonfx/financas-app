using AutoMapper;
using Financas.Dominio.Handler.Commands.MeioPagamento;
using Financas.Infra.Interface.Repositorio;
using Financas.Interface.Repositorio;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers.MeioPagamento
{
    public class AlterarMeioPagamentoHandler : HandlerBase, IRequestHandler<AlterarMeioPagamentoCommand, Model.MeioPagamento>
    {
        private readonly IMapper mapper;
        private readonly IMeioPagamentoRepositorio meioPagamentoRepositorio;

        public AlterarMeioPagamentoHandler(IUnitOfWork unitOfWork,
            IMapper mapper,
            IMeioPagamentoRepositorio meioPagamentoRepositorio) : base(unitOfWork)
        {
            this.mapper = mapper;
            this.meioPagamentoRepositorio = meioPagamentoRepositorio;
        }

        public async Task<Model.MeioPagamento> Handle(AlterarMeioPagamentoCommand request, CancellationToken cancellationToken)
        {
            using (var uow = unitOfWork)
            {
                var transacao = await meioPagamentoRepositorio.ObterPorId(request.Id) ?? new Model.MeioPagamento();

                var resultado = await meioPagamentoRepositorio.Alterar(mapper.Map(request, transacao));
                uow.PersistirTransacao();

                return resultado;
            }
        }
    }
}
