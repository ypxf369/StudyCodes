using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 简单工厂
{
    public class ManJian : Charge
    {
        private double _manCount;
        private double _jianCount;

        public ManJian(double manCount, double jianCount)
        {
            _manCount = manCount;
            _jianCount = jianCount;
        }
        public override double Calculate(double meony)
        {
            double total = meony - Math.Floor(meony / _manCount) * _jianCount;
            return total;
        }
    }
}
