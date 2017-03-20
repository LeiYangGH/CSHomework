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
    public partial class frmLogin : Form
    {
        public static bool isAdmin;
        public static string userID;
        public static string userName;

        public frmLogin()
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
            bool loginSuccess;
            if (this.gly.Checked)
                loginSuccess = DataAccess.Checkguanliyuan(ygbh.Text, mm.Text, out frmLogin.userName);
            else
                loginSuccess = DataAccess.Checkusers(ygbh.Text, mm.Text);

            if (loginSuccess)
            {
                this.Hide();
                frmLogin.isAdmin = this.gly.Checked;
                frmLogin.userID = this.ygbh.Text;
                frmMain frm = new frmMain();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("请输入正确的员工编号或密码", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void tcan_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
