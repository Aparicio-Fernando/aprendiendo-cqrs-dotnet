using FluentValidation;
using MediatR;

namespace TareasAPI.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // Si no hay validadores para este request, dejamos pasar
            if (!_validators.Any())
                return await next();

            // Ejecutamos todas las validaciones
            var context = new ValidationContext<TRequest>(request);
            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            // Si hay errores, los devolvemos sin llegar al Handler
            if (failures.Any())
            {
                var errores = string.Join(", ", failures.Select(f => f.ErrorMessage));
                // Convertimos el string de errores al tipo de respuesta esperado
                return (TResponse)(object)$"Error de validación: {errores}";
            }

            // Todo válido — dejamos pasar al Handler
            return await next();
        }
    }
}
