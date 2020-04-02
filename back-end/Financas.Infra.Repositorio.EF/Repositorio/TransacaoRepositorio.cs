using Financas.Dominio.Model;
using Financas.Infra.Interface.Repositorio;
using Financas.Interface.Repositorio;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Financas.Infra.EF.Repositorio.Repositorio
{
    public class TransacaoRepositorio : RepositorioBase<Transacao>, ITransacaoRepositorio
    {
        public TransacaoRepositorio(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<IEnumerable<Transacao>> ObterTransacoesComDetalhes()
        {
            return Contexto.Set<Transacao>()
                .Include(i => i.Detalhes);
        }
    }
}
