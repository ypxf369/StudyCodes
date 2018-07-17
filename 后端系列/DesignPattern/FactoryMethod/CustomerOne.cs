using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod
{
    public class CustomerOne : BaseCustomer
    {
        public override void DoSomething()
        {
            Console.WriteLine(nameof(CustomerOne));
        }
    }
}
