using System;
using System.Collections.Generic;
using System.Text;

namespace Flyweight
{
    /// <summary>
    /// 具体享元类，这样我们不把每个元素设计成一个单独的类了，而是把共享的字母作为享元对象的内部状态
    /// </summary>
    public class ConcreteFlyweight : Flyweight
    {
        //内部状态
        private string intrinsicstate;

        public ConcreteFlyweight(string innerState)
        {
            this.intrinsicstate = innerState;
        }

        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine("具体实现类：intrinsicstate {0},extrinsicstate {1}", intrinsicstate, extrinsicstate);
        }
    }
}
