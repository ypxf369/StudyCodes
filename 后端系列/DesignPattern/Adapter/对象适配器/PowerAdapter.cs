using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter.对象适配器
{
    /// <summary>
    /// 适配器类
    /// </summary>
    public class PowerAdapter : IThreeHole
    {
        private TwoHole TwoHole { get; set; }

        public PowerAdapter()
        {
            TwoHole = new TwoHole();
        }
        public void Request()
        {
            TwoHole.ConcreteRequest();
        }
    }
}
