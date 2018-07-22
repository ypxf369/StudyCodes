using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype
{
    /// <summary>
    /// 抽象原型
    /// </summary>
    public abstract class Prototype
    {
        public string Id { get; set; }

        public Prototype(string id)
        {
            Id = id;
        }

        //克隆方法
        public abstract Prototype Clone();
    }
}
