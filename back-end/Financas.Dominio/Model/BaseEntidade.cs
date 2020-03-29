using Financas.Dominio.Interface;

namespace Financas.Dominio.Model
{
    public class BaseEntidade : IIdentificador
    {
        public int Id { get; set; }
    }
}
