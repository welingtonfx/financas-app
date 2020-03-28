using Financas.Dominio.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Financas.Interface.Repositorio
{
    public interface ITransacaoRepositorio
    {
        Task<IEnumerable<Transacao>> Obter();
        Task<Transacao> ObterPorId(int id);
        Task<Transacao> Inserir(Transacao entidade);
        Task<Transacao> Alterar(Transacao entidade);
        Task Excluir(int id);
    }
}
