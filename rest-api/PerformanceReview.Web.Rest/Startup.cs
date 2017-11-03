using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
<<<<<<< Updated upstream
=======
using PerformanceReview.Data.EntityFramework;
using PerformanceReview.Data.EntityFramework.Repository;
>>>>>>> Stashed changes

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
            services.AddMvc();
<<<<<<< Updated upstream
=======
            services.AddDbContext<PerformanceReviewContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PerformanceReviewConnection")));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
>>>>>>> Stashed changes
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
