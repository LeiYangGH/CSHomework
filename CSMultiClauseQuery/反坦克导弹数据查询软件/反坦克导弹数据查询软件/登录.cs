using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace 反坦克导弹数据查询软件
{
    public partial class 登录 : Form
    {
        public 登录()
        {
            InitializeComponent();
        }

        private void btlogin_Click(object sender, EventArgs e)
        {
            string strConnection = "provider=microsoft.jet.oledb.4.0;";
            strConnection += @"data source=dl.mdb";
            OleDbConnection objconnection = new OleDbConnection(strConnection);
            objconnection.Open();
            string sql = "select * from dlxxb  where name='" + this.manager.Text + "' and password='" + this.password.Text + "' and bzb='"+部职别.Text+"' and yhlx='"+用户.Text+"'";
            OleDbCommand cmd = new OleDbCommand(sql,objconnection);
            int state = Convert.ToInt32(cmd.ExecuteScalar());
            if(state == 0||state>1)
            {
                MessageBox.Show("没有此用户", "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                模糊查询 form = new 模糊查询();
                form.Show();
                this.Hide();
            }
            objconnection.Close();
            
        }


        private void btlogout_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            注册 form = new 注册();
            form.Show();
            this.Hide();
        }
    }
}
