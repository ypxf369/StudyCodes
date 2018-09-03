using System;
using System.Collections.Generic;
using System.Text;

namespace 装饰者
{
    public class KuZi:FuZhuangDecorator
    {
        public override void ChuanYi()
        {
            Console.WriteLine("穿裤子");
            base.ChuanYi();
        }
    }
}
