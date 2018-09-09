using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using log4net;
using log4net.Repository.Hierarchy;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TPSite.Extensions;

namespace TPSite.Interceptor
{
    /// <summary>
    /// 全局异常过滤器
    /// </summary>
    public class SystemExceptionFilter : IAsyncExceptionFilter
    {
        private static readonly ILog Logger = LogManager.GetLogger(Startup.Logger.Name, typeof(SystemExceptionFilter));
        public async Task OnExceptionAsync(ExceptionContext context)
        {
            var error = context.Exception;
            var message = error.Message;
            var httpContext = context.HttpContext;
            if (httpContext.Request.IsAjax())
            {
                context.Result = new JsonResult(new
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Msg = "服务器内部错误"
                });
            }
            else
            {
                context.Result = new RedirectResult("/Home/Error");
            }
            var innerException = error.InnerException?.Message;
            var url = httpContext?.Request.GetDisplayUrl();//错误发生地址

            await Task.Run(() => Logger.Error("Url:" + url + ";Message:" + message + "\r\n InnerException:" + innerException, error));
        }
    }
}
