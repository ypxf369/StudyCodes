using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MiddlewareTest.Middleware
{
    public class SimpleMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly SimpleOptions _options;

        public SimpleMiddleware(RequestDelegate next, SimpleOptions options)
        {
            if (next == null)
            {
                throw new ArgumentNullException(nameof(next));
            }
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            _next = next;
            _options = options;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            context.Items["test"] = "测试哈哈哈_" + _options.Name + "_" + _options.Value;
            await _next(context);
        }
    }
}
