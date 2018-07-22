using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge
{
    /// <summary>
    /// 具体电视类
    /// </summary>
    public class SanXinTV : TV
    {
        public override void Off()
        {
            Console.WriteLine("关闭三星电视");
        }

        public override void On()
        {
            Console.WriteLine("打开三星电视");
        }

        public override void SwitchChannel()
        {
            Console.WriteLine("三星电视换台");
        }
    }
}
