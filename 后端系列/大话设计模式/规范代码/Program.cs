using System;

namespace 规范代码
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
                if (operation == "/" && b == "0")
                {
                    Console.WriteLine("被除数不能为0,请重新输入");
                    operation = Console.ReadLine();
                }
                switch (operation)
                {
                    case "+":
                        result = Convert.ToInt32(a) + Convert.ToInt32(b);
                        break;
                    case "-":
                        result = Convert.ToInt32(a) - Convert.ToInt32(b);
                        break;
                    case "*":
                        result = Convert.ToInt32(a) * Convert.ToInt32(b);
                        break;
                    case "/":
                        result = Convert.ToInt32(a) / Convert.ToInt32(b);
                        break;
                }
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
