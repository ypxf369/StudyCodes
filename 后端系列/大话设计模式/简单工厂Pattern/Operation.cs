using System;
using System.Collections.Generic;
using System.Text;

namespace 简单工厂Pattern
{
    public abstract class Operation
    {
        public double NumberA { get; set; }
        public double NumberB { get; set; }
        protected Operation(double a, double b)
        {
            NumberA = a;
            NumberB = b;
        }

        public abstract double GetResult();
    }
}
