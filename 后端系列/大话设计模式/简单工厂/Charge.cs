using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 简单工厂
{
    /// <summary>
    /// 收费抽象类
    /// </summary>
    public abstract class Charge
    {
        public abstract double Calculate(double meony);

    }
}
