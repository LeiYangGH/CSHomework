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
using System.Data.SqlClient;
using System.Threading;

namespace 反坦克导弹数据查询软件
{
    public partial class 增加 : Form
    {
        
        public 增加()
        {
            InitializeComponent();
        }

       
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
           
        }

        private void BtAdd_Click(object sender, EventArgs e)
        {
           
        }

        private void BtSave_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            模糊查询 form = new 模糊查询();
            form.Show();
            this.Hide();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Form5 form = new Form5();
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            用户管理 form = new 用户管理();
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

        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string connStr, insertCmd;
            connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=DD.mdb";
            insertCmd = "Insert Into AKD (导弹名称,国家,导弹弹长,导弹弹径,导弹翼展,导弹弹重,导弹最小射程,导弹最大射程,飞行速度,破甲厚度,战斗部,制导方式,导引头,动力装置,命中概率,发射载体,使用条件,生产厂家) Values('" + 
                导弹名称.Text.Replace("'", "''") + "','" +
                国家.Text.Replace("'", "''") + "','" + 
                导弹弹长.Text.Replace("'", "''") + "','" + 
                导弹弹径.Text.Replace("'", "''") + "','" + 
                导弹翼展.Text.Replace("'", "''") + "','" + 
                导弹弹重.Text.Replace("'", "''") + "','" + 
                导弹最小射程.Text.Replace("'", "''") + "','" + 
                导弹最大射程.Text.Replace("'", "''") + "','" + 
                飞行速度.Text.Replace("'", "''") + "','" + 
                破甲厚度.Text.Replace("'", "''") + "','" + 
                战斗部.Text.Replace("'", "''") + "','" + 
                制导方式.Text.Replace("'", "''") + "','" + 
                导引头.Text.Replace("'", "''") + "','" + 
                动力装置.Text.Replace("'", "''") + "','" + 
                命中概率.Text.Replace("'", "''") + "','" + 
                发射载体.Text.Replace("'", "''") + "','" + 
                使用条件.Text.Replace("'", "''") + "','" + 
                生产厂家.Text.Replace("'", "''") + "')";
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
                MessageBox.Show("添加发生错误检查参数是否正确");
                cmd.Connection.Close();
                return;
            }
            conn.Close();
        }
    }
}
