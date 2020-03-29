﻿using AutoMapper;
using Financas.Dominio.Handler.Commands.Categoria;
using Financas.Infra.Interface.Repositorio;
using Financas.Interface.Repositorio;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.Handlers.Categoria
{
    public class AlterarCategoriaHandler : IRequestHandler<AlterarCategoriaCommand, Model.Categoria>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ICategoriaRepositorio categoriaRepositorio;
        public AlterarCategoriaHandler(IUnitOfWork unitOfWork,
            IMapper mapper,
            ICategoriaRepositorio categoriaRepositorio)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<Model.Categoria> Handle(AlterarCategoriaCommand request, CancellationToken cancellationToken)
        {
            using (var uow = unitOfWork)
            {
                var categoria = await categoriaRepositorio.ObterPorId(request.Id) ?? new Model.Categoria();

                var resultado = await categoriaRepositorio.Alterar(mapper.Map(request, categoria));
                uow.PersistirTransacao();

                return resultado;
            }
        }

        private void MapearDadosCategoria(Model.Categoria categoria, AlterarCategoriaCommand request)
        {
            categoria.Descricao = request.Descricao;
            categoria.IdCategoriaPai = request.IdCategoriaPai;
        }
    }
}
