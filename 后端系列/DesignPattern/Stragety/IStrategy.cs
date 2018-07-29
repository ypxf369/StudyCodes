using System;
using System.Collections.Generic;
using System.Text;

namespace Stragety
{
    /// <summary>
    /// 抽象策略角色
    /// </summary>
    public interface IStrategy
    {
        /// <summary>
        /// 所得税计算方法
        /// </summary>
        /// <param name="revenue"></param>
        double CalculateTax(double revenue);
    }
}
