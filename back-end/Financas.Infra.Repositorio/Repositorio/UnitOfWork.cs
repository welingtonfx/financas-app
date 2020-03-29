using Financas.Infra.Interface.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace Financas.Infra.Repositorio.Repositorio
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Contexto { get; }

        public UnitOfWork(FinancasContext contexto)
        {
            Contexto = contexto;
        }

        public void PersistirTransacao()
        {
            Contexto.SaveChanges();
        }

        public void Dispose()
        {
            Contexto.Dispose();
        }
    }
}
