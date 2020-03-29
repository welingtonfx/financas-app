using Financas.Dominio.Model;
using Financas.Infra.Interface.Repositorio;
using Financas.Interface.Repositorio;

namespace Financas.Infra.Repositorio.Repositorio
{
    public class TransacaoRepositorio : RepositorioBase<Transacao>, ITransacaoRepositorio
    {
        public TransacaoRepositorio(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
