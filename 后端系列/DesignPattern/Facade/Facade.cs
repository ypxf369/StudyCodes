using System;
using System.Collections.Generic;
using System.Text;

namespace Facade
{
    /// <summary>
    /// 外观类，提供子系统对外暴露的统一接口
    /// </summary>
    public class Facade
    {
        private readonly SubSystemA subSystemA;
        private readonly SubSystemB subSystemB;

        public Facade()
        {
            subSystemA = new SubSystemA();
            subSystemB = new SubSystemB();
        }

        public bool Apply(string name)
        {
            if (subSystemA.CheckIsExist(name))
            {
                return false;
            }
            else
            {
                return subSystemB.Notice(name);
            }
        }
    }
}
