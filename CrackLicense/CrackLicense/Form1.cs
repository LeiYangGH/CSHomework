using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
namespace CrackLicense
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool b = false;
            try
            {
                //一个文本框输入一个长数字，然后判断是否合法注册码
                string txt = this.textBox1.Text.Trim();
                BigInteger l1 = BigInteger.Parse(new string(txt.Take(16).ToArray()));
                BigInteger l2 = BigInteger.Parse(new string(txt.Skip(16).ToArray()));
                BigInteger l3 = l1 * l2;
                string s = l3.ToString();
                b = (s == "20282408092494394779761211604993");
            }
            catch (Exception)
            {
            }
            if (b)
                MessageBox.Show("注册成功！");
            else
                MessageBox.Show("注册失败！");
        }
    }
}
