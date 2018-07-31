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
    /// 地图
    /// </summary>
    public class Map
    {
        //节点数组
        private List<List<Node>> _nodes;
        private int RowCount;
        private int ComsCount;
        private Control MapPanel;
        Graphics g;

        /// <summary>
        /// 地图背景色，和Node中背景色一致
        /// </summary>
        public Color BgColor { get; set; } = Color.FromArgb(224, 224, 224);


        public Map(int rows, int coms, Control c)
        {
            RowCount = rows;
            ComsCount = coms;
            MapPanel = c;
            g = c.CreateGraphics();
            _nodes = new List<List<Node>>();
            for (int i = 0; i < rows; i++)
            {
                var nodes = new List<Node>();
                for (int j = 0; j < coms; j++)
                {
                    var node = new Node(i, j);
                    nodes.Add(node);
                }
                _nodes.Add(nodes);
            }
        }

        public Map(int rows, int coms, int width, Control c)
        {
            RowCount = rows;
            ComsCount = coms;
            MapPanel = c;
            g = c.CreateGraphics();
            _nodes = new List<List<Node>>();
            for (int i = 0; i < rows; i++)
            {
                var nodes = new List<Node>();
                for (int j = 0; j < coms; j++)
                {
                    var node = new Node(j, i, width);
                    nodes.Add(node);
                }
                _nodes.Add(nodes);
            }
        }

        /// <summary>
        /// 重新加载地图
        /// </summary>
        public void ResetMap()
        {
            for (int i = 0; i < ComsCount; i++)
            {
                for (int j = 0; j < RowCount; j++)
                {
                    var node = GetNode(i, j);
                    node.IsPass = true;
                    node.IsFood = false;
                }
            }
        }

        /// <summary>
        /// 获得节点
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Node GetNode(int x, int y)
        {
            return _nodes[x][y];
        }

        /// <summary>
        /// 设置食物
        /// </summary>
        public void SetFood()
        {
            SolidBrush brush = null;
            int x, y;
            var r = new Random();
            while (true)
            {
                x = r.Next(0, RowCount);
                y = r.Next(0, ComsCount);
                if (_nodes[x][y].IsPass)//避免将食物设置到障碍物上面了
                {
                    var nodeIndex = _nodes[x][y];
                    nodeIndex.SetFood(true);
                    brush = new SolidBrush(nodeIndex.FoodColor);
                    RectangleF[] rects =
                    {
                        new RectangleF(nodeIndex.X * nodeIndex.Width, nodeIndex.Y * nodeIndex.Width, nodeIndex.Width,nodeIndex.Width)
                    };
                    g.FillRectangles(brush, rects);
                    break;
                }
            }
        }

        /// <summary>
        /// 设置障碍物
        /// </summary>
        /// <param name="list"></param>
        public void SetHinder(List<Node> list)
        {
            SolidBrush brush = null;
            RectangleF[] rects = new RectangleF[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                var node = list[i];
                node.SetHinder(true);
                node.IsPass = false;
                if (brush == null)
                {
                    brush = new SolidBrush(node.HinderColor);
                }
                RectangleF r = new RectangleF(node.X * node.Width, node.Y * node.Width, node.Width, node.Width);
                rects[i] = r;
            }
            g.FillRectangles(brush, rects);
        }

        /// <summary>
        /// 设置边界
        /// </summary>
        public void SetBorder()
        {
            //通过计算得出边界的个数是2(x+y-2)个方格
            SolidBrush brush = null;
            int borders = 2 * (ComsCount + RowCount - 2);
            RectangleF[] rects = new RectangleF[borders];
            int indexcount = 0;
            //添加顶部方格进rects列表中
            for (int i = 0; i < RowCount; i++)
            {
                var node = _nodes[i][0];
                node.SetHinder(true);
                if (brush == null)
                {
                    brush = new SolidBrush(node.HinderColor);
                }
                RectangleF r = new RectangleF(node.X * node.Width, node.Y * node.Width, node.Width, node.Width);
                rects[indexcount] = r;
                indexcount++;
            }
            //添加底部方格进rects列表中
            for (int i = 0; i < RowCount; i++)
            {
                var node = _nodes[i][ComsCount - 1];
                node.SetHinder(true);
                RectangleF r = new RectangleF(node.X * node.Width, node.Y * node.Width, node.Width, node.Width);
                rects[indexcount] = r;
                indexcount++;
            }
            //添加左侧方格进列表，因为左侧最上面及最下面的方格已经添加进去，这里不需要重复添加
            for (int i = 1; i < ComsCount - 1; i++)
            {
                var node = _nodes[0][i];
                node.SetHinder(true);
                RectangleF r = new RectangleF(node.X * node.Width, node.Y * node.Width, node.Width, node.Width);
                rects[indexcount] = r;
                indexcount++;
            }
            //添加右侧方格进列表，因为右侧最上面及最下面的方格已经添加进去，这里不需要重复添加
            for (int i = 1; i < ComsCount - 1; i++)
            {
                var node = _nodes[RowCount - 1][i];
                node.SetHinder(true);
                RectangleF r = new RectangleF(node.X * node.Width, node.Y * node.Width, node.Width, node.Width);
                rects[indexcount] = r;
                indexcount++;
            }
            g.FillRectangles(brush, rects);
        }
    }
}
