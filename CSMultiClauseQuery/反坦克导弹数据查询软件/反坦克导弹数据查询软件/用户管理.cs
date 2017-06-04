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
    public partial class 用户管理 : Form
    {
        public 用户管理()
        {
            InitializeComponent();
        }

        private void btlogin_Click(object sender, EventArgs e)
        {
            string getpassword;
            string getmanager;
            string mypassword;
            getmanager = manager.Text;
            getpassword = password.Text;
            string SQLstr = "select*from gl where (((gl.name)='" + getmanager + "'))";
            manager.Text = "";
            password.Text = "";
            OleDbDataAdapter mycmd = new OleDbDataAdapter(SQLstr, "provider=microsoft.jet.oledb.4.0;" + "data source =dl.mdb");
            DataSet ds = new DataSet();
            DataTable mytable = new DataTable();
            DataRow myrow;
            mycmd.Fill(ds);
            mytable = ds.Tables[0];
            try
            {
                myrow = mytable.Rows[0];
            }
            catch
            {
                MessageBox.Show("没有此用户", "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            mypassword = myrow[1].ToString();
            if (getpassword == mypassword)
            {
                用户 form = new 用户();
                form.Show();
                this.Hide();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            模糊查询 form = new 模糊查询();
            form.Show();
            this.Hide();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Form5 form = new Form5();
            form.Show();
            this.Hide();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            增加 form = new 增加();
            form.Show();
            this.Hide();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            改删 form = new 改删();
            form.Show();
            this.Hide();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            数据展示 form = new 数据展示();
            form.Show();
            this.Hide();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
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
    }
}
