using Hangfire;
using Hangfire.MemoryStorage;
using IMDB.Core.Applications;
using IMDB.Core.Applications.Common.Interfaces;
using IMDB.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace IMDB_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHangfire(config =>
             config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170).
             UseSimpleAssemblyNameTypeSerializer()
             .UseDefaultTypeSerializer()
             .UseMemoryStorage());

            services.AddHangfireServer();


            services.AddApplication();
            services.AddDataAccess(Configuration);

            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IMDB_API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                              IWebHostEnvironment env,
                              IRecurringJobManager recurringJobManager,
                              IServiceProvider serviceProvider)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IMDB_API v1"));
            }

            app.UseCors(builder => builder.AllowAnyOrigin()
                                          .AllowAnyHeader()
                                          .AllowAnyMethod());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.UseHangfireDashboard();

            recurringJobManager.AddOrUpdate("OfferMoviesJob", () =>
            serviceProvider.GetService<IOfferJob>().OfferMovies(), "30 19 * * 0");

        }
    }
}
