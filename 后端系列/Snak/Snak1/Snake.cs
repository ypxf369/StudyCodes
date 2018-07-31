using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snak1
{
    /// <summary>
    /// 蛇
    /// </summary>
    public class Snake
    {
        private List<Node> snakeList = new List<Node>();
        private int maxCount = 15;
        private int minCount = 5;
        private Control MapPanel;
        private Graphics g;

        public Snake(int maxLength, int minLength, Control c)
        {
            maxCount = maxLength;
            minCount = minLength;
            MapPanel = c;
            g = c.CreateGraphics();
        }

        /// <summary>
        /// 初始化蛇
        /// </summary>
        public void InitializeSnake()
        {
            SolidBrush brush = null;
            RectangleF[] rects = new RectangleF[minCount];
            for (int i = 0; i < minCount; i++)
            {
                var indexnode = new Node(i + 1, 1);
                indexnode.SetSnake(true);//设置蛇的颜色
                snakeList.Insert(0, indexnode);
                if (brush == null)
                {
                    brush = new SolidBrush(indexnode.SnakColor);
                }
                rects[i] = new RectangleF(indexnode.X * indexnode.Width, indexnode.Y * indexnode.Width, indexnode.Width, indexnode.Width);
            }
            g.FillRectangles(brush, rects);
        }

        /// <summary>
        /// 插入一个节点
        /// </summary>
        /// <param name="node"></param>
        public void InsertNode(Node node)
        {
            snakeList.Insert(0, node);
            node.SetSnake(true);
            SolidBrush brush = new SolidBrush(node.SnakColor);
            RectangleF rect = new RectangleF(node.X * node.Width, node.Y * node.Width, node.Width, node.Width);
            g.FillRectangle(brush, rect);
        }

        /// <summary>
        /// 移除尾巴
        /// </summary>
        public void RemoveNode()
        {
            var node = snakeList[snakeList.Count - 1];
            snakeList.Remove(node);
            node.SetSnake(false);
            SolidBrush brush = new SolidBrush(node.BgColor);
            RectangleF rect = new RectangleF(node.X * node.Width, node.Y * node.Width, node.Width, node.Width);
            g.FillRectangle(brush, rect);
        }

        /// <summary>
        /// 获取蛇头
        /// </summary>
        /// <returns></returns>
        public Node GetSnakeHead()
        {
            return snakeList[0];
        }

        /// <summary>
        /// 蛇是否达到最大长度
        /// </summary>
        /// <returns></returns>
        public bool IsMax()
        {
            return snakeList.Count == maxCount;
        }

        /// <summary>
        /// 蛇移动的方向
        /// </summary>
        public Direction MoveDirection { get; set; } = Direction.Right;

        /// <summary>
        /// 运动方向
        /// </summary>
        public enum Direction
        {
            Left,
            Up,
            Right,
            Down
        }
    }
}
