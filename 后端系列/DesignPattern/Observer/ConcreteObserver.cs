using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    /// <summary>
    /// 具体订阅者
    /// </summary>
    public class ConcreteObserver : IObserver
    {
        public string Name { get; set; }
        public ConcreteObserver(string name)
        {
            Name = name;
        }
        public void ReciveAndPrint()
        {
            Console.WriteLine("具体订阅者_" + Name);
        }
    }
}
