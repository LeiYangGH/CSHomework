using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        
       
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkshuru())
            {
                String username = txtname.Text.Trim();
                String password = txtpwd.Text.Trim();

                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("select count(*)from User where zh='{0}'and mm='{1}'", username, password);

                SqlConnection myconnection = new SqlConnection();

                SqlCommand mycommand = new SqlCommand(sb.ToString(), myconnection);

                //SqlCommand mycommand = new SqlCommand("select count(*)from User where zh='" + this.txtname.Text.ToString() + "'and mm='" + this.txtpwd.Text + "'", myconnection);
                
               myconnection.Open();

                //mycommand.Connection.Open();
            
                int num = (int)mycommand.ExecuteScalar();
                //mycommand.Connection.Close();
                if (num == 1)
                {                   
                    Form2 f2 = new Form2();
                    this.Hide();
                    f2.Show();

                }
                else
                {
                    MessageBox.Show("登录失败！");
                }

            }
        }

        private bool checkshuru()
        {
            if (txtname.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("请输入用户名！");
                txtname.Focus();
                return false;
            }
            else if (txtpwd.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("请输入密码！");
                txtname.Focus();
                return false;
            }
            
            else { return true; }

        }   
    }
}