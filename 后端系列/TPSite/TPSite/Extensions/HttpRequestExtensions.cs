using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TPSite.Extensions
{
    public static class HttpRequestExtensions
    {
        public static bool IsAjax(this HttpRequest req)
        {
            bool result = false;

            var xreq = req.Headers.ContainsKey("x-requested-with");
            if (xreq)
            {
                result = req.Headers["x-requested-with"].ToString().Equals("XMLHttpRequest", StringComparison.OrdinalIgnoreCase);
            }

            return result;
        }
    }
}
