using Financas.Dominio.Handler.Commands.Transacao;
using Financas.Dominio.Handler.Queries.Transacao;
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
    public class TransacaoController : ControllerBase
    {
        private readonly INotificador notificador;
        private readonly IMediator mediator;

        public TransacaoController(INotificador notificador,
            IMediator mediator)
        {
            this.notificador = notificador;
            this.mediator = mediator;
        }

        [HttpGet("obtertransacoes")]
        public async Task<IActionResult> ObterTransacoes()
        {
            var query = new ObterTransacoesQuery();
            var resultado = await mediator.Send(query);

            return Ok(resultado);
        }

        [HttpPost("criartransacao")]
        public async Task<IActionResult> CriarTransacao([FromBody] CriarTransacaoCommand command)
        {
            try
            {
                var transacao = await mediator.Send(command);
                return CreatedAtAction("CriarTransacao", new { Transacao = transacao }, transacao);
            }
            catch (FinancasException ex) when (ex.StatusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(notificador.ObterMensagens());
            }
        }

        [HttpDelete("excluirtransacao/{id}")]
        public async Task<IActionResult> ExcluirTransacao(int id)
        {
            try
            {
                var command = new ExcluirTransacaoCommand() { Id = id };
                await mediator.Send(command);

                return Ok();
            }
            catch (FinancasException ex) when (ex.StatusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(notificador.ObterMensagens());
            }
        }

        [HttpPut("alterartransacao/{id}")]
        public async Task<IActionResult> AlterarTransacao(int id, [FromBody] AlterarTransacaoCommand command)
        {
            try
            {
                command.Id = id;
                var transacao = await mediator.Send(command);
                return CreatedAtAction("AlterarTransacao", new { Transacao = transacao }, transacao);
            }
            catch (FinancasException ex) when (ex.StatusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(notificador.ObterMensagens());
            }
        }
    }
}
