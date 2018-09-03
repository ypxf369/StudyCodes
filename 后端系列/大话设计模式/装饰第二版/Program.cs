using System;

namespace 装饰第二版
{
    class Program
    {
        static void Main(string[] args)
        {
            //应该定义服装抽象类，具体的衣服、裤子继承服装抽象类
            var xiezi = new XieZi("yepeng");
            var kuzi = new KuZi("yepeng");
            var yifu = new YiFu("yepeng");
            xiezi.ChuanYi();
            kuzi.ChuanYi();
            yifu.ChuanYi();
            Console.ReadKey();
        }
    }
}
