﻿using Financas.Dominio.Handler.Commands.Transacao;
using FluentValidation;

namespace Financas.Dominio.Handler.Validation.Transacao
{
    public class AlterarTransacaoValidator : AbstractValidator<AlterarTransacaoCommand>
    {
        public AlterarTransacaoValidator()
        {
            RuleFor(p => p.IdTransacaoTipo)
                .NotEmpty()
                .WithMessage("Preenchimento obrigatório [Tipo]");

            RuleFor(p => p.DataTransacao)
                .NotEmpty()
                .WithMessage("Preenchimento obrigatório [Data]");

            RuleFor(p => p.ValorTotal)
                .GreaterThan(0)
                .WithMessage("[Valor] deve ser maior que 0");
        }
    }
}
