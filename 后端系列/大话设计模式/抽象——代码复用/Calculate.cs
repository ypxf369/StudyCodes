using System;
using System.Collections.Generic;
using System.Text;

namespace 抽象__代码复用
{
    /// <summary>
    /// 计算类
    /// </summary>
    public class Calculate
    {
        public static double Calc(double a, double b, string operation)
        {
            double result = 0;
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
            return result;
        }
    }
}
