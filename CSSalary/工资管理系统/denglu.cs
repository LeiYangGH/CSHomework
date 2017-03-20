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
    public partial class dl : Form
    {
        public dl()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void gly_CheckedChanged(object sender, EventArgs e)
        {
     
        }

        private void dlan_Click(object sender, EventArgs e)
        {
            if(gly.Checked)
            CPublic.Checkguanliyuan(ygbh.Text, mm.Text);
            else
            CPublic.Checkusers(ygbh.Text, mm.Text);

            if (CPublic.LoginInfo == null) MessageBox.Show("请输入正确的员工编号或密码", "登录失败",MessageBoxButtons.OK,MessageBoxIcon.Information);
            else
            {
                first frm = new first();
                frm.Show();
            }
          
        }

        private void tcan_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }
}
