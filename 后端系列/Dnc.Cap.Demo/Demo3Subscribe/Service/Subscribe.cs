using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.CAP;

namespace Demo3Subscribe.Service
{
    public class Subscribe : ISubscribe, ICapSubscribe
    {
        [CapSubscribe("cap.publish.msg.test")]
        public async Task SubscribeMsgAsync(string msg)
        {
            await Console.Out.WriteLineAsync("收到消息了——————" + msg);
        }
    }
}
