using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo2OrderService.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Demo2OrderService
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

            services.AddDbContext<OrderDbContext>();
            //要想实现消息的发布订阅订阅处理，必须在这里进行依赖注入
            services.AddScoped<IOrderService, OrderService>();
            services.AddCap(options =>
            {
                options.UseEntityFramework<OrderDbContext>(efOptions =>
                {
                    efOptions.Schema = "Orderas";//表名前缀 默认 Cap
                });

                options.UseRabbitMQ(mqOptions =>
                {
                    mqOptions.HostName = "127.0.0.1"; //默认localhost
                    mqOptions.UserName = "guest"; //用户名 默认：guest
                    mqOptions.Password = "guest"; //密码 默认：guest
                    //mqOptions.VirtualHost = "test";//虚拟主机 默认：/
                    mqOptions.Port = 5672; //端口号 默认：-1
                    mqOptions.ExchangeName = "cap.default.topic"; //CAP默认Exchange名称 默认：cap.default.topic
                    mqOptions.RequestedConnectionTimeout = 30000; //RabbitMQ连接超时时间 默认：30000毫秒
                    mqOptions.SocketReadTimeout = 30000; //RabbitMQ读取超时时间 默认：30000
                    mqOptions.SocketWriteTimeout = 30000; //RabbitMQ写入超时时间 默认：30000
                    mqOptions.QueueMessageExpires = 3; //队列中消息自动删除时间 默认：10天
                });

                options.UseDashboard();//启用仪表盘

                //订阅者所属的默认消费者组，默认值：cap.queue+程序集名称
                //options.DefaultGroup = "group";

                //成功的消息被删除的过期时间，默认3600秒
                //options.SucceedMessageExpiredAfter = 3600;

                //执行失败消息的回调函数 Action<MessageType, string, string>
                //当消息多次发送失败后，CAP会将消息状态标记为Failed，CAP有一个专门的处理者用来处理这种失败的消息，针对失败的消息会重新放入到队列中发送到MQ，在这之前如果FailedCallback具有值，那么将首先调用此回调函数来告诉客户端。
                //options.FailedThresholdCallback = (type, name, content) =>
                //{
                //    if (type == MessageType.Publish)
                //    {
                //        //name:消息名称
                //        //content:消息的内容
                //        //do something
                //    }
                //};

                //失败重试间隔时间 默认值：60秒
                options.FailedRetryInterval = 30;

                //失败最大重试次数 默认值：50次
                options.FailedRetryCount = 50;

            });

            services.AddHttpClient();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseCap();
        }
    }
}
