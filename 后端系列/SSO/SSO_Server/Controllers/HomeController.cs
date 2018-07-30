using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace SSO_Server.Controllers
{
    public class HomeController : Controller
    {
        public static Dictionary<string, Guid> TokenIds = new Dictionary<string, Guid>();
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///  验证是否登录
        /// </summary>
        /// <param name="backUrl"></param>
        /// <returns></returns>
        public IActionResult Verification(string backUrl)
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                return Redirect("Login?backUrl=" + backUrl);
            }
            HttpContext.Session.SetString("user", "已经登录");
            return Redirect(backUrl + "?tokenId=" + TokenIds[HttpContext.Session.Id]);
        }

        /// <summary>
        /// 验证TokenId是否有效
        /// </summary>
        /// <param name="tokenId"></param>
        /// <returns></returns>
        public bool TokenIdIsValid(Guid tokenId)
        {
            return TokenIds.Any(i => i.Value == tokenId);
        }

        /// <summary>
        /// 返回登录页面
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public string Login(string name, string password, string backUrl)
        {
            if (true) //todo:验证用户名密码登录
            {
                HttpContext.Session.SetString("user", name + "已登录");
                //在认证中，保存客户端Client的登录认证码
                TokenIds.Add(HttpContext.Session.Id, Guid.NewGuid());
            }
            else//验证失败重新登录
            {
                return "/Home/Login";
            }

            return backUrl + "?tokenId=" + TokenIds[HttpContext.Session.Id];//生成一个tokenId发放到客户端
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Logout()
        {
            var http = _httpClientFactory.CreateClient();
            //清除客户端的session信息
            await http.GetAsync("http://localhost:5001/Home/ClearToken?tokenId=" + TokenIds[HttpContext.Session.Id]);
            await http.GetAsync("http://localhost:5002/Home/ClearToken?tokenId=" + TokenIds[HttpContext.Session.Id]);
            TokenIds.Remove(HttpContext.Session.Id);
            HttpContext.Session.SetString("user", null);
            return Redirect("Login");
        }
    }
}
