using System;
using System.Collections.Generic;
using System.Text;

namespace 简单工厂Pattern
{
    public class JianOperation : Operation
    {
        public JianOperation(double a, double b) : base(a, b)
        {
            
        }
        public override double GetResult()
        {
            return NumberA - NumberB;
        }
    }
}
