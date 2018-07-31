using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snak2
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
            //绘制网格
            Bitmap bitmap = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            Graphics g = Graphics.FromImage(bitmap);
            for (int i = 0; i < 30; i++)
            {
                g.DrawLine(new Pen(Color.LightGray), new Point(20 * i, 0), new Point(20 * i, 600));
                g.DrawLine(new Pen(Color.LightGray), new Point(0, 20 * i), new Point(600, 20 * i));
            }
            Graphics fg = e.Graphics;
            fg.DrawImage(bitmap, this.ClientRectangle);
            //贪吃蛇
            Cell snake1 = new Cell(0, 0, 20, 20);
            Cell snake2 = new Cell(1, 0, 20, 20);
            Cell snake3 = new Cell(2, 0, 20, 20);
            snake1.Draw(fg, Color.Black);
            snake2.Draw(fg, Color.Black);
            snake3.Draw(fg, Color.Black);


            //食物
            Food food = new Food(4, 4, 20, 20);
            food.Draw(fg, Color.Green);

            //墙
            Brick brick = new Brick(7, 7, 20, 20);
            brick.Draw(fg, Color.Gray);
        }
        private Snake snake=new Snake(20,20);
        private Direction snakeDirection = Direction.Right;
        private bool isGamePalying = false;
        private bool isGameOver = false;
        private bool isDirectionChanged = false;
        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isGamePalying) return;
            //如果方向键已经按下，则等待time tick时间响应
            if (isDirectionChanged) return;

            if (e.KeyCode == Keys.Up && snakeDirection != Direction.Down)
            {
                snakeDirection = Direction.Up;
                isDirectionChanged = true;
            }
            else if (e.KeyCode == Keys.Down && snakeDirection != Direction.Up)
            {
                snakeDirection = Direction.Down;
                isDirectionChanged = true;
            }
            else if (e.KeyCode == Keys.Left && snakeDirection != Direction.Right)
            {
                snakeDirection = Direction.Left;
                isDirectionChanged = true;
            }
            else if (e.KeyCode == Keys.Right && snakeDirection != Direction.Left)
            {
                snakeDirection = Direction.Right;
                isDirectionChanged = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!isGamePalying) return;
            if (!isGameOver)
            {
                isDirectionChanged = false;
                //根据方向判断坐标值的变化
                if (snakeDirection == Direction.Right)
                {
                    snake.MoveRight();
                }
                else if (snakeDirection == Direction.Down)
                {
                    snake.MoveDown();
                }
                else if (snakeDirection == Direction.Left)
                {
                    snake.MoveLeft();
                }
                else if (snakeDirection == Direction.Up)
                {
                    snake.MoveUp();
                }
                //判断是否撞墙
                if (snake.headPoint.X >= 19 || snake.headPoint.X <= 0 || snake.headPoint.Y >= 19 ||
                    snake.headPoint.Y <= 0)
                {
                    isGameOver = true;
                    //this.lblGameOver.Visible = true;
                    return;
                }
                ////判断是否撞到自己
                //if (food.isFull(snake.headpoint.X, snake.headpoint.Y, snake))
                //{
                //    isGameOver = true;
                //    this.lblGameOver.Visible = true;
                //    return;
                //}
                ////判断是否吃到食物
                //if (snake.headPoint.X == food.X && snake.headPoint.Y == food.Y)
                //{
                //    food.Clear(this.pictureBox1.CreateGraphics(), this.BackColor);
                //    food = food.NewFood(snake);
                //    food.Draw(this.pictureBox1.CreateGraphics(), Color.Green);
                //}
                //else
                //{
                //    //没有吃到食物，移除Tail
                //    snake.RemoveTail(this.pictureBox1.CreateGraphics(), this.BackColor);
                //}
                ////绘制新的head
                //snake.AddHead(this.pictureBox1.CreateGraphics(), Color.Black);

            }
        }
    }

    public enum Direction
    {
        Left, Right, Up, Down
    }
}
