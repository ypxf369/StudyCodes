using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    /// <summary>
    /// 具体建造者
    /// </summary>
    public class ConcreteBuilderOne : Builder
    {
        private Computer Computer { get; set; }

        public ConcreteBuilderOne()
        {
            Computer = new Computer();
        }
        public override void BuildPartCpu()
        {
            Computer.Add("Cpu1");
        }

        public override void BuildPartMainBoard()
        {
            Computer.Add("MainBoard1");
        }

        public override Computer GetComputer()
        {
            return Computer;
        }
    }
}
