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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new JieYueZhe().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
#if TEST
            UserInfo.setUserPWD = "0001";
            UserInfo.setUserName = "0001";

            this.Hide();
            new YGMain().ShowDialog();
#else
            if (this.comboBox1.SelectedIndex == 0)
            {
                string sql = "select * from TB_Admin where UserName='" + this.textBox1.Text + "' and  PWD='" + this.textBox2.Text + "' and QX='管理员'";
                DataSet ds = DBHelper.GetDate(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    UserInfo.setUserPWD = textBox2.Text.Trim();
                    UserInfo.setUserName = textBox1.Text.Trim();
 
                    this.Hide();
             new Main().ShowDialog();
                }
                else
                {
                    MessageBox.Show("帐号或密码错误!");
                }
            }
            if (this.comboBox1.SelectedIndex == 1)
            {
                string sql = "select * from TB_Admin where UserName='" + this.textBox1.Text + "' and  PWD='" + this.textBox2.Text + "'  and QX='工作人员'";
                DataSet ds = DBHelper.GetDate(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    UserInfo.setUserPWD = textBox2.Text.Trim();
                    UserInfo.setUserName = textBox1.Text.Trim();

                    this.Hide();
                    new GZMain().ShowDialog();
                }
                else
                {
                    MessageBox.Show("帐号或密码错误!");
                }
            } if (this.comboBox1.SelectedIndex ==2)
            {
                string sql = "select * from TB_User where UserName='" + this.textBox1.Text + "' and  PWD='" + this.textBox2.Text + "' ";
                DataSet ds = DBHelper.GetDate(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    UserInfo.setUserPWD = textBox2.Text.Trim();
                    UserInfo.setUserName = textBox1.Text.Trim();

                    this.Hide();
                    new YGMain().ShowDialog();
                }
                else
                {
                    MessageBox.Show("帐号或密码错误!");
                }
            }
#endif
        }

    }
}
