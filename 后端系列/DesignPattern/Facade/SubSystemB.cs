using System;
using System.Collections.Generic;
using System.Text;

namespace Facade
{
    /// <summary>
    /// 子系统B
    /// </summary>
    public class SubSystemB
    {
        public bool Notice(string name)
        {
            Console.WriteLine(name + "成功");
            return true;
        }
    }
}
