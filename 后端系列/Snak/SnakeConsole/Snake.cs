using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeConsole
{
    public class Snake
    {
        public List<Block> SnakeList { get; } = new List<Block>();

        public Snake()
        {
            InitSnake();
        }

        private void InitSnake()
        {
            int rowStart = 2;
            int colStart = 5;
            int length = 20 + colStart;
            Block b;
            for (int i = colStart; i < length; i++)
            {
                b = new Block(rowStart, i);
                SnakeList.Insert(0, b);
            }
        }

        /// <summary>
        /// 判断蛇是否到达食物的位置，如果到达则eat
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool IsEatFood(Block b)
        {
            Block head = SnakeList[0];//获取蛇头
            if (head.IsEqual(b))//判断是否和食物的位置一致
            {
                SnakeList.Insert(0, b);//添加一个bloc到蛇的集合中，
                return true;
            }
            return false;
        }

        public void Move(Direction d)
        {
            Block head = SnakeList[0];//获取蛇头
            SnakeList.RemoveAt(SnakeList.Count - 1);//移除蛇尾
            Block newBlock = null;
            switch (d)//获取蛇当前运行的方向，然后根据蛇头的位置计算出新的蛇头位置
            {
                case Direction.Up:
                    newBlock = new Block(head.Row - 1, head.Col);
                    break;
                case Direction.Right:
                    newBlock = new Block(head.Row, head.Col + 1);
                    break;
                case Direction.Down:
                    newBlock = new Block(head.Row + 1, head.Col);
                    break;
                case Direction.Left:
                    newBlock = new Block(head.Row, head.Col - 1);
                    break;
            }
            SnakeList.Insert(0, newBlock);//将新的位置插入到蛇头
        }

        public bool IsOver()
        {
            Block head = SnakeList[0];
            if (head.Row == 0 || head.Col == 0 || head.Row == 25 || head.Col == 80) //是否遇到边界
            {
                return true;
            }
            return SnakeList.Any(t => head.IsEqual(t));//是否遇到自身
        }
    }
}
