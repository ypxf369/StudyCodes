using System;
using System.Collections.Generic;
using System.Text;

namespace 装饰者
{
    public class Person
    {
        protected string _name;
        public Person() { }
        public Person(string name)
        {
            _name = name;
        }

        public virtual void ChuanYi()
        {
            Console.WriteLine(_name);
        }
    }
}
