using IMDB.Core.Applications.Common.Interfaces;
using IMDB.Infrastructure.Database;
using IMDB.Infrastructure.ServiceOptions;
using IMDB.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IMDB.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IMDBDbContext>(options =>
                 options.UseSqlServer(
                        configuration.GetConnectionString("IMDBConnectionString")));
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<IMDBDbContext>());

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<ICurrentRequestService, CurrentRequestService>();
            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<IMailSender, SMTPService>();
            services.AddScoped<IMovieService, IMDBService>();

            services.Configure<MovieServiceDataOptions>(configuration.GetSection("MovieServiceData"));
            
            return services;
        }
    }
}
