using System;
using System.Collections.Generic;
using System.Text;

namespace 简单工厂Pattern
{
    public class ChengOperation : Operation
    {
        public ChengOperation(double a, double b) : base(a, b)
        {
            
        }
        public override double GetResult()
        {
            return NumberA * NumberB;
        }
    }
}
