using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;//添加引用


namespace Access操作范例
{
    public partial class Form1 : Form
    {
        private DataTable dt = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=数据文件夹//AutoDesk.mdb";   //数据库文件名

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FillGrid();
        }

        //连接数据库表1并显示到DataGridView1中
        private void FillGrid()
        {
            this.dt.Clear();
            OleDbConnection myConn1 = new OleDbConnection(connStr); //连接到数据库
            string myStr1 = "select[编号],[姓名],[信息] from [表1]";//选择数据表
            OleDbDataAdapter myAda1 = new OleDbDataAdapter(myStr1, myConn1); //打开数据表
            myAda1.Fill(this.dt);//将表中数据填充到记录集中
            dataGridView1.DataSource = this.dt; //设定显示控件的数据源
        }

        private bool GetInput(out string name, out string info)
        {
            string n = this.txtName.Text.Trim();
            string i = this.txtInfo.Text.Trim();
            name = n;
            info = i;
            if (string.IsNullOrWhiteSpace(n) ||
               string.IsNullOrWhiteSpace(i))
            {
                MessageBox.Show("空值没有任何意义！");
                return false;
            }
            else
                return true;
        }

        //向数据库表1中添加数据
        private void AddtoAccess1()
        {
            string name = null, info = null;
            if (!GetInput(out name, out info))
                return;
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();
                string sql = "insert into [表1] ([姓名],[信息]) values (@name,@info)";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@info", info);
                cmd.ExecuteNonQuery();
            }
            this.FillGrid();
        }

        //删除DataGridView1选中行的数据，并更新数据表1
        private void DeleteAccess1()
        {
            OleDbConnection myConn1 = new OleDbConnection(connStr);
            DataGridViewRow selRow = this.GetSelectedRow();
            if (selRow == null)
            {
                MessageBox.Show("请先选中要删除的数据行");
                return;
            }
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();
                string sql = "delete from [表1] where [编号] = @id";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", selRow.Cells[0].Value);
                cmd.ExecuteNonQuery();
            }
            this.FillGrid();
        }

        //将DataGridView1中的数据保存到数据表1
        private void SavetoAccess1()
        {
            dataGridView1.EndEdit();
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    string id = dataGridView1.Rows[i].Cells["编号"].Value.ToString();
                    string sql = "update [表1] set [姓名] = @name, [信息] = @info where [编号] = @id";
                    DataGridViewRow row = dataGridView1.Rows[i];
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", row.Cells[1].Value);
                    cmd.Parameters.AddWithValue("@info", row.Cells[2].Value);
                    cmd.Parameters.AddWithValue("@id", row.Cells[0].Value);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("ok");
            }
        }

        DataGridViewRow GetSelectedRow()
        {
            if (dataGridView1.SelectedRows == null || dataGridView1.SelectedRows.Count == 0)
                return null;
            else
                return dataGridView1.SelectedRows[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SavetoAccess1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddtoAccess1();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DeleteAccess1();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string name = this.txtNameSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("请先输入查询名称");
                return;
            }
            if (this.dt == null || this.dt.Rows.Count == 0)
            {
                MessageBox.Show("请先加载表格");
                return;
            }
            DataRow row = this.dt.Rows.OfType<DataRow>()
                .FirstOrDefault(x => x[1].ToString() == name);
            string info = "";
            if (row != null)
                info = row[2].ToString();
            this.lblInfo.Text = info;
        }









    }
}
