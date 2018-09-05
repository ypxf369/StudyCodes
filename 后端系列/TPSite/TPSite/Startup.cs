using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TPSite.EntityFrameworkCore;
using TPSite.Extras.AutoMapper.Startup;
using TPSite.Interceptor;
using TPSite.IService.Convention;

namespace TPSite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Logger = LogManager.CreateRepository("TPSiteRepository");
            XmlConfigurator.Configure(Logger, new FileInfo("log4net.config"));
        }

        public static ILoggerRepository Logger { get; set; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddDbContext<EfCoreDbContext>();
            services.AddAuthorization();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "CookieLoginScheme";
            }).AddCookie(cookie =>
            {
                cookie.LoginPath = new PathString("/Account/Login");
                cookie.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                cookie.SlidingExpiration = true;
            });
            services.AddMvc(options =>
            {
                options.Filters.Add<SystemExceptionFilter>();//添加异常过滤器
                options.Filters.Add<AuditingFilter>();//审计日志过滤器
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var builder = new ContainerBuilder();//实例化Autofac容器
            builder.Populate(services);

            var assemblys = Assembly.Load("TPSite.Service");
            var baseType = typeof(IServiceSupport);

            builder.RegisterAssemblyTypes(assemblys)
                .Where(i => baseType.IsAssignableFrom(i) && i != baseType)
                .AsImplementedInterfaces();
            var container = builder.Build();
            return new AutofacServiceProvider(container);//让Autofac接管core内置DI容器
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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                ContentTypeProvider = new FileExtensionContentTypeProvider
                {
                    Mappings =
                    {
                        new KeyValuePair<string, string>(".moc",""),
                        new KeyValuePair<string, string>(".mtn","")
                    }
                }
            });
            app.UseCookiePolicy();

            AutoMapperStartup.Register();//加载AutoMapper配置项

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "live2d",
                    template: "{controller}",
                    defaults: "live2d/model.moc"
                );
            });
        }
    }
}
