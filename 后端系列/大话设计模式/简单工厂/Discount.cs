using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 简单工厂
{
    /// <summary>
    /// 打折
    /// </summary>
    public class Discount : Charge
    {
        private double _rebate;

        public Discount(double rebate)
        {
            _rebate = rebate;
        }
        public override double Calculate(double meony)
        {
            return meony * _rebate;
        }
    }
}
