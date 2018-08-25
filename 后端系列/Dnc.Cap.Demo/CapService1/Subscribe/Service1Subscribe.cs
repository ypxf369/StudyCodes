using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using DotNetCore.CAP;
using Newtonsoft.Json;

namespace CapService1.Subscribe
{
    public class Service1Subscribe : IService1Subscribe, ICapSubscribe
    {
        [CapSubscribe("service1.publish.test.trans")]
        public async Task<Message> DoWorkAsync(Message message)
        {
            if (message == null)
            {
                await Console.Out.WriteLineAsync("订阅消息为空");
            }
            await Console.Out.WriteLineAsync("接收到消息：————" + JsonConvert.SerializeObject(message));
            //定义回调方法的返回参数
            return new Message() { Title = "回调方法返回", Content = "我是原始方法返回给回调方法的参数" };
            //throw new Exception("接收到消息抛出异常");//抛出异常后，消息将打上Fail标签，进行重试
        }

        //回调方法：原理：自动发布到MQ中，然后通过name来订阅
        [CapSubscribe("CallBackMethodAsync")]
        public async Task CallBackMethodAsync(object obj)
        {
            await Console.Out.WriteLineAsync("——————————调用了回调方法————————————" + JsonConvert.SerializeObject(obj));
        }
    }
}
