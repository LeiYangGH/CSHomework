using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 车行租车系统
{
    public partial class Main : Form
    {
        public Main()
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
   

        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseMdiForm();
            Admin frm = new Admin();
            frm.MdiParent = this;
            frm.Show();

        }

        private void 权限挂了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseMdiForm();
            Admin_List frm = new Admin_List();
            frm.MdiParent = this;
            frm.Show();

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
 

 
     
    
        private void 车辆类型管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseMdiForm();
            LeiXing_List frm = new LeiXing_List();
            frm.MdiParent = this;
            frm.Show();

        }

        private void 车辆管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CloseMdiForm();
            Car_List frm = new Car_List();
            frm.MdiParent = this;
            frm.Show();

        }

        private void 用户管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CloseMdiForm();
            JieYueZhe_List frm = new JieYueZhe_List();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
