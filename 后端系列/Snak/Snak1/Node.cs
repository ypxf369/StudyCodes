using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snak1
{
    /// <summary>
    /// 节点
    /// </summary>
    public class Node
    {
        /// <summary>
        /// 蛇的颜色
        /// </summary>
        public Color SnakColor { get; set; } = Color.Chocolate;

        /// <summary>
        /// 背景色
        /// </summary>
        public Color BgColor { get; set; } = Color.FromArgb(224, 224, 224);

        /// <summary>
        /// 食物的颜色
        /// </summary>
        public Color FoodColor { get; set; } = Color.Green;

        /// <summary>
        /// 障碍物的颜色
        /// </summary>
        public Color HinderColor { get; set; } = Color.Black;

        /// <summary>
        /// 当前颜色
        /// </summary>
        public Color CurrentColor { get; set; }
        /// <summary>
        /// 相对横坐标
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// 相对纵坐标
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// 节点边长
        /// </summary>
        public int Width { get; set; } = 10;

        /// <summary>
        /// 是否为食物
        /// </summary>
        public bool IsFood { get; set; }
        /// <summary>
        /// 是否可以通过
        /// </summary>
        public bool IsPass { get; set; }

        public Node()
        {
            CurrentColor = BgColor;
        }

        public Node(int x, int y, int width, bool isFood, bool isPass) : this(x, y, width)
        {
            CurrentColor = BgColor;
            IsFood = isFood;
            IsPass = isPass;
        }

        public Node(int x, int y, int width) : this(x, y)
        {
            Width = width;
        }

        public Node(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// 设置食物参数
        /// </summary>
        /// <param name="isFood"></param>
        public void SetFood(bool isFood)
        {
            IsFood = isFood;
            CurrentColor = isFood ? FoodColor : BgColor;
        }

        /// <summary>
        /// 设置障碍物参数
        /// </summary>
        /// <param name="isHinder"></param>
        public void SetHinder(bool isHinder)
        {
            IsPass = !isHinder;
            CurrentColor = isHinder ? HinderColor : BgColor;
        }

        /// <summary>
        /// 设置蛇的颜色
        /// </summary>
        /// <param name="isSnake"></param>
        public void SetSnake(bool isSnake)
        {
            IsPass = !isSnake;
            CurrentColor = isSnake ? SnakColor : BgColor;
        }
    }
}
