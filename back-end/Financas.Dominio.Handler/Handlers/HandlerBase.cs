using Financas.Infra.Interface.Repositorio;

namespace Financas.Dominio.Handler.Handlers
{
    public class HandlerBase
    {
        protected readonly IUnitOfWork unitOfWork;

        public HandlerBase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
