using System;
using System.Collections.Generic;
using System.Text;

namespace 装饰第一版
{
    public class Person
    {
        private readonly string _name;
        public Person(string name)
        {
            _name = name;
        }

        public void GetYiFu()
        {
            Console.WriteLine(_name + "穿衣服");
        }

        public void GetXieZi()
        {
            Console.WriteLine(_name + "穿鞋子");
        }

        public void GetKuZi()
        {
            Console.WriteLine(_name + "穿裤子");
        }
    }
}
