using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod
{
    /// <summary>
    /// 抽象工厂类
    /// </summary>
    public abstract class Factory
    {
        /// <summary>
        /// 具体类型的创建者
        /// </summary>
        /// <returns></returns>
        public abstract BaseCustomer Creator();
    }
}
