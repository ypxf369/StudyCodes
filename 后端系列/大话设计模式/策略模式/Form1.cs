using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 策略模式
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(new[] { "正常收费", "满300反100", "打8折" });
            comboBox1.SelectedIndex = 0;
        }
        private double total = 0.0d;
        private void btnOk_Click(object sender, EventArgs e)
        {
            var context = new ChargeContext(comboBox1.SelectedItem.ToString());
            double totalPrice =
                context.GetTotalPrice(Convert.ToDouble(textPrice.Text) * Convert.ToDouble(textNum.Text));
            listBox1.Items.Add("单价：" + textPrice.Text + "数量：" + textNum.Text + "总价：" + totalPrice);
            total += totalPrice;
            labTotalPrice.Text = total.ToString();
        }
    }
}
