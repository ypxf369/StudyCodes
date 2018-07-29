using System;

namespace Stragety
{
    class Program
    {
        static void Main(string[] args)
        {
            //个人所得税
            PersonStrategy ps = new PersonStrategy();
            StrategyContex contex = new StrategyContex(ps);
            Console.WriteLine("收入5000的个人所得税{0}", contex.Calculate(5000));
            //企业所得税
            EnterpriseStrategy es = new EnterpriseStrategy();
            contex = new StrategyContex(es);
            Console.WriteLine("收入80000的企业所得税{0}", contex.Calculate(80000));
            Console.ReadKey();
        }
    }
}
