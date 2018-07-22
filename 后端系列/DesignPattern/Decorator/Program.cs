using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Phone phone = new SamsungPhone();
            //TieMo tieMo=new TieMo(phone);
            //tieMo.Print();

            //GuaJian guaJian=new GuaJian(phone);
            //guaJian.Print();

            TieMo tieMo = new TieMo(phone);
            GuaJian guaJian = new GuaJian(tieMo);
            guaJian.Print();
            Console.ReadKey();
        }
    }
}
