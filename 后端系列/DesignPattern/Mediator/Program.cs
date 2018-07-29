using System;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            PartnerA a = new PartnerA();
            a.MoneyCount = 20;
            PartnerB b = new PartnerB();
            b.MoneyCount = 30;
            Mediator mediator = new ConcreteMediator(a, b);
            //A赢了
            Console.WriteLine("A赢了");
            a.ChangeCount(5, mediator);
            Console.WriteLine("A现在的钱是：{0}", a.MoneyCount);
            Console.WriteLine("B现在的钱是：{0}", b.MoneyCount);

            //B赢了
            Console.WriteLine("B赢了");
            b.ChangeCount(10, mediator);
            Console.WriteLine("A现在的钱是：{0}", a.MoneyCount);
            Console.WriteLine("B现在的钱是：{0}", b.MoneyCount);
            Console.ReadKey();
        }
    }
}
