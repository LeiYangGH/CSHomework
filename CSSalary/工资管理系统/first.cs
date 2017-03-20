using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 工资管理系统
{
    public partial class first : Form
    {
        public first()
        {
            InitializeComponent();
        }



        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void 版权ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            banquan frm = new banquan();
            frm.Show();
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            help frm = new help();
            frm.Show();
        }

        private void SetAdminVisible(bool isAdmin)
        {
            添加新记录ToolStripMenuItem.Enabled = isAdmin;
            工资管理ToolStripMenuItem.Enabled = isAdmin;
            if (isAdmin)
            {
                ztlHM.Text = "您好，" + frmLogin.userName + "管理员，欢迎使用本系统！";
            }
            else
            {
                ztlHM.Text = "欢迎使用本系统！";
            }
        }

        private void gongziguanli_Load(object sender, EventArgs e)
        {
            this.SetAdminVisible(frmLogin.isAdmin);
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ztlHM_Click(object sender, EventArgs e)
        {

        }

        private void 工资修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gongziguanli frm = new gongziguanli();
            frm.Show();
        }

        private void gongzibiaoALLBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.gongzibiaoALLBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.biyeshejiDataSet);

        }

        private void gongzibiaoALLDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gongzibiaoALLBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void gongzibiaoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {


        }

        private void gongzibiaoALLBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void 添加新记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zhuce frm = new zhuce();
            frm.Show();
        }

        private void first_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

