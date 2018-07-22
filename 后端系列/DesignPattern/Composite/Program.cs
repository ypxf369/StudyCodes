using System;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            //Line line = new Line("一条线");
            //line.Draw();

            ComplexGraphics complexGraphics1 = new ComplexGraphics("由线和圆组成的复杂图形");
            Line line = new Line("一条线A");
            Circle circle = new Circle("圆A");
            complexGraphics1.Add(line);
            complexGraphics1.Add(circle);
            //complexGraphics1.Draw();
            ComplexGraphics complexGraphics2=new ComplexGraphics("由复杂图形组成的复杂图形");
            complexGraphics2.Add(complexGraphics1);
            complexGraphics2.Draw();
            Console.ReadKey();
        }
    }
}
