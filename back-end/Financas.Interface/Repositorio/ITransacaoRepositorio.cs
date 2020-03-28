using Financas.Dominio.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Financas.Interface.Repositorio
{
    public interface ITransacaoRepositorio
    {
        Task<IEnumerable<Transacao>> ObterTransacoes();
        Task<Transacao> ObterTransacaoPorId(int id);
        Task<Transacao> CriarTransacao(Transacao transacao);
        Task<Transacao> AlterarTransacao(Transacao transacao);
        Task ExcluirTransacao(int id);
    }
}
