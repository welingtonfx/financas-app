using Financas.Dominio.Handler.Commands.Transacao;
using Financas.Dominio.Handler.Queries.Transacao;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Financas.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class TransacaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransacaoController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("obtertransacoes")]
        public async Task<IActionResult> ObterTransacoes()
        {
            var query = new ObterTransacoesQuery();
            var resultado = await _mediator.Send(query);

            return Ok(resultado);
        }

        [HttpPost("criartransacao")]
        public async Task<IActionResult> CriarTransacao([FromBody] CriarTransacaoCommand command)
        {
            var transacao = await _mediator.Send(command);
            return CreatedAtAction("CriarTransacao", new { Transacao = transacao }, transacao);
        }

        [HttpDelete("excluirtransacao/{id}")]
        public async Task<IActionResult> ExcluirTransacao(int id)
        {
            var command = new ExcluirTransacaoCommand() { Id = id };
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPut("alterartransacao/{id}")]
        public async Task<IActionResult> AlterarTransacao(int id, [FromBody] AlterarTransacaoCommand command)
        {
            command.Id = id;
            var transacao = await _mediator.Send(command);
            return CreatedAtAction("AlterarTransacao", new { Transacao = transacao }, transacao);
        }
    }
}
