using System;
using System.Collections.Generic;
using System.Text;

namespace Command
{
    /// <summary>
    /// 教官，负责执行命令对象执行请求
    /// </summary>
    public class Invoke
    {
        public Command _command;

        public Invoke(Command command)
        {
            _command = command;
        }

        public void ExecuteCommand()
        {
            _command.Action();
        }
    }
}
