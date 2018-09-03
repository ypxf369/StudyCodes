using System;
using System.Collections.Generic;
using System.Text;

namespace 装饰者
{
    public class XieZi : FuZhuangDecorator
    {

        public override void ChuanYi()
        {
            Console.WriteLine("穿鞋子");
            base.ChuanYi();
        }
    }
}
