using System;
using System.Collections.Generic;
using System.Text;

namespace Stragety
{
    /// <summary>
    /// 具体策略类，企业所得税
    /// </summary>
    public class EnterpriseStrategy : IStrategy
    {
        public double CalculateTax(double revenue)
        {
            return (revenue - 3500) > 0 ? (revenue - 3500) * 0.045 : 0.0;
        }
    }
}
