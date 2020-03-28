using Financas.Dominio.Handler.Commands.Conta;
using Financas.Dominio.Handler.Queries.Conta;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Financas.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ContaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContaController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("obtercontas")]
        public async Task<IActionResult> ObterCategorias()
        {
            var query = new ObterContasQuery();
            var resultado = await _mediator.Send(query);

            return Ok(resultado);
        }

        [HttpPost("criarconta")]
        public async Task<IActionResult> CriarConta([FromBody] CriarContaCommand command)
        {
            var categoria = await _mediator.Send(command);
            return CreatedAtAction("CriarConta", new { Categoria = categoria }, categoria);
        }

        [HttpDelete("excluirconta/{id}")]
        public async Task<IActionResult> ExcluirCategoria(int id)
        {
            var command = new ExcluirContaCommand() { Id = id };
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPut("alterarconta/{id}")]
        public async Task<IActionResult> AlterarCategoria(int id, [FromBody] AlterarContaCommand command)
        {
            command.Id = id;
            var conta = await _mediator.Send(command);
            return CreatedAtAction("AlterarConta", new { Conta = conta }, conta);
        }
    }
}
