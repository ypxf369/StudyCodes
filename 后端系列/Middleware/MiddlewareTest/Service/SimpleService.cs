using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiddlewareTest.Middleware;

namespace MiddlewareTest.Service
{
    public class SimpleService : ISimpleService
    {
        private readonly SimpleOptions _options;
        public SimpleService(SimpleOptions options)
        {
            _options = options;
        }
        public void SayHello()
        {
            Console.WriteLine("Hello World!" + _options.Name + "_" + _options.Value);
        }
    }
}
