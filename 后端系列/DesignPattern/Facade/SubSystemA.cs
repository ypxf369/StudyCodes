using System;
using System.Collections.Generic;
using System.Text;

namespace Facade
{
    /// <summary>
    /// 子系统A
    /// </summary>
    public class SubSystemA
    {
        public bool CheckIsExist(string name)
        {
            if (name != null && name.Equals("yepeng"))
            {
                return true;
            }
            return false;
        }
    }
}
