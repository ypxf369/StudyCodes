using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPSite.SignalR
{
    public class OnlineUser
    {
        public string ConnectionId { get; set; }
        public Guid UserId { get; set; }
        public string NickName { get; set; }
        public string Avatar { get; set; }
    }
}
