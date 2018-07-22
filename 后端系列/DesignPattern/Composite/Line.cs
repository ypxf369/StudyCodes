﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Composite
{
    /// <summary>
    /// 简单对象，树叶构件
    /// </summary>
    public class Line : Graphics
    {
        public Line(string name) : base(name)
        {

        }
        public override void Draw()
        {
            Console.WriteLine("画 " + Name);
        }
    }
}
