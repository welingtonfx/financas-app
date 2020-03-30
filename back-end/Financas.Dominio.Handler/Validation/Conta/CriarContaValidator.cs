using Financas.Dominio.Handler.Commands.Conta;
using FluentValidation;

namespace Financas.Dominio.Handler.Validation.Conta
{
    public class CriarContaValidator : AbstractValidator<CriarContaCommand>
    {
        public CriarContaValidator()
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
