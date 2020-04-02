using Financas.Dominio.Handler.Commands.MeioPagamento;
using FluentValidation;

namespace Financas.Dominio.Handler.Validation.MeioPagamento
{
    public class AlterarMeioPagamentoValidator : AbstractValidator<AlterarMeioPagamentoCommand>
    {
        public AlterarMeioPagamentoValidator()
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
