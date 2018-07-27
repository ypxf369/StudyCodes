using System;
using System.Collections.Generic;
using System.Text;

namespace Command
{
    /// <summary>
    /// 抽象命令类
    /// </summary>
    public abstract class Command
    {
        //命令应该知道接受者是谁，所以有Receiver这个成员变量
        protected Receiver _receiver;

        public Command(Receiver receiver)
        {
            _receiver = receiver;
        }

        //命令执行方法
        public abstract void Action();
    }
}
