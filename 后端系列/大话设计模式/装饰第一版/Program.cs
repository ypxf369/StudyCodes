using System;

namespace 装饰第一版
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person("yepeng");
            person.GetXieZi();
            person.GetKuZi();
            person.GetYiFu();
            Console.ReadKey();
        }
    }
}
