using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter.类适配器
{
    /// <summary>
    /// 两孔插头，源角色
    /// </summary>
    public abstract class TwoHole
    {
        public void ConcreteRequest()
        {
            Console.WriteLine("我是两孔插头");
        }
    }
}
