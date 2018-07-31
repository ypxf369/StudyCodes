using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snak2
{
    /// <summary>
    /// 砖块
    /// </summary>
    public class Brick : Cell
    {
        public Brick(int x, int y, int width, int height) : base(x, y, width, height)
        {

        }
        public override void Draw(Graphics g, Color c)
        {
            SolidBrush brush = new SolidBrush(Color.LightGray);
            g.FillRectangle(brush, X * Width, Y * Height, Width, Height);
            Pen pen = new Pen(c, 1);
            g.DrawRectangle(pen, X * Width + 1, Y * Height + 1, Width - 2, Height - 2);
            g.DrawLine(pen, X * Width + 1, Y * Width + 7, X * Width + Width - 2, Y * Width + 7);
            g.DrawLine(pen, X * Width + 1, Y * Width + 13, X * Width + Width - 2, Y * Width + 13);
            g.DrawLine(pen, X * Width + 10, Y * Width + 1, X * Width + 10, Y * Width + 7);
            g.DrawLine(pen, X * Width + 10, Y * Width + 13, X * Width + 10, Y * Width + 19);
            g.DrawLine(pen, X * Width + 5, Y * Width + 7, X * Width + 5, Y * Width + 13);
            g.DrawLine(pen, X * Width + 15, Y * Width + 7, X * Width + 15, Y * Width + 13);
        }
    }
}
