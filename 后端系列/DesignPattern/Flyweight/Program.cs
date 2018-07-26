using System;

namespace Flyweight
{
    class Program
    {
        static void Main(string[] args)
        {
            //定义外部状态，
            int externalstate = 10;

            //初始化享元工厂
            FlyweightFactory factory = new FlyweightFactory();

            //判断是否已经创建了字母A，如果已经创建就直接使用床架你的对象A
            Flyweight fa = factory.GetFlyweight("A");
            if (fa != null)
            {
                //把外部状态作为享元对象的方法调用参数
                fa.Operation(externalstate);
            }

            //判断是否已经创建了字母D
            Flyweight fd = factory.GetFlyweight("D");
            if (fd != null)
            {
                fd.Operation(externalstate);
            }
            else
            {
                Console.WriteLine("驻留池中不存在对象D");
                //这时候就需要创建一个对象并放入驻留池中
                ConcreteFlyweight d = new ConcreteFlyweight("D");
                factory.flyweights.Add("D", d);
            }
            Console.ReadKey();
        }
    }
}
