using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy
{
    /// <summary>
    /// 代理主题角色
    /// </summary>
    public class ProxyPerson : Person
    {
        private RealPerson realPerson;
        public override void Buy()
        {
            //通过代理类访问真实实体对象的方法
            if (realPerson == null)
            {
                realPerson = new RealPerson();
            }

            PreBuy();
            //调用真实主题方法
            realPerson.Buy();
            EndBuy();
        }

        //代理角色执行的其他一些操作
        public void PreBuy()
        {
            Console.WriteLine("购买之前所做的一些操作");
        }

        public void EndBuy()
        {
            Console.WriteLine("购买之后做的一些操作");
        }
    }
}
