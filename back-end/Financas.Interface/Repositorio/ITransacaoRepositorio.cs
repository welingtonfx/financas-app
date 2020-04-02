using Financas.Dominio.Model;
using Financas.Infra.Interface.Repositorio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Financas.Interface.Repositorio
{
    public interface ITransacaoRepositorio : IRepositorio<Transacao>
    {
        Task<IEnumerable<Transacao>> ObterTransacoesComDetalhes();
    }
}
