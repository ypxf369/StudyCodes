using System;
using System.Collections.Generic;
using System.Text;

namespace 装饰第二版
{
    public abstract class Person
    {
        protected readonly string _name;

        protected Person(string name)
        {
            _name = name;
        }
        public abstract void ChuanYi();
    }
}
