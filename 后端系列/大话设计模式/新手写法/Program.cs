using System;

namespace 新手写法
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double result = 0;
                Console.WriteLine("请输入一个数字");
                string a = Console.ReadLine();
                Console.WriteLine("请输入一个数字");
                string b = Console.ReadLine();
                Console.WriteLine("请输入计算符号(+、-、*、/)：");
                string operation = Console.ReadLine();
                if (operation == "+")
                {
                    result = Convert.ToInt32(a) + Convert.ToInt32(b);
                }
                if (operation == "-")
                {
                    result = Convert.ToInt32(a) - Convert.ToInt32(b);
                }
                if (operation == "*")
                {
                    result = Convert.ToInt32(a) * Convert.ToInt32(b);
                }
                if (operation == "/")
                {
                    result = Convert.ToInt32(a) / Convert.ToInt32(b);
                }
                //if后面不加return，导致无用的多余判断
                Console.WriteLine("计算结果为：" + result);
                Console.WriteLine("请按任意键退出。。。");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("输入有误！！！" + e.Message);
            }
        }
    }
}
