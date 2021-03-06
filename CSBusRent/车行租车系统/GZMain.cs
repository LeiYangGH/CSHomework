﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 车行租车系统
{
    public partial class GZMain : Form
    {
        public GZMain()
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
 
  

        private void GZMain_Load(object sender, EventArgs e)
        {

        }

        private void 借阅管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseMdiForm();
            JieYue frm = new JieYue();
            frm.MdiParent = this;
            frm.Show();

        }

        private void 归还管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseMdiForm();
            JieYue_List frm = new JieYue_List();
            frm.MdiParent = this;
            frm.Show();
        }

 

        private void 租借管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseMdiForm();
            JieYue frm = new JieYue();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
