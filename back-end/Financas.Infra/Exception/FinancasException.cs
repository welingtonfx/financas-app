using System.Net;

namespace Financas.Infra.Exception
{
    public class FinancasException : System.Exception
    {
        public FinancasException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; set; }
    }
}
