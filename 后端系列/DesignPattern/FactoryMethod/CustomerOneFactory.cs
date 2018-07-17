using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod
{
    /// <summary>
    /// 具体工厂类
    /// </summary>
    public class CustomerOneFactory : Factory
    {
        public override BaseCustomer Creator()
        {
            return new CustomerOne();
        }
    }
}
