using Financas.Dominio.Handler.Commands.Categoria;
using FluentValidation;

namespace Financas.Dominio.Handler.Categoria.Validation
{
    public class CriarCategoriaValidator : AbstractValidator<CriarCategoriaCommand>
    {
        public CriarCategoriaValidator()
        {
            RuleFor(p => p.Descricao)
                .NotEmpty()
                .WithMessage("Preenchimento obrigatório [Descrição]");
        }
    }
}
