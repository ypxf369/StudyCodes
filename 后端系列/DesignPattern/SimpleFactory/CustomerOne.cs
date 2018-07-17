using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFactory
{
    public class CustomerOne : BaseCustomer
    {
        public override void DoSomething()
        {
            Console.WriteLine(nameof(CustomerOne));
        }
    }
}
