using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication4
{
    public partial class diancai : Form
    {
        public diancai()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void cpfl6_Click(object sender, EventArgs e)
        {

        }
        
        private string dcxdxx;
        public string dcxdxy
        {
            get { return dcxdxx; }
            set { dcxdxx = value; }
        }
        private void diancai_Load(object sender, EventArgs e)
        {
            dcxdczh.Text = this.dcxdxy;
           

            DataTable dt = new DataTable();
            String sql = "Server=111.9.116.106;Database=ceshi;uid=sa;pwd=BKLserver@123!@#";
            SqlConnection sssqlconn = new SqlConnection(sql);
            sssqlconn.Open();
            SqlCommand comm = new SqlCommand();
            comm.CommandText = "select lbmc from splb ";
            comm.Connection = sssqlconn;
            string mmmmm = "select count(distinct lbid) from splb";
            SqlCommand cmd = new SqlCommand(mmmmm, sssqlconn);
            cmd.ExecuteScalar().ToString();
            int x = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            using (SqlDataReader dr = comm.ExecuteReader())
            {
                dt.Clear();
                dt.Load(dr);
                sssqlconn.Close();
                sssqlconn.Dispose();
            }
            try
            {
                if (dt.Rows[0]["lbmc"].ToString() == "")
                {
                    tapcpfl.Parent = null;//隐藏
                }
                else
                {
                    cpfl1.Parent = tapcpfl;//显示
                    cpfl1.Text = dt.Rows[0]["lbmc"].ToString();
                }
                if (dt.Rows[1]["lbmc"].ToString() == "")
                {
                    tapcpfl.Parent = null;//隐藏
                }
                else
                {
                    cpfl2.Parent = tapcpfl;//显示
                    cpfl2.Text = dt.Rows[1]["lbmc"].ToString();
                }
                if (dt.Rows[2]["lbmc"].ToString() == "")
                {
                    tapcpfl.Parent = null;//隐藏
                }
                else
                {
                    cpfl3.Parent = tapcpfl;//显示
                    cpfl3.Text = dt.Rows[2]["lbmc"].ToString();
                }
                if (dt.Rows[3]["lbmc"].ToString() == "")
                {
                    tapcpfl.Parent = null;//隐藏
                }
                else
                {
                    cpfl4.Parent = tapcpfl;//显示
                    cpfl4.Text = dt.Rows[3]["lbmc"].ToString();
                }
                if (dt.Rows[4]["lbmc"].ToString() == "")
                {
                    tapcpfl.Parent = null;//隐藏
                }
                else
                {
                    cpfl5.Parent = tapcpfl;//显示
                    cpfl5.Text = dt.Rows[4]["lbmc"].ToString();
                }
                if (dt.Rows[5]["lbmc"].ToString() == "")
                {

                    tapcpfl.Parent = null;//隐藏

                }
                else
                {

                    cpfl6.Parent = tapcpfl;//显示
                    cpfl6.Text = dt.Rows[5]["lbmc"].ToString();
                }

            }


            catch (Exception ex)
            {


            }
           
        //分类1    
            string ssb;
            string sssb;
            string ssssb; 
            DataTable dtt = new DataTable();
            String ssql = "Server=111.9.116.106;Database=ceshi;uid=sa;pwd=BKLserver@123!@#";
            SqlConnection sqlconn = new SqlConnection(ssql);
            sqlconn.Open();
            SqlCommand cocc = new SqlCommand();
            cocc.CommandText = "select hh,pm,lsj from spzl a left join splb b on a.llb=b.lbid where b.lbmc='"+ cpfl1.Text+ "'";
            cocc.Connection = sqlconn;
            string cccc = "select count(distinct spbh) from spzl a left join splb b on a.llb=b.lbid where b.lbmc='"+cpfl1.Text+"'";
            SqlCommand cmddd = new SqlCommand(cccc, sqlconn);
            cmddd.ExecuteScalar().ToString();
            int xm = Convert.ToInt32(cmddd.ExecuteScalar().ToString());
            using (SqlDataReader drr = cocc.ExecuteReader())
            {
                dtt.Clear();
                dtt.Load(drr);
                sqlconn.Close();
                sqlconn.Dispose();
            }
            try
            {
                for (int ii = 0; ii < xm; ii++)
                {
                    UserControl1 tb = new UserControl1();
                    //设定位置
                    tb.Top = 10 + ii * 58;
                    tb.BackColor = Color.DeepSkyBlue;
                    tb.Size = new Size(80, 55);

                    ssb = dtt.Rows[ii]["hh"].ToString();
                    sssb = dtt.Rows[ii]["pm"].ToString();
                    ssssb = dtt.Rows[ii]["lsj"].ToString();
                    tb.labid = ssb;
                    tb.lablsj = ssssb;
                    tb.labname = sssb;
                    this.flowLayoutPanel1.Controls.Add(tb);
                    tb.Click += (object sne, EventArgs ed) =>
                    {
                        tb.BackColor = Color.Maroon;
                        string[] str = { tb.labid, tb.labname, tb.lablsj, "1" };
                        this.dcxdjm.Items.Add(new ListViewItem(str));
                        
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); ;
            }
            //分类2;
            string ssb1;
            string sssb1;
            string ssssb1;
            DataTable dttr = new DataTable();
            String ssql1 = "Server=111.9.116.106;Database=ceshi;uid=sa;pwd=BKLserver@123!@#";
            SqlConnection sqlconn111 = new SqlConnection(ssql1);
            sqlconn111.Open();
            SqlCommand cocc1 = new SqlCommand();
            cocc1.CommandText = "select hh,pm,lsj from spzl a left join splb b on a.llb=b.lbid where b.lbmc='" + cpfl2.Text + "'";
            cocc1.Connection = sqlconn111;
            string cccc11 = "select count(distinct spbh) from spzl a left join splb b on a.llb=b.lbid where b.lbmc='"+cpfl2.Text + "'";
            SqlCommand cmddd1 = new SqlCommand(cccc11, sqlconn111);
            cmddd1.ExecuteScalar().ToString();
            int xmm = Convert.ToInt32(cmddd1.ExecuteScalar().ToString());
            using (SqlDataReader drr1 = cocc1.ExecuteReader())
            {
                dttr.Clear();
                dttr.Load(drr1);
                sqlconn111.Close();
                sqlconn111.Dispose();
            }
            try
            {
                for (int iii = 0; iii < xmm; iii++)
                {
                    UserControl1 tb1 = new UserControl1();
                    //设定位置
                    tb1.Top = 15 + iii * 58;
                    tb1.BackColor = Color.DeepSkyBlue; 
                    tb1.Size = new Size(80, 55);
                    ssb1 = dttr.Rows[iii]["hh"].ToString();
                    sssb1 = dttr.Rows[iii]["pm"].ToString();
                    ssssb1 = dttr.Rows[iii]["lsj"].ToString();
                    tb1.labid = ssb1;
                    tb1.lablsj = ssssb1;
                    tb1.labname = sssb1;
                    this.flowLayoutPanel2.Controls.Add(tb1);//动态控件生成
                    tb1.Click += (object sne, EventArgs ed) =>
                    {  //将控件的赋予给 listview 控件
                        tb1.BackColor = Color.Maroon;
                        string[] str1 = { tb1.labid, tb1.labname, tb1.lablsj, "1" };
                        this.dcxdjm.Items.Add(new ListViewItem(str1)); //将控件的赋予给 listview 控件 
                       
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); ;
            }
            //分类3;
            string ssbx;
            string sssbx;
            string ssssbx;
            DataTable dttrx = new DataTable();
            String ssql1x = "Server=111.9.116.106;Database=ceshi;uid=sa;pwd=BKLserver@123!@#";
            SqlConnection sqlconn111x = new SqlConnection(ssql1x);
            sqlconn111x.Open();
            SqlCommand cocc1x = new SqlCommand();
            cocc1x.CommandText = "select hh,pm,lsj from spzl a left join splb b on a.llb=b.lbid where b.lbmc='" + cpfl3.Text + "'";
            cocc1x.Connection = sqlconn111x;
            string cccc11x = "select count(distinct spbh) from spzl a left join splb b on a.llb=b.lbid where b.lbmc='" + cpfl3.Text + "'";
            SqlCommand cmddd1x = new SqlCommand(cccc11x, sqlconn111x);
            cmddd1x.ExecuteScalar().ToString();
            int xmmx = Convert.ToInt32(cmddd1x.ExecuteScalar().ToString());
            using (SqlDataReader drr1x = cocc1x.ExecuteReader())
            {
                dttrx.Clear();
                dttrx.Load(drr1x);
                sqlconn111x.Close();
                sqlconn111x.Dispose();
            }
            try
            {
                for (int iiix = 0; iiix < xmmx; iiix++)
                {
                    UserControl1 tb1x = new UserControl1();
                    //设定位置
                    tb1x.Top = 10 + iiix * 58;
                    tb1x.BackColor = Color.DeepSkyBlue;
                    tb1x.Size = new Size(80, 55);

                    ssbx = dttr.Rows[iiix]["hh"].ToString();
                    sssbx = dttr.Rows[iiix]["pm"].ToString();
                    ssssbx = dttr.Rows[iiix]["lsj"].ToString();
                    tb1x.labid = ssbx;
                    tb1x.lablsj = ssssbx;
                    tb1x.labname = sssbx;
                    this.flowLayoutPanel3.Controls.Add(tb1x);
                    tb1x.Click += (object sne, EventArgs ed) =>
                    {
                        tb1x.BackColor = Color.Maroon;
                        string[] str1x = { tb1x.labid, tb1x.labname, tb1x.lablsj, "1" };
                        this.dcxdjm.Items.Add(new ListViewItem(str1x));

                    };
                }
            }
            catch (Exception ex)
            {
             
            }

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dcxdjm_SelectedIndexChanged(object sender, EventArgs e)
        {


        

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dcxd_Click(object sender, EventArgs e)
        {
            
                   string myx = "server=111.9.116.106;uid=sa;pwd=BKLserver@123!@#;database=ceshi";
                   SqlConnection mysql = new SqlConnection(myx);
                   SqlCommand cmd = new SqlCommand("insert into dcjl values(@hh,@pm,@lsj,@lsh)", mysql);
                    foreach (ListViewItem item in dcxdjm.Items)
                    {
                       // messagebox.show(item.text + " " + item.subitems[1].text);
                        mysql.Open();
                        cmd.Parameters.AddWithValue("@hh", item.Text);
                        cmd.Parameters.AddWithValue("@pm", item.SubItems[1].Text);
                        cmd.Parameters.AddWithValue("@lsj", item.SubItems[2].Text);
                        cmd.Parameters.AddWithValue("@lsh", item.SubItems[3].Text);
                        cmd.ExecuteNonQuery();
                        mysql.Close();
                        cmd.Parameters.Clear();
                    }



           mysql.Close();



        }

        private void dcxdczh_Click(object sender, EventArgs e)
        {

        }

        private void dcslj1_Click(object sender, EventArgs e)
        {
            int Index = 0;

            if (this.dcxdjm.SelectedItems.Count > 0) //判断listview有被选中项
            {
                Index = this.dcxdjm.SelectedItems[0].Index; //取当前选中项的index,SelectedItems[0]这必须为0
                String aa = dcxdjm.Items[Index].SubItems[3].Text;
                int bb = Convert.ToInt32(aa)+1;

                dcxdjm.Items[Index].SubItems[3].Text = bb.ToString();
                //用我们刚取到的index取被选中的某一列的值从0开始
            }
                

            

        }

        private void dcslj2_Click(object sender, EventArgs e)
        {

            int Indexx = 0;

            if (this.dcxdjm.SelectedItems.Count > 0) //判断listview有被选中项
            {
                Indexx = this.dcxdjm.SelectedItems[0].Index; //取当前选中项的index,SelectedItems[0]这必须为0
                String aa = dcxdjm.Items[Indexx].SubItems[3].Text;


                if (Convert.ToInt32(aa) > 1)
                {
                    int bb = Convert.ToInt32(aa) - 1;

                    dcxdjm.Items[Indexx].SubItems[3].Text = bb.ToString();
                    //用我们刚取到的index取被选中的某一列的值从0开始
                }

            }

        }

        }
    }

