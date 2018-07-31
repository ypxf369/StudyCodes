using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeConsole
{
    public class Block
    {
        private int x;
        private int y;

        public Block()
        {

        }

        public Block(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int Row
        {
            get { return x; }
            set { x = value; }
        }

        public int Col
        {
            get { return y; }
            set { y = value; }
        }

        public bool IsEqual(Block b)
        {
            return x == b.Row && y == b.Col;
        }

        public static Block ProvideFood()
        {
            var ran = new Random();
            Block b = new Block(ran.Next(1, 25), ran.Next(1, 80));
            return b;
        }
    }
}
