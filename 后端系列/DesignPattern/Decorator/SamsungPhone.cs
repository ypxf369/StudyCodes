using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    /// <summary>
    /// 具体装饰类，具体组件,覆盖父类的方法
    /// </summary>
    public class SamsungPhone : Phone
    {
        public override void Print()
        {
            Console.WriteLine("我是三星手机");
        }
    }
}
