using Microsoft.EntityFrameworkCore;
using System;

namespace Financas.Infra.Interface.Repositorio
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Contexto { get; }
        void PersistirTransacao();
    }
}
