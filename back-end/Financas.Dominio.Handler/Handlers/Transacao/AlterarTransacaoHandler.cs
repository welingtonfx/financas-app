using AutoMapper;
using Financas.Dominio.Handler.Commands.Transacao;
using Financas.Infra.Interface.Repositorio;
using Financas.Interface.Repositorio;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers.Transacao
{
    public class AlterarTransacaoHandler : HandlerBase, IRequestHandler<AlterarTransacaoCommand, Model.Transacao>
    {
        private readonly IMapper mapper;
        private readonly ITransacaoRepositorio transacaoRepositorio;

        public AlterarTransacaoHandler(IUnitOfWork unitOfWork,
            IMapper mapper,
            ITransacaoRepositorio transacaoRepositorio) : base(unitOfWork)
        {
            this.mapper = mapper;
            this.transacaoRepositorio = transacaoRepositorio;
        }

        public async Task<Model.Transacao> Handle(AlterarTransacaoCommand request, CancellationToken cancellationToken)
        {
            using (var uow = unitOfWork)
            {
                var transacao = await transacaoRepositorio.ObterPorId(request.Id) ?? new Model.Transacao();

                var resultado = await transacaoRepositorio.Alterar(mapper.Map(request, transacao));
                uow.PersistirTransacao();

                return resultado;
            }
        }
    }
}
