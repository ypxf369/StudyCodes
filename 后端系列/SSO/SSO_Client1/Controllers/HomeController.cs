using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSO_Client1.Models;

namespace SSO_Client1.Controllers
{
    public class HomeController : Controller
    {
        public static List<string> Tokens = new List<string>();
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            string tokenId = Request.Query["tokenId"];
            //如果tokenId不为空，则由Service302过来的。
            if (tokenId != null)
            {
                var http = _httpClientFactory.CreateClient();
                //验证token是否有效
                var isValid = await http.GetStringAsync("http://localhost:5000/Home/TokenIdIsValid?tokenId=" + tokenId);
                if (bool.Parse(isValid))
                {
                    if (!Tokens.Contains(tokenId))
                    {
                        //记录登录过的Clinet（主要是为了可以统一登出）
                        Tokens.Add(tokenId);
                    }
                    HttpContext.Session.SetString("token", tokenId);
                }
            }

            //判断是否是登录状态
            if (HttpContext.Session.GetString("token") == null ||
                !Tokens.Contains(HttpContext.Session.GetString("token")))
            {
                return Redirect("http://localhost:5000/Home/Verification?backUrl=http://localhost:5001/Home");
            }
            //else
            //{
            //    if (HttpContext.Session.GetString("token") != null)
            //    {
            //        HttpContext.Session.SetString("token", null);
            //    }
            //}

            return View();
        }

        public void ClearToken(string tokenId)
        {
            Tokens.Remove(tokenId);
        }
    }
}
