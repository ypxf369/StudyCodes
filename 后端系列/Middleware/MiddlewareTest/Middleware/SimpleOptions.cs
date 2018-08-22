using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace MiddlewareTest.Middleware
{
    public class SimpleOptions : IOptions<SimpleOptions>
    {
        public string Name { get; set; } = "默认姓名";
        public string Value { get; set; } = "默认名字yepeng";

        SimpleOptions IOptions<SimpleOptions>.Value => this;
    }
}
