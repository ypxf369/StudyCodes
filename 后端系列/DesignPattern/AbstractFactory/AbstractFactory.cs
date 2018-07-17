using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory
{
    /// <summary>
    /// 抽象工厂类，提供创建一系列不同产品的接口
    /// </summary>
    public abstract class AbstractFactory
    {
        public abstract CustomerOne CreateCustomerOne();
        public abstract CustomerTwo CreateCustomerTwo();
    }
}
