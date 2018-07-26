using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy
{
    /// <summary>
    /// 真实主题角色
    /// </summary>
    public class RealPerson : Person
    {
        public override void Buy()
        {
            Console.WriteLine("帮我买一个苹果手机和电脑");
        }
    }
}
