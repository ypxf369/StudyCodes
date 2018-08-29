using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo3Subscribe.Service
{
    public interface ISubscribe
    {
        Task SubscribeMsgAsync(string msg);
    }
}
