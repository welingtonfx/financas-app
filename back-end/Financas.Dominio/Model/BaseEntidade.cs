using Financas.Infra.Interface.Comum;

namespace Financas.Dominio.Model
{
    public class BaseEntidade : IIdentificador
    {
        public int Id { get; set; }
    }
}
