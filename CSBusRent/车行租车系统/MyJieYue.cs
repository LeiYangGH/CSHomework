using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 图书馆管理系统
{
    public partial class MyJieYue : Form
    {
        public MyJieYue()
        {
            InitializeComponent();
        }
        private string mID = "";
        public string ID
        {
            get
            {
                return mID;
            }
            set
            {
                mID = value;
            }
        }
        private void MyJieYue_Load(object sender, EventArgs e)
        {

            string SQL = "select * from TB_Book";
            DataSet ds = DBHelper.GetDate(SQL);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "BianHao";
            comboBox1.ValueMember = "ID";

          

            string SQL1 = "select * from TB_JieYueZhe where UserName='" + UserInfo.getUserName + "'";
            DataSet ds1 = DBHelper.GetDate(SQL1);
            comboBox2.Text = ds1.Tables[0].Rows[0]["UserName"].ToString();
            this.textBox6.Text = ds1.Tables[0].Rows[0]["XingMing"].ToString();
            comboBox2.Enabled = false;
            this.textBox6.Enabled = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mID == "")
            {
                string SQL = "INSERT INTO TB_JieYue (BBianHao,BMingCheng,ZuoZhe,ShiJian,ChuBanShe,BeiZhu,JieYueZheng,XingMing,JieYueTime,State) VALUES ('" + this.comboBox1.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + this.textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + comboBox2.Text + "','" + textBox6.Text + "','" + DateTime.Now.ToString() + "','借阅中')";
                DBHelper.Exec(SQL);
                MessageBox.Show("操作成功");

            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

          
                        
            string SQL = "select * from   TB_Book where BianHao='" + this.comboBox1.Text + "'";
            DataSet ds = DBHelper.GetDate(SQL);
             this.textBox1.Text = ds.Tables[0].Rows[0]["MingCheng"].ToString();
            this.textBox2.Text = ds.Tables[0].Rows[0]["ZuoZhe"].ToString();
            this.textBox3.Text = ds.Tables[0].Rows[0]["RiQi"].ToString();
            this.textBox4.Text = ds.Tables[0].Rows[0]["ChuBanShe"].ToString();
            this.textBox5.Text = ds.Tables[0].Rows[0]["BeiZhu"].ToString();
            }
            catch
            {


            }
        }

 
    }
}
