using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApplication1.Contracts;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1
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

            var con = "server=.;database=H_Plus_Sports;trusted_connection=true;";
            services.AddDbContext<H_Plus_SportsContext>(options => options.UseSqlServer(con));

          
           services.AddSingleton<ICustomerRepository, CustomerRepository>();
         //   services.AddSingleton<ISalespersonRepository, SalespersonRepository>();
          //  services.AddSingleton<IProductRepository, ProductRepository>();
         //   services.AddSingleton<IOrderRepository, OrderRepository>();
          //  services.AddSingleton<IOrderItemRepository, OrderItemRepository>();
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
