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

namespace BigJob
{
    public partial class userInfoSearch : Form
    {
        public userInfoSearch()
        {
            InitializeComponent();
        }

        database link = new database();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = string.Format("select * from S_users where User_name='{0}'", textBox1.Text.Trim()); // 这里需要实现模糊查找

                OleDbDataReader dr = link.UpdateDataBase2(sql);

                if (dr.Read())//存在对应项
                {
                    textBox3.Text = dr["User_code"].ToString();
                    textBox3.Text = dr["User_name"].ToString();
                    textBox4.Text = dr["User_per"].ToString();
                }
                else
                {
                    MessageBox.Show("对不起，没有该用户信息");
                }
            }
            catch
            {
                textBox1.Text = "";
            }
        }
    }
}
