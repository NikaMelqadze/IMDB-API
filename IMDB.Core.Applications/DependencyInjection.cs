using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using IMDB.Core.Applications.Common.Behaviours;
using IMDB.Core.Applications.Common.Interfaces;
using IMDB.Core.Applications.Common.Repositories;
using IMDB.Core.Applications.Common.Jobs;

namespace IMDB.Core.Applications
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LocalizationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ErrorHandlingBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IOfferJob, OfferJob>();


            services.AddLocalization();
            //services.AddLogging();

            return services;
        }
    }
}
