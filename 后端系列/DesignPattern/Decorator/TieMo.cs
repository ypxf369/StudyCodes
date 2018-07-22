using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    /// <summary>
    /// 贴膜类，具体装饰类
    /// </summary>
    public class TieMo : Decorator
    {
        public TieMo(Phone phone) : base(phone)
        {

        }

        public override void Print()
        {
            base.Print();
            //添加新的行为
            AddTieMo();
        }

        public void AddTieMo()
        {
            Console.WriteLine("手机贴上膜了");
        }
    }
}
