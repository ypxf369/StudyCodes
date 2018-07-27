
using System;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建聚合（集合）对象
            IAggregate list = new ConcreteAggregate();
            //声明迭代器对象
            ITerator iTerator = list.GetITerator();
            //进行迭代
            while (iTerator.MoveNext())
            {
                var i = iTerator.GetCurrent();
                Console.WriteLine(i);
                iTerator.Next();
            }
            Console.ReadKey();
        }
    }
}
