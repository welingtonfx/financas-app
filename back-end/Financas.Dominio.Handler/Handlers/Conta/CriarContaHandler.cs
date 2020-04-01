using AutoMapper;
using Financas.Dominio.Handler.Commands.Conta;
using Financas.Infra.Interface.Repositorio;
using Financas.Interface.Repositorio;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers.Conta
{
    public class CriarContaHandler : HandlerBase, IRequestHandler<CriarContaCommand, Model.Conta>
    {
        private readonly IMapper mapper;
        private readonly IContaRepositorio contaRepositorio;

        public CriarContaHandler(IUnitOfWork unitOfWork,
            IMapper mapper,
            IContaRepositorio contaRepositorio) : base(unitOfWork)
        {
            this.mapper = mapper;
            this.contaRepositorio = contaRepositorio;
        }

        public async Task<Model.Conta> Handle(CriarContaCommand request, CancellationToken cancellationToken)
        {
            using (var uow = unitOfWork)
            {
                var conta = mapper.Map<Model.Conta>(request);
                conta.DataCriacao = conta.DataAlteracao = DateTime.Now;

                var resultado = await contaRepositorio.Inserir(conta);
                uow.PersistirTransacao();

                return resultado;
            }
        }
    }
}
