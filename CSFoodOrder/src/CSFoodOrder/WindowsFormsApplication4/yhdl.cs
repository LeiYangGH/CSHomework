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
    public partial class yhdl : Form
    {
        public yhdl()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string my = "server=111.9.116.106;uid=sa;pwd=BKLserver@123!@#;database=ceshi";
            SqlConnection mysql = new SqlConnection(my);
 
            mysql.Open();
            string a= textBox1.Text;
            string b=textBox2.Text;
            string c = "select id,pswd from userinfo where id='" + textBox1.Text + "'and pswd='" + textBox2.Text + "'";
            SqlCommand d = new SqlCommand(c, mysql);

            SqlDataReader f;
            f = d.ExecuteReader();

            if (f.Read())
            {

                MessageBox.Show("登陆成功");
                
                zck g = new zck();
                g.Show();
                this.Hide();
                mysql.Close();             
            }

            else {

                MessageBox.Show("登陆失败,请重新输入！");
                mysql.Close();  
            
        }
            
            mysql.Close(); 
           
        
        } 
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        
            yhzc g = new yhzc();
            g.Show();
            
           
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= (int)'a' && (int)e.KeyChar <= (int)'z') || (((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8 || (int)e.KeyChar == 46))
            {
                e.Handled = false;
            }
            else e.Handled = true;


            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (textBox2.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(textBox2.Text, out oldf);
                    b2 = float.TryParse(textBox2.Text + e.KeyChar.ToString(), out f);
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

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 

     {

         this.button1.Focus();

     }
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

                this.button1.Focus();

            }
        }
    }
}
