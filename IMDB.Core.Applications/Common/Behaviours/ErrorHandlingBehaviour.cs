using IMDB.Core.Applications.Common.CQRS.DTOs;
using IMDB.Core.Applications.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IMDB.Core.Applications.Common.Behaviours
{
    internal class ErrorHandlingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<TRequest> _logger;
        private readonly IStringLocalizer<Resources.ErrorsResource> _localizer;

        private const string InternalExceptionCode = "INTERNAL_EXCEPTION";

        public ErrorHandlingBehaviour(ILogger<TRequest> logger, IStringLocalizer<Resources.ErrorsResource> localizer)
        {            
               _logger = logger;
            _localizer = localizer;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "IMDB: Unhandled Exception for Request {Name} {@Request}", typeof(TRequest).Name, request);

                IResult result;
                if (ex is ExceptionBase)
                {
                    result = new FailedResult(_localizer[(ex as ExceptionBase).Code ?? InternalExceptionCode]
                                                     , (ex is ValidationException) ? (ex as ValidationException).Errors : null);
                }
                else
                {
                    result = new FailedResult(_localizer[InternalExceptionCode]);
                }
                return (TResponse)result;
            }
        }
    }
}
