using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    /// <summary>
    /// 挂件类，具体装饰类
    /// </summary>
    public class GuaJian : Decorator
    {
        public GuaJian(Phone phone) : base(phone)
        {

        }

        public override void Print()
        {
            base.Print();
            AddGuaJian();
            //添加新的行为
        }

        public void AddGuaJian()
        {
            Console.WriteLine("手机装上挂件了");
        }
    }
}
