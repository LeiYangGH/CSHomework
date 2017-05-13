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
    public partial class AdminPWD : Form
    {
        public AdminPWD()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (this.textBox1.Text == UserInfo.getUserPWD)
            {
                if (this.textBox3.Text != this.textBox2.Text)
                {
                    MessageBox.Show("两次输入的密码不一致，请检查！");
                }
                else
                {

                    try
                    {

                        string SQL = "update TB_Admin set PWD='" + this.textBox2.Text + "' where UserName='" + UserInfo.getUserName + "'";
                        int B = DBHelper.Exec(SQL);
                        if (B>0)
                        {
                            MessageBox.Show("操作成功");
                        }
                        else
                        {
                            MessageBox.Show("操作错误，请检查数据是否合法！");
                        }
                    }
                    catch
                    {

                        MessageBox.Show("操作错误，请检查是否主键冲突！");
                    }
                }
            }
            else
            {
                MessageBox.Show("您输入的旧密码错误，请重新输入！");

            }
        }
    }
}
