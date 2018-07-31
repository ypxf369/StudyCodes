using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeConsole
{
    public class MapManager
    {
        private const int row = 25;
        private const int col = 80;
        private Snake snake;
        private Block b;//食物
        private Timer t;//定时器
        int[,] gameMap = new int[row, col];//地图
        private int count = 0;
        private StringBuilder mapBuffer;//缓存区
        private bool isNormal = true;
        private Direction moveDirection = Direction.Right;

        //初始化地图+绘制边界,0为空白区域，1为实体区域
        private void InitMap()
        {
            for (int i = 0; i < row; i++)
            {
                if (i == row - 1 || i == 0) //绘制横边界
                {
                    for (int j = 0; j < col; j++)
                    {
                        gameMap[i, j] = 1;
                    }
                }
                else
                {
                    for (int j = 0; j < col; j++)
                    {
                        if (j == col - 1 || j == 0) //绘制纵边界
                        {
                            gameMap[i, j] = 1;
                        }
                        else
                        {
                            gameMap[i, j] = 0;
                        }
                    }
                }
            }
        }

        //绘制蛇
        private void InitSnake()
        {
            foreach (var s in snake.SnakeList)
            {
                gameMap[s.Row, s.Col] = 1;
            }
        }

        //绘制食物
        private void InitFood()
        {
            gameMap[b.Row, b.Col] = 1;
        }

        //输出控制台
        private void DrawMap()
        {
            mapBuffer.Clear();
            Console.Clear();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (gameMap[i, j] == 1)
                    {
                        mapBuffer.Append("*");
                    }
                    else
                    {
                        mapBuffer.Append(" ");
                    }
                }
                mapBuffer.Append("\n");
            }
            Console.WriteLine("\n-----------------------------当前得分{0}-------------------------------\n", count);
            Console.WriteLine(mapBuffer.ToString());//从缓存区中输出整个游戏画面
        }

        //游戏运行管理
        private void GameRun(object o)
        {
            InitMap();
            InitSnake();
            InitFood();
            if (snake.IsEatFood(b))
            {
                b = Block.ProvideFood();//产生新的食物
                count++;//得分加1
            }
            snake.Move(moveDirection);
            if (snake.IsOver())
            {
                GameOver();
            }
            DrawMap();
        }

        private void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game Over");
            isNormal = false;
            //t.Dispose();
        }

        private void GameInit()
        {
            Console.WriteLine("按[↑，↓，←，→]进行方向控制，按[q]退出游戏！");
            Console.WriteLine("按任何键进入游戏");
            Console.ReadKey(true);
        }

        //程序开始，该方法包括启动定时器，以及与用户的交互
        public void Start()
        {
            GameInit();
            snake = new Snake();
            b = Block.ProvideFood();
            mapBuffer = new StringBuilder();
            t = new Timer(GameRun, null, 500, 200);
            //Task.Run(async () =>
            //{
            //    for (int i = 0; i < 100; i++)
            //    {
            //        GameRun(new object());
            //        await Task.Delay(500);
            //    }
            //});

            ConsoleKey key;
            //while (isNormal)
            while (true)
            {
                key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (moveDirection != Direction.Down)
                        {
                            moveDirection = Direction.Up;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (moveDirection != Direction.Left)
                        {
                            moveDirection = Direction.Right;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (moveDirection != Direction.Up)
                        {
                            moveDirection = Direction.Down;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (moveDirection != Direction.Right)
                        {
                            moveDirection = Direction.Left;
                        }
                        break;
                    case ConsoleKey.Q:
                        GameOver();
                        break;
                }
            }
            Console.ReadLine();
        }
    }
}
