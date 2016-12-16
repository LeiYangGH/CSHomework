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
    public partial class xzspzl : Form
    {
        public xzspzl()
        {
            InitializeComponent();
        }

        private void xzspzl_Load(object sender, EventArgs e)
        {

        }
            

        private void baocun_Click(object sender, EventArgs e)
        {
            string my = "server=111.9.116.106;uid=sa;pwd=BKLserver@123!@#;database=ceshi";

            SqlConnection mysql = new SqlConnection(my);


            string  spzl="SELECT HH,PM,ZJM,DW,JJ,ghs,llb,gg,tm,cd,bz,lsj from spzl where HH='"+vhh.Text+"'";
            SqlCommand d = new SqlCommand(spzl, mysql);
            mysql.Open();
            SqlDataReader f;
            f = d.ExecuteReader();
            if (f.Read())
            {
                MessageBox.Show("货号重复，请重新输入！");

                mysql.Close();
                return;

            }
            if (vhh.Text == "" )
                {
                    MessageBox.Show("请输入货号！");
                    mysql.Close();
                }
                if (vpm.Text == "")
                {
                    MessageBox.Show("请输入商品名称！");
                    mysql.Close();
                }

                if (vdw.Text == "")
                {
                    MessageBox.Show("请输入单位！");
                    mysql.Close();
                }
                if (vjj.Text == "")
                {
                    MessageBox.Show("请输入进价！");
                    mysql.Close();
                }
                if (vlsj.Text == "")
                {
                    MessageBox.Show("请输入零售价！");
                    mysql.Close();
                }

                else
                {
                    mysql.Close();
                    mysql.Open();
                    SqlCommand mysql1 = mysql.CreateCommand();


                   










                    mysql1.CommandText = "insert into spzl values(@HH,@PM,@ZJM,@DW,@JJ,@ghs,@llb,@gg,@tm,@cd,@bz,@lsj,@spbh)";
                    mysql1.Parameters.Add("@HH", SqlDbType.VarChar, 32, "hh");
                    mysql1.Parameters.Add("@PM", SqlDbType.VarChar, 32, "pm");
                    mysql1.Parameters.Add("@ZJM", SqlDbType.VarChar, 10, "zjm");
                    mysql1.Parameters.Add("@DW", SqlDbType.VarChar, 32, "dw");
                    mysql1.Parameters.Add("@JJ", SqlDbType.VarChar, 32, "jj");
                    mysql1.Parameters.Add("@GHS", SqlDbType.VarChar, 32, "ghs");
                    mysql1.Parameters.Add("@LLB", SqlDbType.VarChar, 32, "llb");
                    mysql1.Parameters.Add("@GG", SqlDbType.VarChar, 32, "gg");
                    mysql1.Parameters.Add("@TM", SqlDbType.VarChar, 32, "tm");
                    mysql1.Parameters.Add("@CD", SqlDbType.VarChar, 32, "cd");
                    mysql1.Parameters.Add("@BZ", SqlDbType.VarChar, 32, "bz");
                    mysql1.Parameters.Add("@LSJ", SqlDbType.VarChar, 32, "lsj"); 
                    mysql1.Parameters.Add("@SPBH", SqlDbType.Int, 32, "spbh");

                    mysql1.Parameters["@HH"].Value = vhh.Text;
                    mysql1.Parameters["@PM"].Value = vpm.Text;
                    mysql1.Parameters["@ZJM"].Value = vzjm.Text;
                    mysql1.Parameters["@DW"].Value = vdw.Text;
                    mysql1.Parameters["@JJ"].Value = vjj.Text;
                    mysql1.Parameters["@GHS"].Value = vghs.Text;
                    mysql1.Parameters["@LLB"].Value = vlb.Text;
                    mysql1.Parameters["@GG"].Value = vgg.Text;
                    mysql1.Parameters["@TM"].Value = vtm.Text;
                    mysql1.Parameters["@CD"].Value = vcd.Text;
                    mysql1.Parameters["@BZ"].Value = vbz.Text;
                    mysql1.Parameters["@LSJ"].Value = vlsj.Text;
                    mysql1.Parameters["@SPBH"].Value = vspbh.Text;
                    mysql1.ExecuteNonQuery();
                    mysql.Close();
                    MessageBox.Show("保存成功");
                    vhh.Enabled = false;  // ctextbox 输入窗口变灰色
                    vpm.Enabled = false;
                    vzjm.Enabled = false;
                    vdw.Enabled = false;
                    vjj.Enabled = false;
                    vghs.Enabled = false;
                    vlb.Enabled = false;
                    vgg.Enabled = false;
                    vtm.Enabled = false;
                    vcd.Enabled = false;
                    vbz.Enabled = false;
                    vlsj.Enabled = false;

                    vhh.Text = "";
                    vpm.Text = "";
                    vzjm.Text = "";
                    vdw.Text = "";
                    vjj.Text = "";
                    vghs.Text = "";
                    vlb.Text = "";
                    vgg.Text = "";
                    vtm.Text = "";
                    vcd.Text = "";
                    vbz.Text = "";
                    vlsj.Text = "";



                    this.xinzeng.Focus();

                
            }

            mysql.Close();



        }

        private void vhh_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (((int)e.KeyChar >= (int)'a' && (int)e.KeyChar <= (int)'z') || (((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8 || (int)e.KeyChar == 46))
            {
                e.Handled = false;
            }
            else e.Handled = true ;


            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (vhh.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(vhh.Text, out oldf);
                    b2 = float.TryParse(vhh.Text + e.KeyChar.ToString(), out f);
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

      
        private void vhh_TextChanged(object sender, EventArgs e)
        {
            
        }



        private void vzjm_TextChanged(object sender, EventArgs e)
        {

           

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            



        }

        private void vhh_KeyDown(object sender, KeyEventArgs e)
        {


                
                    if (e.KeyCode == Keys.Enter)
                    {

                        this.vpm.Focus();
           
                }
            
        }


       private void vhh_Leave(object sender, EventArgs e) 
        
        { 
            
       }


        private void vpm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.vzjm.Focus();

            }
        }

        private void vzjm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.vtm.Focus();

            }
        }

        private void vtm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.vgg.Focus();

            }
        }

        private void vgg_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void vgg_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                this.vdw.Focus();

            }



        }

        private void vdw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.vjj.Focus();

            }
        }

        private void vlsj_TextChanged(object sender, EventArgs e)
        {

        }

        private void vjj_TextChanged(object sender, EventArgs e)
        {

        }

        private void vjj_KeyPress(object sender, KeyPressEventArgs e)
        {

            string ts = "请输入进价";
            string ts1 = "";


            if (!(Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '.'))
            {
                e.Handled = true;
                jjts.Text = ts;

            }
            else 
            {
                jjts.Text = ts1;
            }

        }

        private void vjj_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.vlsj.Focus();

            }
        }

        private void vlsj_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.vlb.Focus();

            }
        }

        private void vlb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.vcd.Focus();

            }
        }

        private void vcd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.vghs.Focus();

            }
        }

        private void vghs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.vbz.Focus();

            }
        }

        private void vbz_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.baocun.Focus();

            }
        }

        private void vlsj_KeyPress(object sender, KeyPressEventArgs e)
        {

            string lsjts1 = "请输入零售价";
            string lsjts2="";
            if (!(Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '.'))
            {
                e.Handled = true;
                lsjts.Text = lsjts1;
            }

            else
            { 
            lsjts.Text=lsjts2;
            
            }
        }

        private void vcd_TextChanged(object sender, EventArgs e)
        {

        }

        private void xinzeng_Click(object sender, EventArgs e)
        {

            vhh.Text = "";
            vpm.Text = "";
            vzjm.Text = "";
            vdw.Text = "";
            vjj.Text = "";
            vghs.Text = "";
            vlb.Text = "";
            vgg.Text = "";
            vtm.Text = "";
            vcd.Text = "";
            vbz.Text = "";
            vlsj.Text = "";
            vhh.Enabled = true;  // ctextbox 输入窗口变灰色
            vpm.Enabled = true;
            vzjm.Enabled = true;
            vdw.Enabled = true;
            vjj.Enabled = true;
            vghs.Enabled = true;
            vlb.Enabled = true;
            vgg.Enabled = true;
            vtm.Enabled = true;
            vcd.Enabled = true;
            vbz.Enabled = true;
            vlsj.Enabled = true;
            this.vhh.Focus();
        }

        private void xinzeng_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void xinzeng_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                this.vhh.Focus();

            }
            
        }

        private void vtm_KeyPress(object sender, KeyPressEventArgs e)
        {
           if (((int)e.KeyChar >= (int)'a' && (int)e.KeyChar <= (int)'z') || (((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8 || (int)e.KeyChar == 46))
            {
                e.Handled = false;
            }
            else e.Handled = true ;


            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (vtm.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(vhh.Text, out oldf);
                    b2 = float.TryParse(vhh.Text + e.KeyChar.ToString(), out f);
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

        private void baocun_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.xinzeng.Focus();

            }
        }

        private void baocun_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void vdw_TextChanged(object sender, EventArgs e)
        {

        }


        public string c { get; set; }

        private void vspbh_TextChanged(object sender, EventArgs e)
        {
            vspbh.Enabled = false;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SqlConnection connspbh = new SqlConnection("server=111.9.116.106;uid=sa;pwd=BKLserver@123!@#;database=ceshi");
            connspbh.Open();
            string mmmmm = "select max(spbh) from spzl";
            SqlCommand cmd = new SqlCommand(mmmmm, connspbh);
            cmd.ExecuteScalar().ToString();//得出的结果等于3


            if (!cmd.ExecuteScalar().ToString().Equals("") && !cmd.ExecuteScalar().ToString().Equals(null))
            {
                vspbh.Text = (Convert.ToInt32(cmd.ExecuteScalar().ToString()) + 1).ToString();

                connspbh.Close();
                timer1.Enabled = false;
                
            }
            else
            {

                vspbh.Text = "1";
                timer1.Enabled = false;

            }
        
            connspbh.Close(); 
        }
    }
}
