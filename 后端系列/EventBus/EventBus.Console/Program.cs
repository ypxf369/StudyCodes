using System;
using EventBus.Core;

namespace EventBus.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var sendEmail = new UserAddedSendEmailHandler();
            var sendMessage = new UserAddedSendMessageHandler();
            var sendRedbags = new UserAddedOrderEventHandlerSendRedbags();
            //订阅事件
            EventBus.Core.EventBus.Instance.Subscribe(sendEmail);
            EventBus.Core.EventBus.Instance.Subscribe(sendMessage);
            EventBus.Core.EventBus.Instance.Subscribe<OrderEvent>(sendRedbags);
            EventBus.Core.EventBus.Instance.Subscribe<UserEvent>(sendRedbags);

            //发布事件
            EventBus.Core.EventBus.Instance.Publish(new UserEvent() { Id = Guid.NewGuid() }, Callback);
            EventBus.Core.EventBus.Instance.Publish(new OrderEvent() { Id = Guid.NewGuid() }, Callback);


            System.Console.ReadKey();
        }

        static void Callback(IEvent evt, bool result, Exception ex)
        {
            if (result)
            {
                System.Console.WriteLine("{0}执行完毕！", evt.Id);
            }
            if (ex != null)
            {
                System.Console.WriteLine("执行出错--------------" + "\r\n{0}", ex.Message);
            }
        }
    }
}
