using Financas.Interface.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Financas.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepositorio categoriaRepositorio;

        public CategoriaController(ICategoriaRepositorio categoriaRepositorio)
        {
            this.categoriaRepositorio = categoriaRepositorio;
        }

        [HttpGet("obtercategorias")]
        public async Task<IActionResult> ObterTransacoes()
        {
            var resultado = await categoriaRepositorio.ObterCategorias();

            return Ok(resultado);
        }
    }
}
