using System;

namespace ChainOfResponsibity
{
    class Program
    {
        static void Main(string[] args)
        {
            PurchaseRequest requestA = new PurchaseRequest("电脑", 20000);
            PurchaseRequest requestB = new PurchaseRequest("交换机", 40000);
            PurchaseRequest requestC = new PurchaseRequest("大型打印机", 200000);
            Handler handlerA = new ConcreteHandlerA("yesir_1");
            Handler handlerB = new ConcreteHandlerB("yesir_2");
            Handler handlerC = new ConcreteHandlerC("yesir_3");
            //链接责任链
            handlerA.NextHandler = handlerB;
            handlerB.NextHandler = handlerC;

            handlerA.ProcessRequest(requestC);
            Console.ReadKey();
        }
    }
}
