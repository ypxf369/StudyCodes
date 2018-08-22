using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MiddlewareTest.Middleware;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SimpleMiddlewareApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSimpleMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<SimpleMiddleware>(new SimpleOptions());
        }
        //public static IApplicationBuilder UseSimpleMiddleware(this IApplicationBuilder app, Action<SimpleOptions> action)
        //{
        //    var options = new SimpleOptions();
        //    action(options);
        //    return app.UseMiddleware<SimpleMiddleware>(options);
        //}

        public static IApplicationBuilder UseSimpleMiddleware(this IApplicationBuilder app, Action<MapOptions> action)
        {
            var options = new MapOptions();
            action(options);
            app.Map(options.Endpoint, i => i.Run(async context =>
              {
                  await context.Response.WriteAsync("Map test 111_" + options.Name);
              }));
            return app.UseMiddleware<SimpleMiddleware>(new SimpleOptions());
        }
    }
}
