using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
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
            if (ModelState.IsValid)
            {
                var result = await _userService.CheckUserPasswordAsync(model.UserName, model.Password);
                if (result != LoginResults.Success)
                {
                    ModelState.AddModelError("Error", result.GetDescription());
                    return View(model);
                }
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, model.UserName));
                var userIdentity = new ClaimsIdentity(claims, "CookieLoginScheme");
                var userPrincipal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync("CookieLoginScheme", userPrincipal, new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMilliseconds(30),
                    IsPersistent = false,
                    AllowRefresh = false
                });
                if (!model.ReturnUrl.IsNullOrWhiteSpace() && Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }
                else
                {
                    return RedirectToAction("DoubleRoom", "Chatroom");
                }
            }
            return View(model);
        }
    }
}
