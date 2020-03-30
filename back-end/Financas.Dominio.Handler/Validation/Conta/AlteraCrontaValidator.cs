using Financas.Dominio.Handler.Commands.Conta;
using FluentValidation;

namespace Financas.Dominio.Handler.Validation.Conta
{
    public class AlterarContaValidator : AbstractValidator<AlterarContaCommand>
    {
        public AlterarContaValidator()
        {
            RuleFor(p => p.IdContaTipo)
                .NotEmpty()
                .WithMessage("Preenchimento obrigatório [Tipo de conta]");

            RuleFor(p => p.Descricao)
                .NotEmpty()
                .WithMessage("Preenchimento obrigatório [Descrição]");
        }
    }
}
