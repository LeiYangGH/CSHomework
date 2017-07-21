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
        public Form1()
        {
            InitializeComponent();
        }

        string Accessfile = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=数据文件夹//AutoDesk.mdb";   //数据库文件名

        private void Form1_Load(object sender, EventArgs e)
        {
            //不显示datagridview的最后一行
            dataGridView1.AllowUserToAddRows = false;
            //将Datagridview设置为列宽自适应
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        }

        //连接数据库表1并显示到DataGridView1中
        private void ConnAccess1()
        {
            OleDbConnection myConn1 = new OleDbConnection(Accessfile); //连接到数据库
            string myStr1 = "select[编号],[姓名],[信息] from [表1]";//选择数据表
            OleDbDataAdapter myAda1 = new OleDbDataAdapter(myStr1, myConn1); //打开数据表
            DataTable mydt1 = new DataTable(); //声明一个记录集
            myAda1.Fill(mydt1);//将表中数据填充到记录集中
            dataGridView1.DataSource = mydt1; //设定显示控件的数据源
            myConn1.Close();//断开数据库连接
            foreach (DataGridViewRow row in this.dataGridView1.Rows)  //编号自动排序
            {
                row.Cells[0].Value = (row.Index+1).ToString();
            }
        }

        //向数据库表1中添加数据
        private void AddtoAccess1()
        {
            OleDbConnection myConn1 = new OleDbConnection(Accessfile); //连接到数据库
            myConn1.Open();

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("空值没有任何意义！");
            }
            else
            {
                string insStr1 = "insert into [表1] ([姓名],[信息]) values ('"
                    + textBox1.Text + "', '"
                    + textBox2.Text + "')";

                OleDbCommand myCmd1 = new OleDbCommand(insStr1, myConn1);
                myCmd1.ExecuteNonQuery();
                myConn1.Close();
                ConnAccess1();
            }
        }

        //删除DataGridView1选中行的数据，并更新数据表1
        private void DeleteAccess1()
        {
            OleDbConnection myConn1 = new OleDbConnection(Accessfile);
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("请先选中要删除的数据行");
            }
            else
            {

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    myConn1.Open();
                    string idname1 = dataGridView1[0,i].Value.ToString();
                    //string idname1 = dataGridView1[0,i].Value.ToString();
                    string delStr1 = "delete from [表1] where [编号]=" + idname1 + " ";
                    OleDbCommand myCmd1 = new OleDbCommand(delStr1, myConn1);
                    myCmd1.ExecuteNonQuery();
                    myConn1.Close();
                }
                ConnAccess1();
            }
        }

        //将DataGridView1中的数据保存到数据表1
        private void SavetoAccess1()
        {
            dataGridView1.EndEdit();
            OleDbConnection myConn1 = new OleDbConnection(Accessfile);
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                myConn1.Open();
                string idname1 = dataGridView1.Rows[i].Cells["编号"].Value.ToString();
                string updateStr1 = " update [表1] set [姓名] ='" + dataGridView1[1, i].Value + "',[信息] ='" + dataGridView1[2, i].Value + "' where [编号]=" + idname1 + "";
                OleDbCommand myCmd1 = new OleDbCommand(updateStr1, myConn1);
                myCmd1.ExecuteNonQuery();
                myConn1.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnAccess1();
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

        }









    }
}
