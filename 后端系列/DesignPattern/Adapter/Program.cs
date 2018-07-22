using System;
using Adapter.类适配器;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            //类适配器
            //IThreeHole threeHole = new PowerAdapter();
            //threeHole.Request();

            //对象适配器
            IThreeHole threeHole = new PowerAdapter();
            threeHole.Request();
            Console.ReadKey();
        }
    }
}
