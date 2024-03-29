﻿using Financas.Dominio.Model;
using Financas.Infra.Interface.Repositorio;
using Financas.Interface.Repositorio;

namespace Financas.Infra.EF.Repositorio.Repositorio
{
    public class ContaRepositorio : RepositorioBase<Conta>, IContaRepositorio
    {
        public ContaRepositorio(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
