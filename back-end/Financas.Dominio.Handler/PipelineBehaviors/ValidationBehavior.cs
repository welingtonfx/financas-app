using Financas.Infra.Exception;
using Financas.Infra.Interface;
using Financas.Infra.Interface.Comum;
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Dominio.Handler.PipelineBehaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly INotificador notificador;
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationBehavior(INotificador notificador,
            IEnumerable<IValidator<TRequest>> validators)
        {
            this.notificador = notificador;
            this.validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext(request);

            var failures = validators
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .Select(x => new Mensagem(x.ErrorMessage, MensagemTipoEnum.Erro));

            if (failures.Any())
            {
                this.notificador.AdicionarMensagens(failures);
                throw new FinancasException(HttpStatusCode.BadRequest);
            }

            return await next();
        }
    }
}
