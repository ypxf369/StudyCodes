using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace MiddlewareTest.Middleware
{
    public static class SimpleMiddlewareServiceCollectionExtensions
    {
        public static IServiceCollection AddSimpleMiddleware(this IServiceCollection services)
        {
            //return services.AddTransient<>()
        }
    }
}
