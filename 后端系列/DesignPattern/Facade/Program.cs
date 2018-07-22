using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            Facade facade=new Facade();
            facade.Apply("yepeng1");
            Console.ReadKey();
        }
    }
}
