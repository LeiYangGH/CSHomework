using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigJob
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        /*public static OleDbConnection acecon;
        public static OleDbDataAdapter aceda;
        public static OleDbCommand acecom;
        public static OleDbCommandBuilder aceComBld;
        public DataSet ds = new DataSet();
        private static string connstr = ConfigurationManager.ConnectionStrings["SQLConnString"].ConnectionString;
        public static OleDbConnection connection()
        {
            try
            {
                acecon = new OleDbConnection(connstr);
                acecon.Open();
                return acecon;
            }
            catch
            {
                throw new Exception("DB Connection Error!");
            }
        }*/

        public static DateTime dt;//记录退出时间

        log log1 = new log();
        private void Main_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            if (login.URight == "commonuser")
            {
                //地区管理ToolStripMenuItem.Enabled = false;
                安装信息管理ToolStripMenuItem.Enabled = false;
                用户信息录入ToolStripMenuItem.Enabled = false;
                授权管理ToolStripMenuItem.Enabled = false;
                登录验证ToolStripMenuItem.Enabled = false;
                产品信息录入ToolStripMenuItem.Enabled = false;
                地区信息录入ToolStripMenuItem.Enabled = false;
                产品信息录入ToolStripMenuItem.Enabled = false;
                服务商信息录入ToolStripMenuItem.Enabled = false;
                加油站信息录入ToolStripMenuItem.Enabled = false;
                工程师信息录入ToolStripMenuItem.Enabled = false;
                客户管理ToolStripMenuItem.Enabled = false;

            }
            //将当前登录用户名和登录时间赋给label的text属性
            //并在当前主界面窗体加载的时候 显示在label框上
            //label1.Text = "当前登录用户为: " + login.Uid + " " + "登录时间为:" + login.Time;
            toolStripStatusLabel2.Text = login.Uid;
            toolStripStatusLabel4.Text = login.Time.ToString(); ;
            
        }

        private void 系统管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void 返回登录界面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login l2 = new login();
            l2.ShowDialog();
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //dt = DateTime.Now;
           // this.Close();

            //调用获取当前退出时间的方法
            //log1.GetExitTime();
            //将当前用户的登录信息添加到DataGridView里面
            //log1.AddLog();
            dt = DateTime.Now;
            //直接退出系统
            Application.Exit();
        }

        private void 系统日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            systemLog sl = new systemLog();
            //log sl = new log();
            sl.MdiParent = this;
            //sl.WindowState = FormWindowState.Maximized;//以最大化形式打开
            sl.Show();
            //sl.ShowDialog();
        }

        private void 查看用户信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userInfo ui = new userInfo();
            ui.MdiParent = this;
            ui.Show();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (Form childrenForm in this.MdiChildren)
            {
                childrenForm.Close();
            }
        }

        private void 信息录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userInfoAdd uia = new userInfoAdd();
            uia.MdiParent = this;
            uia.Show();
        }

        private void 授权管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userPermission up = new userPermission();
            up.MdiParent = this;
            up.Show();
        }

        private void 登录验证ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userLoginVerify ulv = new userLoginVerify();
            ulv.MdiParent = this;
            ulv.Show();
        }

        private void 地区代码管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void 查看产品信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            productInfo pi = new productInfo();
            pi.MdiParent = this;
            pi.Show();
        }

        private void 地区信息录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
        }

        private void 安装信息录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 工程师信息录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployee fe = new frmEmployee();
            fe.MdiParent = this;
            fe.Show();
        }
    }
}
