using System;
using System.Collections.Generic;
using System.Text;

namespace 装饰第二版
{
    public class XieZi : Person
    {
        public XieZi(string name) : base(name)
        {

        }
        public override void ChuanYi()
        {
            Console.WriteLine(_name + "穿鞋子");
        }
    }
}
