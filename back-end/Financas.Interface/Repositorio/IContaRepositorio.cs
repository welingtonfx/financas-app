using Financas.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Financas.Interface.Repositorio
{
    public interface IContaRepositorio
    {
        Task<IEnumerable<Conta>> Obter();
        Task<Conta> ObterPorId(int id);
        Task<Conta> Inserir(Conta entidade);
        Task<Conta> Alterar(Conta entidade);
        Task Excluir(int id);
    }
}
