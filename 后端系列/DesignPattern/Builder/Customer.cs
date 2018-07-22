using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    class Customer
    {
        static void Main(string[] args)
        {
            var director = new Director();
            var b1 = new ConcreteBuilderOne();
            var b2 = new ConcreteBuilderTwo();
            director.Construct(b1);
            var computer1 = b1.GetComputer();
            computer1.Show();
        }
    }
}
