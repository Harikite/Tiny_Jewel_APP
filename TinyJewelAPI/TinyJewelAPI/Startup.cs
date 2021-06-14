using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyJewel.Infrastructure.Repository;
using TinyJewel.MiddleWare;
using TinyJewelAPI.Middleware;
using TinyJewelCore.BusinessLogic.AccountBL;
using TinyJewelCore.BusinessLogic.CustomerBL;
using TinyJewelCore.BusinessLogic.Utility;
using TinyJewelInfrastructure.DataAccess;
using TinyJewelInfrastructure.Service;
 

namespace TinyJewelAPI
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

            services.AddControllers();//.AddNewtonsoftJson()

            services.AddDbContext<CustomerDBContext>(opt => opt.UseInMemoryDatabase("CustomerDB")); ;
            //services.AddScoped<CustomerDBContext>();

            services.AddCors();

            services.AddScoped<IJwtUtils, JwtUtils>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountBL, AccountBL>();
            services.AddScoped<ICustomerBL, CustomerBL>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // global cors policy
            app.UseCors(x => x
                .SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            // global error handler
            app.UseMiddleware<ErrorHandlerMiddleware>();

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
