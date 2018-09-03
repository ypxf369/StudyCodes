using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 简单
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private double total = 0.0d;
        private void btnOk_Click(object sender, EventArgs e)
        {
            double totalPrice = Convert.ToDouble(textPrice.Text) * Convert.ToDouble(textNum.Text);
            total += totalPrice;
            listBox1.Items.Add("单价：" + textPrice.Text + "数量：" + textNum.Text + "总价：" + totalPrice);
            labTotalPrice.Text = totalPrice.ToString();
        }
    }
}
