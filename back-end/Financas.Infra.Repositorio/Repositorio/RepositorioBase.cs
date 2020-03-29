using Financas.Dominio.Model;
using Financas.Infra.Interface.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financas.Infra.Repositorio.Repositorio
{
    public class RepositorioBase<T> : IRepositorio<T>
        where T: BaseEntidade, new()
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IServiceProvider serviceProvider;

        public RepositorioBase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<T>> Obter()
        {
            return unitOfWork.Contexto.Set<T>().AsEnumerable();
        }

        public async Task<T> ObterPorId(int id)
        {
            return unitOfWork.Contexto.Set<T>().SingleOrDefault(s => s.Id == id);
        }

        public async Task<T> Inserir (T entidade)
        {
            unitOfWork.Contexto.Set<T>().Add(entidade);
            return entidade;
        }

        public async Task<T> Alterar(T entidade)
        {
            unitOfWork.Contexto.Entry(entidade).State = EntityState.Modified;
            unitOfWork.Contexto.Set<T>().Attach(entidade);
            return entidade;
        }

        public async Task Excluir(int id)
        {
            T entidade = unitOfWork.Contexto.Set<T>().SingleOrDefault(p => p.Id == id);

            if (entidade != null)
                unitOfWork.Contexto.Set<T>().Remove(entidade);
        }
    }
}
