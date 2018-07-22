using System;
using System.Collections.Generic;
using System.Text;

namespace Composite
{
    /// <summary>
    /// 复杂画图类，树枝构件
    /// </summary>
    public class ComplexGraphics : Graphics
    {
        private readonly IList<Graphics> graphicses = new List<Graphics>();
        public ComplexGraphics(string name) : base(name)
        {

        }
        public override void Draw()
        {
            foreach (var g in graphicses)
            {
                g.Draw();
            }
        }

        public void Add(Graphics graphics)
        {
            graphicses.Add(graphics);
        }

        public void Remove(Graphics graphics)
        {
            graphicses.Remove(graphics);
        }
    }
}
