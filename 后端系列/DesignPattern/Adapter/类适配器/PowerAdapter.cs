using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter.类适配器
{
    /// <summary>
    /// 适配器类，
    /// 适配器类提供了三孔插头的行为，但本质上还是两孔插头（调用两孔插头的方法）
    /// </summary>
    public class PowerAdapter : TwoHole, IThreeHole
    {
        public void Request()
        {
            this.ConcreteRequest();
        }
    }
}
