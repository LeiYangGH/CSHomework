using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password3
{
    public partial class Form1 : Form
    {
        private Dictionary<string, string> dicUP;
        public Form1()
        {
            InitializeComponent();
            this.dicUP = new Dictionary<string, string>()
            {
//                用户名peer，密码123456
//用户名Jack，密码joking
//用户名Saya，密码sakura
                {"peer","123456" },
                {"Jack","joking" },
                {"Saya","sakura" },
            };
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string u = this.txtU.Text;
            string p = this.txtP.Text;
            if (this.dicUP.Any(d => d.Key == u
                && d.Value == p))
            {
                MessageBox.Show("登录成功！");
            }
            else
            {
                MessageBox.Show("登录失败！请检查用户名或密码！");

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
