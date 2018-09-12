using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using TPSite.Dto;
using TPSite.IService;

namespace TPSite.SignalR
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class ChatHub : Hub
    {
        private static readonly ConcurrentDictionary<Guid, OnlineUser> OnlineUsers = new ConcurrentDictionary<Guid, OnlineUser>();

        private readonly IMessageRecordService _messageRecordService;
        private readonly IUserService _userService;

        public ChatHub(IMessageRecordService messageRecordService, IUserService userService)
        {
            _messageRecordService = messageRecordService;
            _userService = userService;
        }

        /// <summary>
        /// 上线提醒
        /// </summary>
        /// <returns></returns>
        public override async Task OnConnectedAsync()
        {
            var claimIdentity = Context.User.Identities.First(i => i.IsAuthenticated);
            var currentUserName = claimIdentity.FindFirst(ClaimTypes.Name).Value;
            var currentUserId = Guid.Parse(claimIdentity.FindFirst(ClaimTypes.Sid).Value);
            var user = new OnlineUser
            {
                ConnectionId = Context.ConnectionId,
                UserId = currentUserId,
                NickName = currentUserName,
                Avatar = ""
            };
            OnlineUsers[currentUserId] = user;
            await base.OnConnectedAsync();
            //await Groups.AddToGroupAsync(Context.ConnectionId, ChatName);
            //await Clients.GroupExcept(ChatName, new[] { Context.ConnectionId }).SendAsync("system", $"用户{client.NickName}加入了群聊");
            await Clients.Client(Context.ConnectionId).SendAsync("System", "链接成功！");
            var babyId = OnlineUsers.FirstOrDefault(i => i.Key != currentUserId).Value?.ConnectionId;
            if (!string.IsNullOrWhiteSpace(babyId))
            {
                await Clients.Client(babyId).SendAsync("System", "你的宝宝上线啦！！！");
            }
        }

        /// <summary>
        /// 断线做离线处理
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
            var userId = OnlineUsers.FirstOrDefault(i => i.Value.ConnectionId == Context.ConnectionId).Value?.UserId;
            bool isRemoved = OnlineUsers.TryRemove(userId.GetValueOrDefault(), out var user);
            //await Groups.RemoveFromGroupAsync(Context.ConnectionId, ChatName);
            if (isRemoved)
            {
                await Clients.Client(OnlineUsers.FirstOrDefault(i => i.Value.ConnectionId != Context.ConnectionId).Value?.ConnectionId).SendAsync("System", $"{user.NickName}离线啦！");
            }
        }

        /// <summary>
        /// 给指定用户发送消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendUserMessage(string message)
        {
            //var client = _onlineUsers.Where(x => x.Key == Context.ConnectionId).Select(x => x.Value).FirstOrDefault();
            var claimIdentity = Context.User.Identities.First(i => i.IsAuthenticated);
            var currentUserId = Guid.Parse(claimIdentity.FindFirst(ClaimTypes.Sid).Value);
            Guid toUserId=Guid.Empty;
            var msgRcdDto = new MessageRecordDto
            {
                FromUserId = currentUserId,
                Message = message
            };
            var client = OnlineUsers.Where(i => i.Key != currentUserId).Select(i => i.Value).FirstOrDefault();
            //var client = OnlineUsers.Where(i => i.Value.ConnectionId != Context.ConnectionId).Select(i => i.Value).FirstOrDefault();
            if (client == null)
            {
                await Clients.Client(Context.ConnectionId).SendAsync("System", "对方已离线，消息将保存！");
                msgRcdDto.IsRead = false;
                var users = await _userService.GetAllListAsync(i => i.RealName == "yepeng" || i.RealName == "zhangting");
                if (users.Any())
                {
                    //获取对方的用户信息
                    var babyUser = users.FirstOrDefault(i => i.Id != currentUserId);
                    if (babyUser != null)
                    {
                        toUserId = babyUser.Id;
                    }
                }
            }
            else
            {
                var currentUserName = claimIdentity.FindFirst(ClaimTypes.Name).Value;
                await Clients.Client(client.ConnectionId).SendAsync("User", currentUserName, message);
                msgRcdDto.IsRead = true;
                toUserId = OnlineUsers.First(i => i.Key != currentUserId).Value.UserId;
            }
            //await Clients.GroupExcept(ChatName, new[] { Context.ConnectionId }).SendAsync("receive", new { msg, nickName = client.NickName, avatar = client.Avatar });
            //保存消息记录
            msgRcdDto.ToUserId = toUserId;
            await _messageRecordService.InsertAsync(msgRcdDto);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
