using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OrderService.Models.Databases;
using OrderService.Repositories;

namespace OrderService
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Repository
            services.AddScoped<IOrderRepository, OrderRepository>();

            //EF DbContext
            services.AddDbContext<OrderDbContext>();

            //Dapper-ConnStringa
            services.AddSingleton(Configuration["DB:OrderDB"]);

            //CAP
            services.AddCap(i =>
            {
                i.UseEntityFramework<OrderDbContext>(); //EF
                i.UseSqlServer(Configuration["DB:OrderDB"]); //SQLServer
                i.UseRabbitMQ(cfg =>
                {
                    cfg.HostName = Configuration["MQ:Host"];
                    cfg.VirtualHost = Configuration["MQ:VirtualHost"];
                    cfg.Port = Convert.ToInt32(Configuration["MQ:Port"]);
                    cfg.UserName = Configuration["MQ:UserName"];
                    cfg.Password = Configuration["MQ:Password"];
                }); //RabbitMQ

                i.UseDashboard(); //Dashboard

                i.FailedRetryCount = 2;
                i.FailedRetryInterval = 5; //重试间隔
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            //CAP
            app.UseCap();
        }
    }
}
