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

        public string U;
        public string P;
        public string Q;

        private void Admin_Load(object sender, EventArgs e)
        {
            if (mID != "")
            {

                DataTable dt = new DataTable();
                string tableName = Admin_List.isEditingAdminTable ? "TB_Admin" : "[TB_Employee]";
                dt = DBHelper.GetDate(string.Format("select * from {0} where ID=", tableName) + mID).Tables[0];
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
                string tableName = Admin_List.isEditingAdminTable ? "TB_Admin" : "[TB_Employee]";

                if (DBHelper.GetDate(string.Format("select * from {0} where UserName='", tableName) + textBox1.Text + "'").Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("用户名型重复");
                    return;
                }
                DBHelper.Exec(string.Format("INSERT INTO {0} (UserName,PWD,QX  ) VALUES ('", tableName) + textBox1.Text + "','" + textBox2.Text + "','" + this.comboBox1.Text + "')");
            }
            else
            {
                //修改
                if (Q == this.comboBox1.Text.Trim())
                    return;
                if (this.comboBox1.Text.Trim() == "管理员")
                {
                    DBHelper.Exec("INSERT INTO TB_Admin (UserName,PWD,QX  ) VALUES ('" + U + "','" + P + "','" + this.comboBox1.Text + "')");
                    DBHelper.Exec("delete from [TB_Employee] where UserName='" + U + "'");
                }
                else
                {
                    DBHelper.Exec("INSERT INTO [TB_Employee] (UserName,PWD,QX  ) VALUES ('" + U + "','" + P + "','" + this.comboBox1.Text + "')");
                    DBHelper.Exec("delete from TB_Admin where UserName='" + U + "'");
                }



            }
            this.Close();
        }
    }
}
