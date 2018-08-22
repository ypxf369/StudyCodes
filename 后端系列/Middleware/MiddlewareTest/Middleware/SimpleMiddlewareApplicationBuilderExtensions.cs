using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using MiddlewareTest.Middleware;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SimpleMiddlewareApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSimpleMiddleware(this IApplicationBuilder app, Action<SimpleOptions> action)
        {
            var options = new SimpleOptions();
            action(options);
            return app.UseMiddleware<SimpleMiddleware>(options);
        }
    }
}
