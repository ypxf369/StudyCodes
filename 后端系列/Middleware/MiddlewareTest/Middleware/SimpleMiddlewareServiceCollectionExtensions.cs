using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MiddlewareTest.Middleware;
using MiddlewareTest.Service;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SimpleMiddlewareServiceCollectionExtensions
    {
        public static IServiceCollection AddSimpleMiddleware(this IServiceCollection services)
        {
            return services.AddTransient<ISimpleService, SimpleService>();
        }

        public static IServiceCollection AddSimpleMiddleware(this IServiceCollection services, Action<SimpleOptions> action)
        {
            var options = new SimpleOptions();
            action(options);
            return services.AddTransient<ISimpleService, SimpleService>(factory => new SimpleService(options));
        }
    }
}
