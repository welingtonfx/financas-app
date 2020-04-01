using AutoMapper;
using Financas.Dominio.Handler.Commands.Conta;
using Financas.Infra.Interface.Repositorio;
using Financas.Interface.Repositorio;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers.Conta
{
    public class AlterarContaHandler : HandlerBase, IRequestHandler<AlterarContaCommand, Model.Conta>
    {
        private readonly IMapper mapper;
        private readonly IContaRepositorio contaRepositorio;

        public AlterarContaHandler(IUnitOfWork unitOfWork,
            IMapper mapper,
            IContaRepositorio contaRepositorio) : base(unitOfWork)
        {
            this.mapper = mapper;
            this.contaRepositorio = contaRepositorio;
        }

        public async Task<Model.Conta> Handle(AlterarContaCommand request, CancellationToken cancellationToken)
        {
            using (var uow = unitOfWork)
            {
                var conta = await contaRepositorio.ObterPorId(request.Id) ?? new Model.Conta();
                conta.PreencherDataAlteracao();

                var resultado = await contaRepositorio.Alterar(mapper.Map(request, conta));
                uow.PersistirTransacao();

                return resultado;
            }
        }
    }
}
