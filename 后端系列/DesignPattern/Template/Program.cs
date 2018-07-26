using System;

namespace Template
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建一个茄子实例并调用模板方法
            QieZi qiezi = new QieZi();
            qiezi.CookVegetable();
            Console.ReadKey();
        }
    }
}
