using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 增加打折
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(new[] { "保持原价", "打8折", "打5折" });
            comboBox1.SelectedIndex = 0;
        }

        private double total = 0.0d;
        private void btnOk_Click(object sender, EventArgs e)
        {
            double totalPrice = Convert.ToDouble(textPrice.Text) * Convert.ToDouble(textNum.Text);
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    totalPrice = totalPrice * 0.8;
                    break;
                case 2:
                    totalPrice = totalPrice * 0.5;
                    break;
            }
            listBox1.Items.Add("单价：" + textPrice.Text + "数量：" + textNum.Text + "总价：" + totalPrice);
            total += totalPrice;
            labTotalPrice.Text = total.ToString();
        }
    }
}
