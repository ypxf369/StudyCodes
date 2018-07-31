using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snak2
{
    public class Cell
    {
        /// <summary>
        /// 单元格左上角X坐标
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// 单元格左上角Y坐标
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// 单元格宽度
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 单元格高度
        /// </summary>
        public int Height { get; set; }

        public Cell()
        {
            
        }

        public Cell(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// 画单元格
        /// </summary>
        /// <param name="g"></param>
        /// <param name="c"></param>
        public virtual void Draw(Graphics g, Color c)
        {
            Pen pen = new Pen(c, 2);
            g.DrawRectangle(pen, X * Width + 2, Y * Height + 2, Width - 3, Height - 3);
            g.DrawRectangle(pen, X * Width + 6, Y * Height + 6, Width - 11, Height - 11);
        }

        /// <summary>
        /// 清除单元格
        /// </summary>
        /// <param name="g"></param>
        /// <param name="c"></param>
        public void Clear(Graphics g, Color c)
        {
            SolidBrush brush = new SolidBrush(c);
            g.FillRectangle(brush, X * Width + 1, Y * Height + 1, Width - 1, Height - 1);
        }
    }
}
