using Financas.Dominio.Handler.Commands;
using Financas.Dominio.Handler.Handlers;
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

            return Ok(resultado);
        }

        [HttpPost("criarcategoria")]
        public async Task<IActionResult> CriarCategoria([FromBody] CriarCategoriaCommand command)
        {
            var categoria = await _mediator.Send(command);
            return CreatedAtAction("CriarCategoria", new { Categoria = categoria }, categoria);
        }

        [HttpDelete("excluircategoria/{id}")]
        public async Task<IActionResult> ExcluirResult(int id)
        {
            var command = new ExcluirCategoriaCommand() { Id = id };
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPut("alterarcategoria")]
        public async Task<IActionResult> AlterarCategoria([FromBody] AlterarCategoriaCommand command)
        {
            var categoria = await _mediator.Send(command);
            return CreatedAtAction("AlterarCategoria", new { Categoria = categoria }, categoria);
        }
    }
}
