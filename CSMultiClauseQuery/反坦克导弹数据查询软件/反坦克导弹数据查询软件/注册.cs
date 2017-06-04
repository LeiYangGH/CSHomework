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
    public partial class 注册 : Form
    {
        public 注册()
        {
            InitializeComponent();
        }
       
        private void button1_Click_1(object sender, EventArgs e)
        {
            string connStr, insertCmd;
            connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=dl.mdb";
            insertCmd = "Insert Into [dlxxb]([name],[password],[bzb],[yhlx]) Values('" +
                姓名.Text.Replace("'", "''") + "','" +
                密码.Text.Replace("'", "''") + "','" +
                部职别.Text.Replace("'", "''") + "','" +
                用户.Text.Replace("'", "''") + "')";
            OleDbConnection conn;
            OleDbCommand cmd;
            conn = new OleDbConnection(connStr);
            conn.Open();
            cmd = new OleDbCommand(insertCmd, conn);
            
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("添加成功");
            }
            catch
            {
                MessageBox.Show("添加发生错误检查参数是否正确", "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmd.Connection.Close();
                return;
         }
            姓名.Text = "";
            密码.Text = "";
            部职别.Text = "";
            用户.Text = "";
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult myresult;
            myresult = MessageBox.Show("是否返回上一级", "返回提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (myresult == DialogResult.Yes)
            {
                登录 form = new 登录();
                form.Show();
                this.Hide();
            }
            else if (myresult == DialogResult.No)
            {
                return;
            }
            
           
        }
    }
}
