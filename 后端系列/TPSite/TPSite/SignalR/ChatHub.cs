using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;

namespace TPSite.SignalR
{
    public class ChatHub : Hub
    {
        private static readonly ConcurrentDictionary<string, OnlineUser> OnlineUsers = new ConcurrentDictionary<string, OnlineUser>();
        
        /// <summary>
        /// 上线提醒
        /// </summary>
        /// <returns></returns>
        public override async Task OnConnectedAsync()
        {
            var context = Context.GetHttpContext();
            var currentUserName = context.User.Identities.First(i => i.IsAuthenticated).FindFirst(ClaimTypes.Name).Value;
            var user = new OnlineUser
            {
                ConnectionId = Context.ConnectionId,
                NickName = currentUserName,
                Avatar = ""
            };
            OnlineUsers[currentUserName] = user;
            await base.OnConnectedAsync();
            //await Groups.AddToGroupAsync(Context.ConnectionId, ChatName);
            //await Clients.GroupExcept(ChatName, new[] { Context.ConnectionId }).SendAsync("system", $"用户{client.NickName}加入了群聊");
            await Clients.Client(Context.ConnectionId).SendAsync("System", "链接成功！");
            var babyId = OnlineUsers.FirstOrDefault(i => i.Value.ConnectionId != Context.ConnectionId).Value
                ?.ConnectionId;
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
            var name = OnlineUsers.FirstOrDefault(i => i.Value.ConnectionId == Context.ConnectionId).Value?.NickName;
            bool isRemoved = OnlineUsers.TryRemove(name, out var user);
            //await Groups.RemoveFromGroupAsync(Context.ConnectionId, ChatName);
            if (isRemoved)
            {
                await Clients.Client(OnlineUsers.FirstOrDefault(i => i.Value.ConnectionId != Context.ConnectionId).Value?.ConnectionId).SendAsync("System", $"{name}离线啦！");
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
            var client = OnlineUsers.Where(i => i.Value.ConnectionId != Context.ConnectionId).Select(i => i.Value).FirstOrDefault();
            if (client == null)
            {
                await Clients.Client(Context.ConnectionId).SendAsync("System", "对方已离线，消息将保存！");
            }
            else
            {
                var currentUser = Context.User.Identities.FirstOrDefault(i => i.IsAuthenticated)?.FindFirst(ClaimTypes.Name).Value;
                await Clients.Client(client.ConnectionId).SendAsync("User", currentUser, message);
                //await Clients.GroupExcept(ChatName, new[] { Context.ConnectionId }).SendAsync("receive", new { msg, nickName = client.NickName, avatar = client.Avatar });

            }
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
