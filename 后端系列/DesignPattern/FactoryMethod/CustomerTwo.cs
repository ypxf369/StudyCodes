using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod
{
    public class CustomerTwo : BaseCustomer
    {
        public override void DoSomething()
        {
            Console.WriteLine(nameof(CustomerTwo));
        }
    }
}
