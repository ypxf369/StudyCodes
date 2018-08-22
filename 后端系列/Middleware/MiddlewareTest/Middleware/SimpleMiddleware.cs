using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MiddlewareTest.Service;

namespace MiddlewareTest.Middleware
{
    public class SimpleMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly SimpleOptions _options;
        private readonly ISimpleService _simpleService;

        public SimpleMiddleware(RequestDelegate next, SimpleOptions options, ISimpleService simpleService)
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
            _simpleService = simpleService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            context.Items["test"] = "测试哈哈哈_" + _options.Name + "_" + _options.Value;
            _simpleService.SayHello();
            await _next(context);
        }
    }
}
