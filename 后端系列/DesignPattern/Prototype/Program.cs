using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Prototype prototype = new ConcretePrototype("yepeng");

            Prototype clone = prototype.Clone() as ConcretePrototype;

            Prototype clone2 = prototype.Clone() as ConcretePrototype;

            Console.WriteLine($"clone1:{clone.Id},clone2:{clone2.Id}");
            Console.ReadKey();
        }
    }
}
