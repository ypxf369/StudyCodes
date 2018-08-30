using System;
using System.Collections.Generic;
using System.Text;

namespace 紧耦合VS松耦合
{
    public abstract class Operation
    {
        public double NumberA { get; set; }
        public double NumberB { get; set; }
        public abstract double GetResult();
    }
}
