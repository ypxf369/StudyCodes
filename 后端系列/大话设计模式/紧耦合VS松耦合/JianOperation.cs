using System;
using System.Collections.Generic;
using System.Text;

namespace 紧耦合VS松耦合
{
    public class JianOperation : Operation
    {
        public override double GetResult()
        {
            return NumberA - NumberB;
        }
    }
}
