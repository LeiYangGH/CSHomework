using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace p22
{
    public partial class 界面 : Form
    {
        public 界面()
        {
            InitializeComponent();
        }

        private void 界面_Load(object sender, EventArgs e)
        {
            Repository.dataRoute.ReadFile();
            Repository.dataTourist.ReadFile();
            Repository.dataActivity.ReadFile();

            //return;
            登录 frmSuper = new 登录();
            var result = frmSuper.ShowDialog();
            if (result != DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            btn1 frm = new btn1();
            frm.ShowDialog();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            路线价格 frm = new 路线价格();
            frm.ShowDialog();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            btn2 frm = new btn2();
            frm.ShowDialog();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            路线选择 frm = new 路线选择();
            frm.ShowDialog();
        }
    }
}
