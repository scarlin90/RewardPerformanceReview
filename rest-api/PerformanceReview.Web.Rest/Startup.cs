using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PerformanceReview.Data.EntityFramework;
using PerformanceReview.Data.EntityFramework.Entity;
using PerformanceReview.Data.EntityFramework.Repository;
using PerformanceReview.Web.Rest.Models;

namespace PerformanceReview.Web.Rest
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
            services.AddMvc(setup => {
                setup.ReturnHttpNotAcceptable = true;
                setup.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            });
            services.AddDbContext<PerformanceReviewContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PerformanceReviewConnection")));
            services.AddScoped<IPerformanceReviewRepository, PerformanceReviewRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected exception occured, please try again later.");
                    });
                });
            }

            AutoMapper.Mapper.Initialize(cfg => 
            {
                cfg.CreateMap<Employee, EmployeeDto>();
                cfg.CreateMap<EmployeeReview, EmployeeReviewDto>();
                cfg.CreateMap<EmployeeForCreationDto, Employee>();
            });

            app.UseMvc();
        }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PerformanceReviewContext>
    {
        public PerformanceReviewContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<PerformanceReviewContext>();

            var connectionString = configuration.GetConnectionString("PerformanceReviewConnection");

            builder.UseSqlServer(connectionString, b => b.MigrationsAssembly("PerformanceReview.Web.Rest"));

            return new PerformanceReviewContext(builder.Options);
        }
    }
}
