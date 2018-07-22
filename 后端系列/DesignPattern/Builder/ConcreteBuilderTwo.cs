using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    /// <summary>
    /// 具体建造者
    /// </summary>
    public class ConcreteBuilderTwo : Builder
    {
        private Computer Computer { get; set; }

        public ConcreteBuilderTwo()
        {
            Computer = new Computer();
        }
        public override void BuildPartCpu()
        {
            Computer.Add("Cpu2");
        }

        public override void BuildPartMainBoard()
        {
            Computer.Add("MainBoard2");
        }

        public override Computer GetComputer()
        {
            return Computer;
        }
    }
}
