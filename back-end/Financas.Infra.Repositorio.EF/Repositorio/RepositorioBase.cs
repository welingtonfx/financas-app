using Financas.Dominio.Model;
using Financas.Infra.Interface.Repositorio;
using Financas.Infra.Repositorio.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Financas.Infra.EF.Repositorio.Repositorio
{
    public class RepositorioBase<T> : IRepositorio<T>
        where T: BaseEntidade, new()
    {
        private readonly IUnitOfWork unitOfWork;
        protected readonly DbContext Contexto;

        public RepositorioBase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.Contexto = unitOfWork.Contexto;
        }

        public async Task<IEnumerable<T>> Obter()
        {
            return unitOfWork.Contexto.Set<T>().AsEnumerable();
        }

        public async Task<IEnumerable<T>> Obter(Expression<Func<T, bool>> filtro = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] propriedadesInclude)
        {
            IQueryable<T> query = unitOfWork.Contexto.Set<T>();

            if (filtro != null)
                query = query.Where(filtro);

            foreach (var propriedadeInclude in propriedadesInclude)
                query = query.Include(propriedadeInclude);

            if (orderBy != null)
                return orderBy(query).AsEnumerable();
            else
                return query.AsEnumerable();
        }

        public async Task<T> ObterPorId(int id)
        {
            return unitOfWork.Contexto.Set<T>().SingleOrDefault(s => s.Id == id);
        }

        public async Task Inserir(IEnumerable<T> entidades)
        {
            foreach (var entidade in entidades)
                await Inserir(entidade);
        }

        public async Task<T> Inserir (T entidade)
        {
            unitOfWork.Contexto.Set<T>().Add(entidade);
            return entidade;
        }

        public async Task Alterar(IEnumerable<T> entidades)
        {
            foreach (var entidade in entidades)
                await Alterar(entidade);
        }

        public async Task<T> Alterar(T entidade)
        {
            unitOfWork.Contexto.Entry(entidade).State = EntityState.Modified;
            unitOfWork.Contexto.Set<T>().Update(entidade);
            return entidade;
        }

        public async Task Excluir(IEnumerable<int> ids)
        {
            IEnumerable<T> entidades = unitOfWork.Contexto.Set<T>().Where(p => ids.Contains(p.Id));

            foreach (var entidade in entidades)
                await Excluir(entidade);
        }

        public async Task Excluir(int id)
        {
            T entidade = unitOfWork.Contexto.Set<T>().SingleOrDefault(p => p.Id == id);

            if (entidade != null)
                unitOfWork.Contexto.Set<T>().Remove(entidade);
        }

        public async Task Excluir(T entidade)
        {
            if (unitOfWork.Contexto.Entry(entidade).State == EntityState.Detached)
                unitOfWork.Contexto.Attach(entidade);

            unitOfWork.Contexto.Remove(entidade);
        }
    }
}
