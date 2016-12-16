using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication4
{
    public partial class yhzc : Form
    {
        public yhzc()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string my = "server=111.9.116.106;uid=sa;pwd=BKLserver@123!@#;database=ceshi";

            SqlConnection mysql =new SqlConnection(my);

            string c = "select id,pswd from userinfo where id='" + textBox1.Text + "'";
            SqlCommand d = new SqlCommand(c, mysql);
            mysql.Open();
            SqlDataReader f;
            f = d.ExecuteReader();
            if (f.Read())
            {
                MessageBox.Show("账号重复，请重新输入！");

                mysql.Close();

            }

            else
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("请输入账号！");
                    mysql.Close();
                }
                if (textBox3.Text == "")
                {
                    MessageBox.Show("请输入密码！");
                    mysql.Close();
                }

                else
                {
                    mysql.Close();
                    mysql.Open();
                    SqlCommand mysql1 = mysql.CreateCommand();
                    mysql1.CommandText = "insert into userinfo values(@id,@name,@age,@pswd)";
                    mysql1.Parameters.Add("@id", SqlDbType.VarChar, 32, "id");
                    mysql1.Parameters.Add("@name", SqlDbType.VarChar, 32, "name");
                    mysql1.Parameters.Add("@age", SqlDbType.Int, 10, "age");
                    mysql1.Parameters.Add("@pswd", SqlDbType.VarChar, 32, "pswd");
                    mysql1.Parameters["@id"].Value = textBox1.Text;
                    mysql1.Parameters["@name"].Value = textBox3.Text;
                    mysql1.Parameters["@age"].Value = textBox4.Text;
                    mysql1.Parameters["@pswd"].Value = textBox2.Text;
                    mysql1.ExecuteNonQuery();
                    mysql.Close();
                    MessageBox.Show("注册成功");
                   
                    this.Close();


                }
            }   
     
            mysql.Close();

            
            }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (((int)e.KeyChar >= (int)'a' && (int)e.KeyChar <= (int)'z') || (((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8 || (int)e.KeyChar == 46))
            {
                e.Handled = false;
            }
            else e.Handled = true;


            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (textBox1.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(textBox1.Text, out oldf);
                    b2 = float.TryParse(textBox1.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= (int)'a' && (int)e.KeyChar <= (int)'z') || (((int)e.KeyChar > 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8 || (int)e.KeyChar == 46))
            {
                e.Handled = false;
            }
            else e.Handled = true;


            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (textBox1.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(textBox1.Text, out oldf);
                    b2 = float.TryParse(textBox1.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.textBox2.Focus();

            }
        }
      

        private void textBox2_KeyDown_1(object sender, KeyEventArgs e)
        {

        
         if (e.KeyCode == Keys.Enter)
            {

                this.textBox3.Focus();

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Enter)
            {

                this.textBox4.Focus();

            }




        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.button1.Focus();

            }
        }
    }
}
        
    

