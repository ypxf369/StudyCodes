using System;
using System.Collections.Generic;
using System.Text;

namespace 装饰第二版
{
    public class KuZi : Person
    {
        public KuZi(string name) : base(name)
        {

        }
        public override void ChuanYi()
        {
            Console.WriteLine(_name + "穿裤子");
        }
    }
}
