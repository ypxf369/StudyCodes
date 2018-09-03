using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 简单工厂
{
    /// <summary>
    /// 正常收费
    /// </summary>
    public class Normal : Charge
    {
        public override double Calculate(double meony)
        {
            return meony;
        }
    }
}
