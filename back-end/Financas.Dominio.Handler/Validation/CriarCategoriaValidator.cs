using Financas.Dominio.Handler.Commands;
using Financas.Dominio.Handler.Commands.Categoria;
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
