using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snak2
{
    public class Snake
    {
        public List<Cell> snakeList = new List<Cell>();
        private int cellWidth;
        private int cellHeight;
        public Point headPoint;

        public Snake(int width, int heigth)
        {
            this.cellWidth = width;
            this.cellHeight = heigth;

            headPoint = new Point(3, 1);
            snakeList.Add(new Cell(headPoint.X - 2, headPoint.Y, width, heigth));
            snakeList.Add(new Cell(headPoint.X - 1, headPoint.Y, width, heigth));
            snakeList.Add(new Cell(headPoint.X, headPoint.Y, width, heigth));
        }

        public void Draw(Graphics g, Color c)
        {
            foreach (Cell snake in snakeList)
            {
                snake.Draw(g, c);
            }
        }

        public void Clear(Graphics g, Color c)
        {
            foreach (Cell snake in snakeList)
            {
                snake.Clear(g, c);
            }
            snakeList.Clear();
        }

        public void RemoveTail(Graphics g, Color c)
        {
            snakeList[0].Clear(g, c);
            snakeList.RemoveAt(0);
        }

        public void AddHead(Graphics g, Color c)
        {
            Cell newSnake = new Cell(headPoint.X, headPoint.Y, cellWidth, cellHeight);
            snakeList.Add(newSnake);
            newSnake.Draw(g, c);
        }

        public void MoveRight()
        {
            headPoint.X++;
        }

        public void MoveDown()
        {
            headPoint.Y++;
        }

        public void MoveLeft()
        {
            headPoint.X--;
        }

        public void MoveUp()
        {
            headPoint.Y--;
        }
    }
}
