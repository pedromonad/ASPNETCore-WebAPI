using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SampleWebApiAspNetCore.Models;
using SampleWebApiAspNetCore.Repositories;
using SampleWebApiAspNetCore.Services;
using Microsoft.EntityFrameworkCore;

namespace SampleWebApiAspNetCore
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }


        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /*services.AddSingleton<IMoviesRepository, MoviesRepository>();

            services.AddTransient<IMoviesMapper, MoviesMapper>();
            // Add framework services.
            services.AddMvc();

            */

            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            //Configuring DbContext: https://docs.microsoft.com/en-us/ef/core/miscellaneous/configuring-dbcontext
            services.AddDbContext<MoviesDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Movies"));
            });

            services.AddMvc();

            services.AddScoped<IMoviesRepository, MoviesRepository>();
            //services.AddTransient<IMoviesMapper, MoviesMapper>();
            services.AddTransient<Seeder>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, Seeder seeder)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc();

            seeder.SeedAsync().Wait();
        }
    }
}
