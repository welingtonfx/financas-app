using Financas.Dominio.Handler.Commands.Conta;
using Financas.Dominio.Handler.Queries.Conta;
using Financas.Infra.Exception;
using Financas.Infra.Interface.Comum;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Financas.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ContaController : ControllerBase
    {
        private readonly INotificador notificador;
        private readonly IMediator mediator;

        public ContaController(INotificador notificador,
            IMediator mediator)
        {
            this.notificador = notificador;
            this.mediator = mediator;
        }

        [HttpGet("obtercontas")]
        public async Task<IActionResult> ObterCategorias()
        {
            var query = new ObterContasQuery();
            var resultado = await mediator.Send(query);

            return Ok(resultado);
        }

        [HttpPost("criarconta")]
        public async Task<IActionResult> CriarConta([FromBody] CriarContaCommand command)
        {
            try
            {
                var categoria = await mediator.Send(command);
                return CreatedAtAction("CriarConta", new { Categoria = categoria }, categoria);
            }
            catch (FinancasException ex) when (ex.StatusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(notificador.ObterMensagens());
            }
        }

        [HttpDelete("excluirconta/{id}")]
        public async Task<IActionResult> ExcluirCategoria(int id)
        {
            try
            {
                var command = new ExcluirContaCommand() { Id = id };
                await mediator.Send(command);

                return Ok();
            }
            catch (FinancasException ex) when (ex.StatusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(notificador.ObterMensagens());
            }
        }

        [HttpPut("alterarconta/{id}")]
        public async Task<IActionResult> AlterarConta(int id, [FromBody] AlterarContaCommand command)
        {
            try
            {
                command.Id = id;
                var conta = await mediator.Send(command);
                return CreatedAtAction("AlterarConta", new { Conta = conta }, conta);
            }
            catch (FinancasException ex) when (ex.StatusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(notificador.ObterMensagens());
            }
        }
    }
}
