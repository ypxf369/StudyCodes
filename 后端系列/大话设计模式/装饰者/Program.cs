using System;

namespace 装饰者
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person("yepeng");
            var kuzi = new KuZi();
            kuzi.DaBan(person);
            var xiezi = new XieZi();
            xiezi.DaBan(kuzi);
            xiezi.ChuanYi();
            Console.ReadKey();
        }
    }
}
