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
    public partial class Admin : Form
    {
        public Admin()
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
        private void Admin_Load(object sender, EventArgs e)
        {
            if (mID != "")
            {

                DataTable dt = new DataTable();
                dt = DBHelper.GetDate("select * from TB_Admin where ID=" + mID).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    this.textBox1.Text = dt.Rows[0]["UserName"].ToString();
                    this.textBox2.Text = dt.Rows[0]["PWD"].ToString();
                    this.comboBox1.Text = dt.Rows[0]["QX"].ToString();

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
                if (this.textBox1.Text == "")
                {
                    MessageBox.Show("用户名不能为空");
                    return;
                }
                if (DBHelper.GetDate("select * from TB_Admin where UserName='" + textBox1.Text + "'").Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("用户名型重复");
                    return;
                }
                DBHelper.Exec("INSERT INTO TB_Admin (UserName,PWD,QX  ) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + this.comboBox1.Text + "')");
            }
            else
            {

                //修改
                DBHelper.Exec("UPDATE TB_Admin set UserName = '" + textBox1.Text + "',PWD = '" + textBox2.Text + "',QX ='" + this.comboBox1.Text + "' WHERE ID=" + mID);

            }
            this.Close();
        }
    }
}
