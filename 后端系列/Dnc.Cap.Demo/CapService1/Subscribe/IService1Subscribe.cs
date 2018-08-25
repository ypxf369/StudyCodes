using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;

namespace CapService1.Subscribe
{
    public interface IService1Subscribe
    {
        Task<Message> DoWorkAsync(Message message);
        Task CallBackMethodAsync(object obj);
    }
}
