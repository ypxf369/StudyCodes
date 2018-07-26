using System;
using System.Collections.Generic;
using System.Text;

namespace Flyweight
{
    /// <summary>
    /// 抽象享元类
    /// </summary>
    public abstract class Flyweight
    {
        public abstract void Operation(int extrinsicstate);
    }
}
