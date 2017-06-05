using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 反坦克导弹数据查询软件
{
    public partial class 修改 : Form
    {
        public 修改()
        {
            InitializeComponent();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            增加 form = new 增加();
            form.Show();
            this.Hide();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            模糊查询 form = new 模糊查询();
            form.Show();
            this.Hide();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Form5 form = new Form5();
            form.Show();
            this.Hide();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            删除 form = new 删除();
            form.Show();
            this.Hide();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            数据展示 form = new 数据展示();
            form.Show();
            this.Hide();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            用户管理 form = new 用户管理();
            form.Show();
            this.Hide();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            DialogResult myresult;
            myresult = MessageBox.Show("是否退出程序", "退出提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (myresult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (myresult == DialogResult.No)
            {
                return;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.aKDTableAdapter.Update(this.dDDataSet.AKD);
            MessageBox.Show("ok");
        }

        private void 修改_Load(object sender, EventArgs e)
        {
            // TODO:  这行代码将数据加载到表“dDDataSet.AKD”中。您可以根据需要移动或删除它。
            this.aKDTableAdapter.Fill(this.dDDataSet.AKD);

        }
    }
}
