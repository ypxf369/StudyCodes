using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge
{
    /// <summary>
    /// 具体遥控器类
    /// </summary>
    public class ConcreteRemoteControl : RemoteControl
    {
        //实现额外的一些功能操作
        public void ReturnLast()
        {
            Console.WriteLine("返回上一台");
        }
    }
}
