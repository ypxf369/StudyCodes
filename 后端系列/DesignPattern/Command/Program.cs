using System;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            //初始化Receiver、Invoke和Command
            Receiver r = new Receiver();
            Command c = new ConcreteCommand(r);
            Invoke i = new Invoke(c);

            //院领导发出命令
            i.ExecuteCommand();
            Console.ReadKey();
        }
    }
}
