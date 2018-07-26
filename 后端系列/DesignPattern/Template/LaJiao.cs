using System;
using System.Collections.Generic;
using System.Text;

namespace Template
{
    /// <summary>
    /// 具体模板角色
    /// </summary>
    public class LaJiao : Vegetabel
    {
        public override void AddVegetabel()
        {
            Console.WriteLine("将切好的辣椒放入锅中。。。");
        }
    }
}
