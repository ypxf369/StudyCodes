using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using TPSite.Domain.Enum;
using TPSite.Extensions;
using TPSite.IService;
using TPSite.Models;
using TPSite.Tools.Extensions;

namespace TPSite.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (model.UserName.IsNullOrWhiteSpace())
            {
                return this.Json(HttpStatusCode.BadRequest, "用户名不能为空");
            }
            if (model.Password.IsNullOrWhiteSpace())
            {
                return this.Json(HttpStatusCode.BadRequest, "密码不能为空");
            }
            var result = await _userService.CheckUserPasswordAsync(model.UserName, model.Password);
            if (result.Item1 != LoginResults.Success)
            {
                return this.Json(HttpStatusCode.BadRequest, "用户名或密码错误");
            }
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, model.UserName));
            claims.Add(new Claim(ClaimTypes.Sid, result.Item2.Id.ToString()));
            var userIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var userPrincipal = new ClaimsPrincipal(userIdentity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, new AuthenticationProperties
            {
                //将cookie持久化到硬盘，关闭浏览器也不会消失
                ExpiresUtc = DateTimeOffset.Now.AddMinutes(30),
                IsPersistent = true,
                AllowRefresh = true
            });
            if (!model.ReturnUrl.IsNullOrWhiteSpace() && Url.IsLocalUrl(model.ReturnUrl))
            {
                return this.Json(HttpStatusCode.OK, "登录成功", model.ReturnUrl);
            }
            else
            {
                return this.Json(HttpStatusCode.OK, "登录成功", "/Chatroom/DoubleRoom");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
