using System;
using System.Collections.Generic;
using System.Text;

namespace Stragety
{
    /// <summary>
    /// 环境角色
    /// </summary>
    public class StrategyContex
    {
        private readonly IStrategy _strategy;

        public StrategyContex(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        public double Calculate(double revenue)
        {
            return _strategy.CalculateTax(revenue);
        }
    }
}
