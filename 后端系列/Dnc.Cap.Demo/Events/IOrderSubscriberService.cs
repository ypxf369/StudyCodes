using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public interface IOrderSubscriberService
    {
        Task ConsumeOrderMessageAsync(OrderMessage message);
    }
}
