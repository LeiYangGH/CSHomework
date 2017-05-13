using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 车行租车系统
{
    public partial class YGMain : Form
    {
        public YGMain()
        {
            InitializeComponent();
        }
        private void CloseMdiForm()
        {
            //检索并关闭所有的mdi子窗体
            for (int i = 0; i < this.MdiChildren.Length; i++)
            {
                this.MdiChildren[i].Close();
            }
        }

        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseMdiForm();
            AdminPWD frm = new AdminPWD();
            frm.MdiParent = this;
            frm.Show();

        }



        private void YGMain_Load(object sender, EventArgs e)
        {
            frmRecommand frm = new frmRecommand();
            frm.Show();
            this.BackgroundImage = frm.GetImage();

            frm.Close();

            //this.BackgroundImage = this.GetRandCarImage();
        }




        private void 租借管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseMdiForm();
            UserJieYue frm = new UserJieYue();
            frm.MdiParent = this;
            frm.Show();

        }

        private void 我的租借ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseMdiForm();
            MyJieYue_List frm = new MyJieYue_List();
            frm.MdiParent = this;
            frm.Show();
        }

    }
}
