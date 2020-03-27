using Financas.Dominio.Handler.Commands;
using FluentValidation;

namespace Financas.Dominio.Handler.Validation
{
    public class CriarCategoriaValidator : AbstractValidator<CriarCategoriaCommand>
    {
        public CriarCategoriaValidator()
        {
            RuleFor(p => p.Descricao)
                .NotEmpty();
        }
    }
}
