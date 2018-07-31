using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snak1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            this.KeyPreview = true;
            InitializeComponent();
        }

        List<List<Node>> mapList = new List<List<Node>>();
        private Map map;
        private Snake snake;
        Graphics g;
        private int level = 1;
        //运行线程
        private Thread Work_Thread = null;
        //运行线程监控值
        private bool IsWork = false;
        private int sleepTime = 500;
        private int currentSleepTime;

        private void MainForm_Load(object sender, EventArgs e)
        {
            g = this.panel1.CreateGraphics();
            map = new Map(40, 40, panel1); //这里可以对画布进行大小设置
            LoadMapList(); //加载障碍物列表
        }

        /// <summary>
        /// 默认将地图设置为30*40
        /// </summary>
        private void SetMap()
        {
            map.ResetMap();
            g.Clear(map.BgColor);
            map.SetBorder(); //设置边界
            var hiderList = GetHider(); //获取障碍物列表
            map.SetHinder(hiderList); //设置障碍物
            SetSnake(); //初始化蛇
        }

        /// <summary>
        /// 初始化蛇
        /// </summary>
        private void SetSnake()
        {
            snake = new Snake(20, 5, panel1);
            snake.InitializeSnake(); //初始化蛇
        }

        /// <summary>
        /// 获取地图障碍物列表，以增加不同级别难度
        /// </summary>
        private void LoadMapList()
        {
            //目前分为5个级别
            //第一级别
            List<Node> hiderList1 = new List<Node>();
            for (int i = 15; i < 25; i++)
            {
                hiderList1.Add(map.GetNode(i, 15));
                hiderList1.Add(map.GetNode(15, i));
            }
            mapList.Add(hiderList1);

            //第二级别
            List<Node> hiderList2 = new List<Node>();
            for (int i = 7; i < 25; i++)
            {
                hiderList2.Add(map.GetNode(i, 15));
                hiderList2.Add(map.GetNode(15, i));
            }
            mapList.Add(hiderList2);

            //第三级别
            List<Node> hiderList3 = new List<Node>();
            for (int i = 7; i < 25; i++)
            {
                hiderList3.Add(map.GetNode(i, 15));
                hiderList3.Add(map.GetNode(15, i));
                hiderList3.Add(map.GetNode(i, 25));
            }
            mapList.Add(hiderList3);

            //第四级别
            List<Node> hiderList4 = new List<Node>();
            for (int i = 7; i < 25; i++)
            {
                hiderList4.Add(map.GetNode(i, 25));
                hiderList4.Add(map.GetNode(i, 15));
                hiderList4.Add(map.GetNode(15, i));
                hiderList4.Add(map.GetNode(i, 7));
            }
            mapList.Add(hiderList4);

            //第五级别
            List<Node> hiderList5 = new List<Node>();
            for (int i = 7; i < 25; i++)
            {
                hiderList5.Add(map.GetNode(i, 25));
                hiderList5.Add(map.GetNode(i, 15));
                hiderList5.Add(map.GetNode(15, i));
                hiderList5.Add(map.GetNode(i, 7));
                hiderList5.Add(map.GetNode(i, 35));
            }
            for (int i = 12; i < 20; i++)
            {
                hiderList5.Add(map.GetNode(7, i));
                hiderList5.Add(map.GetNode(25, i));
            }
            mapList.Add(hiderList5);
        }

        private List<Node> GetHider()
        {
            //这里可以添加多个地图，当级别改变时需要重新加载
            return mapList[level - 1];
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 重置地图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReloadMap_Click(object sender, EventArgs e)
        {
            IsWork = false;
            btnStop.Enabled = false;
            btnPause.Enabled = false;
            btnStart.Enabled = true;
            SetMap();
        }

        private void Work()
        {
            map.SetFood(); //设置食物
            while (IsWork)
            {
                Node node_index = null;
                Node snakeHead = snake.GetSnakeHead();
                switch (snake.MoveDirection)
                {
                    case Snake.Direction.Left:
                        node_index = map.GetNode(snakeHead.X - 1, snakeHead.Y);
                        break;
                    case Snake.Direction.Right:
                        node_index = map.GetNode(snakeHead.X + 1, snakeHead.Y);
                        break;
                    case Snake.Direction.Up:
                        node_index = map.GetNode(snakeHead.X, snakeHead.Y - 1);
                        break;
                    case Snake.Direction.Down:
                        node_index = map.GetNode(snakeHead.X, snakeHead.Y + 1);
                        break;
                }
                SnakeState state = SnakeMove(node_index);
                if (state == SnakeState.Error) //游戏结束
                {
                    IsWork = false;
                    MessageBox.Show("游戏结束！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sleepTime = 1000;
                    level = 1;
                    currentSleepTime = sleepTime;
                    labLevelVlue.BeginInvoke(new MethodInvoker(() =>
                    {
                        btnStop.Enabled = false;
                        btnStart.Enabled = true;
                        btnPause.Enabled = false;
                        labLevelVlue.Text = "1";
                        labLengthValue.Text = "5";
                    }));
                }
                else if (state == SnakeState.NextLevel)
                {
                    IsWork = false;
                    labLengthValue.BeginInvoke(new MethodInvoker(() =>
                    {
                        level += 1;
                        labLevelVlue.Text = level.ToString();
                        labLengthValue.Text = "5";
                    }));
                    sleepTime = sleepTime / 2;
                    currentSleepTime = sleepTime;
                    SetMap(); //重置地图
                }
                else
                {
                    Thread.Sleep(currentSleepTime);
                }
            }
            map.ResetMap();
        }

        /// <summary>
        /// 开始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            IsWork = false;
            btnStop.Enabled = false;
            btnPause.Enabled = true;
            btnStart.Enabled = false;
            SetMap();
            currentSleepTime = sleepTime;
            panel1.Focus();
            IsWork = true;
            btnStop.Enabled = true;
            btnPause.Enabled = true;
            btnReloadMap.Enabled = false;
            Work_Thread = new Thread(Work);
            Work_Thread.IsBackground = true;
            Work_Thread.Start();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                if (snake.MoveDirection != Snake.Direction.Left)
                    snake.MoveDirection = Snake.Direction.Right;
                Thread.Sleep(currentSleepTime);
            }
            else if (e.KeyCode == Keys.Left)
            {
                if (snake.MoveDirection != Snake.Direction.Right)
                    snake.MoveDirection = Snake.Direction.Left;
                Thread.Sleep(currentSleepTime);
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (snake.MoveDirection != Snake.Direction.Down)
                    snake.MoveDirection = Snake.Direction.Up;
                Thread.Sleep(currentSleepTime);
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (snake.MoveDirection != Snake.Direction.Up)
                    snake.MoveDirection = Snake.Direction.Down;
                Thread.Sleep(currentSleepTime);
            }
            else if (e.KeyCode == Keys.Space)
            {
                currentSleepTime = sleepTime / 2;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (IsWork)
                {
                    this.btnPause.Text = "继续";
                    IsWork = false;
                }

            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (!IsWork)
            {
                this.btnPause.Text = "暂停";
                IsWork = true;
                Work_Thread = new Thread(Work);
                Work_Thread.IsBackground = true;
                Work_Thread.Start();
            }
            else
            {
                this.btnPause.Text = "继续";
                IsWork = false;
            }

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStop.Enabled = false;
            btnPause.Enabled = false;
            btnStart.Enabled = true;
            IsWork = false;
            Work_Thread.Abort();
            SetMap();

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsWork = false;
            Application.Exit();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private SnakeState SnakeMove(Node node)
        {
            if (!node.IsPass)
            {
                return SnakeState.Error;
            }
            snake.InsertNode(node);
            if (!node.IsFood)
            {
                //不是食物，则移除最右一个节点
                snake.RemoveNode();
            }
            else
            {
                labLengthValue.BeginInvoke(new MethodInvoker(() =>
                {
                    labLengthValue.Text = (Convert.ToInt32(labLengthValue.Text.Trim()) + 1).ToString();
                }));
                map.SetFood();//设置食物
            }
            if (snake.IsMax())
            {
                return SnakeState.NextLevel;
            }
            return SnakeState.Moving;
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                currentSleepTime = sleepTime;
            }
        }

        private void chooseLevel_CheckedChanged(object sender, EventArgs e)
        {
            levelComboBox.Enabled = chooseLevel.Checked;
        }

        private void levelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 1;
            int index_count = Convert.ToInt32(levelComboBox.Text);
            for (int i = 1; i < index_count; i++)
            {
                index = index * 2;
            }
            level = index_count;
            sleepTime = 1000 / index;
            currentSleepTime = sleepTime;
            btnStop.Enabled = false;
            btnPause.Enabled = false;
            btnStart.Enabled = true;
            IsWork = false;

            SetMap();
            labLevelVlue.Text = "5";
            labLevelVlue.Text = index_count.ToString();
            snake.MoveDirection = Snake.Direction.Right;

        }
    }

    public enum SnakeState
    {
        Moving,
        NextLevel,
        Error
    }
}
