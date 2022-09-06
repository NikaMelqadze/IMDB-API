using IMDB.Core.Applications.Common.CQRS;
using IMDB.Core.Applications.Common.Resources;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ValidationException = IMDB.Core.Applications.Common.Exceptions.ValidationException;

namespace IMDB.Core.Applications.Common.Behaviours
{
    internal class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
            where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly IStringLocalizer<ValidationResource> _localizer;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators, IStringLocalizer<ValidationResource> localizer)
        {
            _localizer = localizer;
            _validators = validators;
            ValidatorOptions.Global.CascadeMode = CascadeMode.Continue;
            ValidatorOptions.Global.DisplayNameResolver = (type, member, expression) =>
            {
                if (member != null)
                {
                    string key = member.Name;
                    var attributes = member.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                    if (attributes.Length == 1)
                    {
                        key = (attributes[0] as DisplayNameAttribute).Key;
                    }
                    return _localizer[key];
                }
                return null;
            };
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count != 0)
                    throw new ValidationException(failures);
            }
            return await next();
        }
    }
}
