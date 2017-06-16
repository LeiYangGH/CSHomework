using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigJob
{
    public partial class userInfoAdd : Form
    {
        public userInfoAdd()
        {
            InitializeComponent();
        }
        database link = new database();
        userInfo ui = new userInfo();
        private void userInfoAdd_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           // string sql = "insert into S_users(User_code,User_name,User_per_code) values('" + textBox3.Text + "'," + "'" + textBox1.Text + "'," + "'" + textBox2.Text +  "')";   //以加号分隔   
           // link.UpdateDataBase(sql);
            MessageBox.Show("添加成功！");
            ui.userInfo_Load(this, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
