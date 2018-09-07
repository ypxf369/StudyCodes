using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TPSite.Extensions
{
    public static class JsonResultExtensions
    {
        public static JsonResult MyJsonResult(this JsonResult jsonResult, HttpStatusCode statusCode, string msg,
            object data = null)
        {
            var result = new AjaxResult { StatusCode = statusCode, Msg = msg, Data = data };
            var settings = new JsonSerializerSettings
            {
                //忽略循环引用
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                DateFormatString = "yyyy/MM/dd HH:mm",
                //json中属性开头字母小写的驼峰命名
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            };
            return new JsonResult(result, settings);
        }

        public class AjaxResult
        {
            /// <summary>
            /// 状态码
            /// </summary>
            public HttpStatusCode StatusCode { get; set; }

            /// <summary>
            /// 消息
            /// </summary>
            public string Msg { get; set; }

            /// <summary>
            /// 执行返回的数据
            /// </summary>
            public object Data { get; set; }
        }
    }
}
