using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;

using System.Windows.Forms;

namespace BigJob
{
    public partial class log : Form
    {
        public log()
        {
            InitializeComponent();
        }
        database link = new database();
        private void log_Load(object sender, EventArgs e)
        {

        }
        public void AddLog()
        {
            //简单判断下 插入的数据是否为空 如果为空 则弹出提示
            //通常这里不需要(用于异常提示)
            if (login.Uid == "" || login.Situation == "" || login.Time.ToString() == "")
            {
                MessageBox.Show("数据不能为空!");
                return;
            }

            /*Main.acecon = Main.connection();
            string sql = "insert into S_log(User_name,Situation,Time) values(login.Uid,login.Situation,login.Time)";
            Main.acecom = new OleDbCommand(sql, Main.acecon);
            Main.acecom.ExecuteNonQuery();//返回数据库中影响的行数*/
        }

        //写一个窗体加载自动从数据库获取数据并显示在datagridview的方法
        public void ShowMsg()
        {
            string sql = "select User_name,Situation,Time from S_log";
            // 使用conn连接桥梁来获取连接字符串
            DataTable dt = new DataTable();
            dt = link.SelectDataBase(sql);
            //将数据表的内容赋给DataGridView控件
            dataGridView1.DataSource = dt;
        }
        //写一个获取当前系统时间的方法
        public void GetExitTime()
        {
            //获取当前退出系统的时间
            login.Time = DateTime.Now;
            //将当前"退出"字符串赋给登录窗体的全局变量Situation
            login.Situation = "退出";
        }
    }
}
