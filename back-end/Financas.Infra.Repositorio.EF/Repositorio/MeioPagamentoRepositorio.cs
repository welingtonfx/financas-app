using Financas.Dominio.Model;
using Financas.Infra.EF.Repositorio.Repositorio;
using Financas.Infra.Interface.Repositorio;
using Financas.Interface.Repositorio;

namespace Financas.Infra.Repositorio.EF.Repositorio
{
    public class MeioPagamentoRepositorio : RepositorioBase<MeioPagamento>, IMeioPagamentoRepositorio
    {
        public MeioPagamentoRepositorio(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
