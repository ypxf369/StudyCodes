using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 简单工厂
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(new[] { "正常收费", "满300反100", "打8折" });
            comboBox1.SelectedIndex = 0;
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
        private double total = 0.0d;
        private void btnOk_Click(object sender, EventArgs e)
        {
            Charge chage = Factory.GetObj(comboBox1.SelectedItem.ToString());
            double totalPrice = chage.Calculate(Convert.ToDouble(textPrice.Text) * Convert.ToDouble(textNum.Text));
            listBox1.Items.Add("单价：" + textPrice.Text + "数量：" + textNum.Text + "总价：" + totalPrice);
            total += totalPrice;
            labTotalPrice.Text = total.ToString();
        }
    }
}
