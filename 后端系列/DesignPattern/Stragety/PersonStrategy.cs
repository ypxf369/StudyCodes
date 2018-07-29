using System;
using System.Collections.Generic;
using System.Text;

namespace Stragety
{
    /// <summary>
    /// 具体策略类，个人所得税
    /// </summary>
    public class PersonStrategy : IStrategy
    {
        public double CalculateTax(double revenue)
        {
            return revenue * 0.12;
        }
    }
}
