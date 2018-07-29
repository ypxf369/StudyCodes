using System;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Subject sub = new ConcreteSubject();
            //添加订阅者
            sub.Add(new ConcreteObserver("tom"));
            sub.Add(new ConcreteObserver("lucy"));
            sub.Update();
            Console.ReadKey();
        }
    }
}
