using System;
using System.Collections.Generic;
using System.Text;
using EventBus.Core;

namespace EventBus.Console
{
    /// <summary>
    /// 发送邮件
    /// </summary>
    public class UserAddedSendEmailHandler : IEventHandler<UserEvent>
    {
        public void Handle(UserEvent evt)
        {
            System.Console.WriteLine("{0}的邮件已发送！", evt.Id);
        }
    }

    /// <summary>
    /// 发送短信
    /// </summary>
    public class UserAddedSendMessageHandler : IEventHandler<UserEvent>
    {
        public void Handle(UserEvent evt)
        {
            System.Console.WriteLine("{0}的短信已发送！", evt.Id);
        }
    }

    /// <summary>
    /// 注册下单发送红包
    /// </summary>
    public class UserAddedOrderEventHandlerSendRedbags : IEventHandler<UserEvent>, IEventHandler<OrderEvent>
    {
        public void Handle(UserEvent evt)
        {
            System.Console.WriteLine("{0}的注册红包已发送！", evt.Id);
        }

        public void Handle(OrderEvent evt)
        {
            System.Console.WriteLine("{0}的下单红包已发送！", evt.Id);
        }
    }
}
