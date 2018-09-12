using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TPSite.Extensions;
using TPSite.IService;
using TPSite.Tools.Extensions;

namespace TPSite.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class ChatroomController : Controller
    {
        private readonly IMessageRecordService _messageRecordService;
        private readonly IUserService _userService;

        public ChatroomController(IMessageRecordService messageRecordService, IUserService userService)
        {
            _messageRecordService = messageRecordService;
            _userService = userService;
        }
        public IActionResult DoubleRoom()
        {
            //todo:登录成功的时候检查有没有离线消息，如果有则显示
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetHistoryMessage(int pageIndex = 1, int pageSize = 20)
        {
            Guid currentUserId = Guid.Parse(HttpContext.User.Identities.First(i => i.IsAuthenticated).FindFirst(ClaimTypes.Sid).Value);
            var result = await _messageRecordService.GetHistoryMessagePagedAsync(currentUserId, pageSize, pageIndex);
            if (result.Any())
            {
                return this.Json(HttpStatusCode.OK, "成功", new {result, currentUserId});
                //todo:将查询出来的未读的消息改为已读
            }
            else
            {
                return this.Json(HttpStatusCode.NoContent, "未找到记录");
            }
        }
    }
}