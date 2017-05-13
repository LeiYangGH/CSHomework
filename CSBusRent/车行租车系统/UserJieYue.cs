using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 车行租车系统
{
    public partial class UserJieYue : Form
    {
        public UserJieYue()
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
        private void UserJieYue_Load(object sender, EventArgs e)
        {

            string SQL = "select * from TB_CheLiang";
            DataSet ds = DBHelper.GetDate(SQL);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "ChePai";
            comboBox1.ValueMember = "ID";

            comboBox2.Text = UserInfo.getUserName;
            this.comboBox2.Enabled = false; GetInfo();

        }
        public void GetInfo()
        {
            try
            {

                string SQL = "select * from TB_User where UserName='" + this.comboBox2.Text + "'";
                DataSet ds = DBHelper.GetDate(SQL);
                this.textBox6.Text = ds.Tables[0].Rows[0]["XingMing"].ToString();
                this.textBox6.Enabled = false;
            }
            catch
            {


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mID == "")
            {
                string SQL = "INSERT INTO TB_JieYue (ChePai,PingPai,ZuJIn,YaSe,Memo,LeiXing,UserName,XingMing,State) VALUES ('" + this.comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + this.textBox4.Text + "','" + textBox7.Text + "','" + textBox1.Text + "','" + comboBox2.Text + "','" + textBox6.Text + "','租借中')";
                DBHelper.Exec(SQL);
                MessageBox.Show("操作成功");

            }

        }
        public static string Img = "";
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

          
                        
            string SQL = "select * from   TB_CheLiang where BianHao='" + this.comboBox1.Text + "'";
            DataTable dt = DBHelper.GetDate(SQL).Tables[0];
            this.textBox1.Text = dt.Rows[0]["LeiXing"].ToString();
            this.textBox2.Text = dt.Rows[0]["PingPai"].ToString();
            this.comboBox1.Text = dt.Rows[0]["ChePai"].ToString();
            this.textBox3.Text = dt.Rows[0]["ZuJIn"].ToString();
            this.textBox4.Text = dt.Rows[0]["YaSe"].ToString();
            this.textBox7.Text = dt.Rows[0]["Memo"].ToString();
            this.textBox1.ReadOnly = true;
            Img = dt.Rows[0]["PIC"].ToString();
            Img = Application.StartupPath + Img;
            this.pictureBox1.Image = System.Drawing.Image.FromFile(Img); 

            }
            catch
            {


            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        { try
            {

            string SQL = "select * from TB_User where UserName='" + this.comboBox2.Text + "'";
            DataSet ds = DBHelper.GetDate(SQL);
            this.textBox6.Text = ds.Tables[0].Rows[0]["XingMing"].ToString();
            }
        catch
        {


        }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {



                string SQL = "select * from   TB_CheLiang where ChePai='" + this.comboBox1.Text + "'";
                DataTable dt = DBHelper.GetDate(SQL).Tables[0];
                this.textBox1.Text = dt.Rows[0]["LeiXing"].ToString();
                this.textBox2.Text = dt.Rows[0]["PingPai"].ToString();
                this.comboBox1.Text = dt.Rows[0]["ChePai"].ToString();
                this.textBox3.Text = dt.Rows[0]["ZuJIn"].ToString();
                this.textBox4.Text = dt.Rows[0]["YaSe"].ToString();
                this.textBox7.Text = dt.Rows[0]["Memo"].ToString();
                this.textBox1.ReadOnly = true;
                Img = dt.Rows[0]["PIC"].ToString();
                Img = Application.StartupPath + Img;
                this.pictureBox1.Image = System.Drawing.Image.FromFile(Img);

            }
            catch
            {


            }
        }
    }
}
