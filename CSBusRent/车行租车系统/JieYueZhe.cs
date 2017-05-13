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
    public partial class JieYueZhe : Form
    {
        public JieYueZhe()
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
        private void JieYue_Load(object sender, EventArgs e)
        {
            if (mID != "")
            {

                DataTable dt = new DataTable();
                dt = DBHelper.GetDate("select * from TB_User where ID=" + mID).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    this.textBox1.Text = dt.Rows[0]["UserName"].ToString();
                    this.textBox2.Text = dt.Rows[0]["PWD"].ToString();
                    this.comboBox1.Text = dt.Rows[0]["Sex"].ToString();
                    this.textBox3.Text = dt.Rows[0]["XingMing"].ToString();
                    this.textBox4.Text = dt.Rows[0]["tel"].ToString();
                    this.textBox5.Text = dt.Rows[0]["IDCard"].ToString();
                    
                }
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
                
                DBHelper.Exec("INSERT INTO TB_User (UserName,PWD,XingMing,Sex,tel,IDCard) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + this.comboBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text  + "')");
            }
            else
            {

                //修改
                DBHelper.Exec("UPDATE TB_User set UserName = '" + textBox1.Text + "',PWD = '" + textBox2.Text + "',Sex ='" + this.comboBox1.Text + "',XingMing = '" + textBox3.Text + "',tel = '" + textBox4.Text + "',IDCard = '" + textBox5.Text + "' WHERE ID=" + mID);

            }
            this.Close();
        }
    }
}
