using Financas.Dominio.Handler.Commands.MeioPagamento;
using FluentValidation;

namespace Financas.Dominio.Handler.Validation.MeioPagamento
{
    public class CriarMeioPagamentoValidator : AbstractValidator<CriarMeioPagamentoCommand>
    {
        public CriarMeioPagamentoValidator()
        {
            RuleFor(p => p.IdMeioPagamentoTipo)
                .NotEmpty()
                .WithMessage("Preenchimento obrigatório [Tipo de meio de pagamento]");

            RuleFor(p => p.Descricao)
                .NotEmpty()
                .WithMessage("Preenchimento obrigatório [Descrição]");
        }
    }
}
