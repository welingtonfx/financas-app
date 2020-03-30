using Financas.Dominio.Handler.Commands.Categoria;
using Financas.Dominio.Handler.Handlers.Categoria;
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
    public class CategoriaController : ControllerBase
    {
        private readonly INotificador notificador;
        private readonly IMediator mediator;

        public CategoriaController(INotificador notificador,
            IMediator mediator)
        {
            this.notificador = notificador;
            this.mediator = mediator;
        }

        [HttpGet("obtercategorias")]
        public async Task<IActionResult> ObterCategorias()
        {
            var query = new ObterCategoriasQuery();
            var resultado = await mediator.Send(query);

            return Ok(resultado);
        }

        [HttpPost("criarcategoria")]
        public async Task<IActionResult> CriarCategoria([FromBody] CriarCategoriaCommand command)
        {
            try
            {
                var categoria = await mediator.Send(command);
                return CreatedAtAction("CriarCategoria", new { Categoria = categoria }, categoria);
            }
            catch (FinancasException ex) when (ex.StatusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(notificador.ObterMensagens());
            }
        }

        [HttpDelete("excluircategoria/{id}")]
        public async Task<IActionResult> ExcluirCategoria(int id)
        {
            try
            {
                var command = new ExcluirCategoriaCommand() { Id = id };
                await mediator.Send(command);

                return Ok();
            }
            catch (FinancasException ex) when (ex.StatusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(notificador.ObterMensagens());
            }
        }

        [HttpPut("alterarcategoria/{id}")]
        public async Task<IActionResult> AlterarCategoria(int id, [FromBody] AlterarCategoriaCommand command)
        {
            try
            {
                command.Id = id;
                var categoria = await mediator.Send(command);
                return CreatedAtAction("AlterarCategoria", new { Categoria = categoria }, categoria);
            }
            catch (FinancasException ex) when (ex.StatusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(notificador.ObterMensagens());
            }
        }
    }
}
