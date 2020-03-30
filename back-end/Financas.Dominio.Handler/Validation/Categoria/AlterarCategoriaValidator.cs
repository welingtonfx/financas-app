using Financas.Dominio.Handler.Commands.Categoria;
using FluentValidation;

namespace Financas.Dominio.Handler.Validation.Categoria
{
    public class AlterarCategoriaValidator : AbstractValidator<AlterarCategoriaCommand>
    {
        public AlterarCategoriaValidator()
        {
            RuleFor(p => p.Descricao)
                .NotEmpty()
                .WithMessage("Preenchimento obrigatório [Descrição]");
        }
    }
}
