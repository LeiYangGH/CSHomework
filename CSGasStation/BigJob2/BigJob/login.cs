using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigJob
{
    public partial class login : Form
    {
        database link = new database();

        //定义一个全局变量 Uid;
        //用于获取登录成功后的用户名
        public static string Uid;

        //定义一个全局变量 Time
        //用于获取登录成功后的用户的登录时间
        public static DateTime Time;

        //定义一个登录全局变量 用来获取 "登录" 或是"退出"
        public static string Situation;

        public static string UserPass = ""; //记录用户密码
        public static string UserPE = "";      //记录用户权限
        public static string UserName = "";
        private DataSet ds = new DataSet();
        private DataTable myTable;
        private DataRow myRow;   //数据库中的一行
        private string sql = "SELECT * from S_users";

        public static string URight;

        public static bool verify = false;  //记录能否检验是否通过
        public login()
        {
            InitializeComponent();
            string TableName = "S_users";
            ds = link.SelectDataBase(sql, TableName);
            myTable = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < myTable.Rows.Count; i++)
            {
                this.myRow = myTable.Rows[i];
                //只有当输入的用户名和密码同时对应上数据库中记录时，才能通过校验
                if (textBox1.Text=="" || textBox2.Text=="")
                {
                    MessageBox.Show("请输入用户名或密码！");
                }
                if (radioButton1.Checked == false && radioButton2.Checked == false)
                {
                    MessageBox.Show("请选择登录类型！");
                }
                else if (radioButton1.Checked == true)
                {
                    URight = "admin";
                }
                else
                {
                    URight = "commonuser";
                }
                if (myRow[1].ToString().Trim() == this.textBox1.Text.ToString().Trim() && myRow[2].ToString().Trim() == URight.Trim() && myRow[3].ToString().Trim() == this.textBox2.Text.ToString().Trim())
                {
                    UserName = myRow[1].ToString().Trim();//保存用户名
                    UserPE = myRow[2].ToString().Trim();//保存用户权限
                    UserPass = myRow[3].ToString().Trim();//保存用户密码
                    verify = true;
                }
            }
            if (verify == true)
            {
                //获取登陆成功后的用户ID
                Uid = textBox1.Text;

                //获取当前登录时间
                Time = DateTime.Now;

                //获取当前用户登录的情况
                Situation = "登录";

                Main m = new Main();
                this.Visible = false;//关闭窗体 
                m.ShowDialog(); 


                if (!File.Exists("Log.txt"))//判断日志文件是否存在
                {
                    File.Create("Log.txt");//创建日志文件
                }
                string strLog = "登录用户：" + textBox1.Text + "    登录时间：" + DateTime.Now + "    退出时间：" + Main.dt;
                using (StreamWriter sWriter = new StreamWriter("Log.txt", true))//创建StreamWriter对象
                {
                    sWriter.WriteLine(strLog);//写入日志
                }
                //systemLog frm = new systemLog();
                //this.Hide();//隐藏当前窗体
                //frm.Show();//显示窗体
                
            }
            else
            {
                MessageBox.Show("您输入的用户名或密码或登录类型不正确!");
                textBox1.Text = "";
                textBox2.Text = "";
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            register re = new register();
            re.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }    
    }
}
