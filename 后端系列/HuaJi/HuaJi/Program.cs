using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuaJi
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            var balls = new List<Ball>();
            var ballImg = new List<Image>();
            string root = Environment.CurrentDirectory;
            ballImg.Add(Image.FromFile($"{root}/img/huaji2.png"));
            ballImg.Add(Image.FromFile($"{root}/img/huaji4.png"));
            ballImg.Add(Image.FromFile($"{root}/img/huaji3.png"));
            var ran = new Random();
            for (int i = 0; i < 1; i++)
            {
                int ballsize = (int)(ran.NextDouble() * (500 - 10) + 10);
                balls.Add(new NpcBall(
                    (int)(ran.NextDouble() * (Form1.width - ballsize / 2 - 15 - ballsize / 2) + ballsize / 2),
                    (int)(ran.NextDouble() * (Form1.height - ballsize / 2 - 35 - ballsize / 2) + ballsize / 2),
                    ballImg,
                    ballsize,
                    (int)(ran.NextDouble() * (5 - 1) + 1),
                    ran.NextDouble() * 90,
                    ran.NextDouble() * 1000 % 2 == 0 ? 1 : -1,
                    ran.NextDouble() * 1000 % 2 == 0 ? 1 : -1
                    ));
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(0, 0, balls));
        }
    }
}
