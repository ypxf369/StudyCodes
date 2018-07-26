using System;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建一个代理对象并发出请求
            Person p = new ProxyPerson();
            p.Buy();
            Console.ReadKey();
        }
    }
}
