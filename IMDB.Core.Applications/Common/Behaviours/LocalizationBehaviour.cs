using IMDB.Core.Applications.Common.CQRS;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IMDB.Core.Applications.Common.Behaviours
{
    public class LocalizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
            where TRequest : IRequest<TResponse>
    {
        public LocalizationBehaviour()
        {

        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (request is RequestBase)
            {
                string culture = (request as RequestBase).Language switch
                {
                    Enums.Languages.Georgian => "ka-GE",
                    Enums.Languages.English => "en-US",
                    _ => "ka-GE",
                };
                Thread.CurrentThread.CurrentCulture
                    = Thread.CurrentThread.CurrentUICulture
                    = FluentValidation.ValidatorOptions.Global.LanguageManager.Culture
                    = System.Globalization.CultureInfo.CreateSpecificCulture(culture);
            }
            return await next();
        }
    }
}
