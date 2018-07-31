using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snak2
{
    /// <summary>
    /// 食物
    /// </summary>
    public class Food : Cell
    {
        public Food(int x, int y, int width, int height) : base(x, y, width, height)
        {
            
        }
        public override void Draw(Graphics g, Color c)
        {
            Pen pen = new Pen(c, 1);
            SolidBrush brush = new SolidBrush(c);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillEllipse(brush, X * Width + 3, Y * Height + 5, Width - 6, Height - 8);
            g.DrawLine(pen, X * Width + 13, Y * Height + 2, X * Width + 10, Y * Height + 7);
            g.DrawLine(pen, X * Width + 11, Y * Height + 2, X * Width + 15, Y * Height + 3);

        }
    }
}
