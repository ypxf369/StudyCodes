using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuaJi
{
    public class Ball
    {
        /// <summary>
        /// 球的横坐标
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// 球的纵坐标
        /// </summary>
        public double Y { get; set; }
        /// <summary>
        /// 球的贴图
        /// </summary>
        public List<Image> Img { get; set; }
        /// <summary>
        /// 球的半径
        /// </summary>
        public double L { get; set; }
        /// <summary>
        /// 球的当前贴图代数
        /// </summary>
        public double NowImg { get; set; }

        public Ball()
        {
            
        }
        public Ball(double x, double y, List<Image> img, double l, double nowimg)
        {
            X = x;
            Y = y;
            Img = img;
            L = l;
            NowImg = nowimg;
        }
    }
}
