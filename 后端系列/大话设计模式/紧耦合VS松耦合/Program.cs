using System;

namespace 紧耦合VS松耦合
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
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
                double result = 0;
                if (operation == "+")
                {
                    var op = new AddOperation
                    {
                        NumberA = Convert.ToInt32(a),
                        NumberB = Convert.ToInt32(b)
                    };
                    result = op.GetResult();
                }
                else if (operation == "-")
                {
                    var op = new JianOperation
                    {
                        NumberA = Convert.ToInt32(a),
                        NumberB = Convert.ToInt32(b)
                    };
                    result = op.GetResult();
                }
                else if (operation == "*")
                {
                    var op = new ChengOperation
                    {
                        NumberA = Convert.ToInt32(a),
                        NumberB = Convert.ToInt32(b)
                    };
                    result = op.GetResult();
                }
                else if (operation == "/")
                {
                    var op = new AddOperation
                    {
                        NumberA = Convert.ToInt32(a),
                        NumberB = Convert.ToInt32(b)
                    };
                    result = op.GetResult();
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
