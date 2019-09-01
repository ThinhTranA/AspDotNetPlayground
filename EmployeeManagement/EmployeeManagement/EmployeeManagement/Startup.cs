using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace EmployeeManagement
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
                            ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                logger.LogInformation("MW1: incoming request");
                await next();
                logger.LogInformation("MW1: outgoing reponse");
            });

            app.Use(async (context, next) =>
            {
                logger.LogInformation("MW2: incoming request");
                await next();
                logger.LogInformation("MW2: outgoing reponse");
            });

            app.Run(async (context) =>
            {
                await context.Response
                .WriteAsync("MW3: Request handled and reponse produced");
                logger.LogInformation("MW3: Request handled and reponse produced");
            });

            //Output:
             //MW1: incoming request
             //MW2: incoming request
             //MW3: Request handled and reponse produced
             //MW2: outgoing reponse
             //MW1: outgoing reponse
        }
    }
}
