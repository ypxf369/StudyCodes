using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuaJi
{
    public partial class Form1 : Form
    {
        public static int width = 1920;
        public static int height = 1080;
        public List<Ball> b;

        public Form1()
        {
            InitializeComponent();
        }

        public Form1(int x, int y, List<Ball> b) : this()
        {
            this.SetBounds(x, y, width, height);
            this.SetVisibleCore(true);
            this.b = b;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.Width = width;
            panel1.Height = height;
            int x, y, xr, yr;
            for (int i = 0; i < b.Count; i++)
            {
                x = (int)(b.ElementAt(i).X - b.ElementAt(i).L / 2);
                y = (int)(b.ElementAt(i).Y - b.ElementAt(i).L / 2);
                xr = (int)b.ElementAt(i).L;
                yr = (int)b.ElementAt(i).L;
                panel1.CreateGraphics()
                        .DrawImage(b.ElementAt(i).Img.ElementAt((int)b.ElementAt(i).NowImg),
                            new Rectangle(x, y, xr, yr));
            }
            panel1.Refresh();
        }
    }
}
