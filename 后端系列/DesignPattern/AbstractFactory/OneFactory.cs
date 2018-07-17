using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory
{
    /// <summary>
    /// 工厂1
    /// </summary>
    public class OneFactory : AbstractFactory
    {
        public override CustomerOne CreateCustomerOne()
        {
            return new CustomerOneA();
        }

        public override CustomerTwo CreateCustomerTwo()
        {
            return new CustomerTwoA();
        }
    }
}
