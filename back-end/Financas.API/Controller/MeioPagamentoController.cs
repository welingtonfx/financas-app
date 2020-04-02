using Financas.Dominio.Handler.Commands.MeioPagamento;
using Financas.Dominio.Handler.Queries.MeioPagamento;
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
    public class MeioPagamentoController : ControllerBase
    {
        private readonly INotificador notificador;
        private readonly IMediator mediator;

        public MeioPagamentoController(INotificador notificador,
            IMediator mediator)
        {
            this.notificador = notificador;
            this.mediator = mediator;
        }

        [HttpGet("obtermeiospagamento")]
        public async Task<IActionResult> ObterMeiosPagamento()
        {
            var query = new ObterMeioPagamentoQuery();
            var resultado = await mediator.Send(query);

            return Ok(resultado);
        }

        [HttpPost("criarmeiopagamento")]
        public async Task<IActionResult> CriarMeioPagamento([FromBody] CriarMeioPagamentoCommand command)
        {
            try
            {
                var meioPagamento = await mediator.Send(command);
                return CreatedAtAction("CriarMeioPagamento", new { MeioPagamento = meioPagamento }, meioPagamento);
            }
            catch (FinancasException ex) when (ex.StatusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(notificador.ObterMensagens());
            }
        }

        [HttpDelete("excluirmeiopagamento/{id}")]
        public async Task<IActionResult> ExcluirMeioPagamento(int id)
        {
            try
            {
                var command = new ExcluirMeioPagamentoCommand() { Id = id };
                await mediator.Send(command);

                return Ok();
            }
            catch (FinancasException ex) when (ex.StatusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(notificador.ObterMensagens());
            }
        }

        [HttpPut("alterarmeiopagamento/{id}")]
        public async Task<IActionResult> AlterarMeioPagamento(int id, [FromBody] AlterarMeioPagamentoCommand command)
        {
            try
            {
                command.Id = id;
                var meioPagamento = await mediator.Send(command);
                return CreatedAtAction("AlterarMeioPagamento", new { MeioPagamento = meioPagamento }, meioPagamento);
            }
            catch (FinancasException ex) when (ex.StatusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(notificador.ObterMensagens());
            }
        }
    }
}
