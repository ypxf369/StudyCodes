using System;
using System.Collections.Generic;
using System.Text;

namespace 紧耦合VS松耦合
{
    public class ChengOperation : Operation
    {
        public override double GetResult()
        {
            return NumberA * NumberB;
        }
    }
}
