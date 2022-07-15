using Application.Repositories;
using Application.UseCases;
using Application.UseCases.GetTransactions.Queries;
using Application.UseCases.GetTransactions.Types;
using GraphiQl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace TransactionProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .Build();
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment HostingEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //transaction
            services.AddTransient<TransactionsMock, TransactionsMock>();
            services.AddScoped<TransactionQuery>();
            services.AddScoped<TransactionType>();
            services.AddScoped<TransactionInputType>();

            services.AddScoped<GraphQlSchema>();

            services
              .AddMvc(option => option.EnableEndpointRouting = false)
              .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
              .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.EnvironmentName.ToString() == "dev")
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphiQl();
            app.UseMvc();
        }
    }
}
