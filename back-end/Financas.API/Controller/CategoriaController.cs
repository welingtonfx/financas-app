using Financas.Dominio.Handler.Handlers;
using Financas.Interface.Repositorio;
using MediatR;
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

        private readonly IMediator _mediator;

        public CategoriaController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("obtercategorias")]
        public async Task<IActionResult> ObterTransacoes()
        {
            var query = new ObterCategoriasQuery();
            var resultado = await _mediator.Send(query);

            //var resultado = await categoriaRepositorio.ObterCategorias();

            return Ok(resultado);
        }
    }
}
