using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy
{
    /// <summary>
    /// 抽象代理类，声明了真实主题和代理主题之间的公共接口
    /// </summary>
    public abstract class Person
    {
        public abstract void Buy();
    }
}
