using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Financas.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class FinancasController : ControllerBase
    {
        public FinancasController()
        {

        }

        [HttpGet("obtertransacoes")]
        public async Task<IActionResult> ObterTransacoes()
        {
            return Ok();
        }
    }
}
