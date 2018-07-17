using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory
{
    /// <summary>
    /// 工厂2
    /// </summary>
    public class TwoFactory : AbstractFactory
    {
        public override CustomerOne CreateCustomerOne()
        {
            return new CustomerOneB();
        }

        public override CustomerTwo CreateCustomerTwo()
        {
            return new CustomerTwoB();
        }
    }
}
