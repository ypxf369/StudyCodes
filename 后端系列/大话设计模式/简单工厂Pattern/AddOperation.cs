using System;
using System.Collections.Generic;
using System.Text;

namespace 简单工厂Pattern
{
    public class AddOperation : Operation
    {
        public AddOperation(double a, double b) : base(a, b)
        {

        }
        public override double GetResult()
        {
            return NumberA + NumberB;
        }
    }
}
