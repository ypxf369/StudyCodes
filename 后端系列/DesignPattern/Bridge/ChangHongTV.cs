using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge
{
    /// <summary>
    /// 具体电视类
    /// </summary>
    public class ChangHongTV : TV
    {
        public override void Off()
        {
            Console.WriteLine("关闭长虹电视");
        }

        public override void On()
        {
            Console.WriteLine("打开长虹电视");
        }

        public override void SwitchChannel()
        {
            Console.WriteLine("长虹电视换台");
        }
    }
}
