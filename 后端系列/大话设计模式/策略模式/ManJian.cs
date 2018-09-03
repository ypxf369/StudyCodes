using System;

namespace 策略模式
{
    public class ManJian : IChargeStrategy
    {
        private double _manCount;
        private double _jianCount;

        public ManJian(double manCount, double jianCount)
        {
            _manCount = manCount;
            _jianCount = jianCount;
        }
        public double Calculate(double meony)
        {
            double total = meony - Math.Floor(meony / _manCount) * _jianCount;
            return total;
        }
    }
}
