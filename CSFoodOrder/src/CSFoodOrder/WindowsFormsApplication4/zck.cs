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
    public partial class zck : Form
    {
        public zck()
        {
            InitializeComponent();
        }

        private void zck_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“ceshiDataSet2.spzl”中。您可以根据需要移动或删除它。
            //this.spzlTableAdapter.Fill(this.ceshiDataSet2.spzl);

        }

        private void menus_DrawItem(object sender, DrawItemEventArgs e)
        {
            //string text = ((TabControl)sender).TabPages[e.Index].Text;
            //SolidBrush brush = new SolidBrush(Color.Black);
            //StringFormat sf = new StringFormat(StringFormatFlags.DirectionRightToLeft);
            //sf.LineAlignment = StringAlignment.Center;
            //sf.Alignment = StringAlignment.Center;
            //e.Graphics.DrawString(text, SystemInformation.MenuFont, brush, e.Bounds, sf);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //if (spzlcxtext.Text == "")
            //{

            //    String strcon = "Server=111.9.116.106;Database=ceshi;uid=sa;pwd=BKLserver@123!@#";
            //    SqlConnection myspzl = new SqlConnection(strcon);

            //    string sql = "select * from spzl";
            //    SqlDataAdapter da = new SqlDataAdapter(sql, myspzl);
            //    DataSet ds = new DataSet(); da.Fill(ds, "spzl");
            //    dataGridView1.DataSource = ds;
            //    dataGridView1.DataSource = ds.Tables["spzl"];
            //    myspzl.Close();
            //    ds.Dispose();
            //    da.Dispose();

            //}
        }

        private void select_Click(object sender, EventArgs e)
        {
            //String strcon = "Server=111.9.116.106;Database=ceshi;uid=sa;pwd=BKLserver@123!@#";
            //SqlConnection conn = new SqlConnection(strcon);
            //conn.Open();
            //String sql = string.Format("select * from spzl where [pm] like '%" + spzlcxtext.Text + "%'");
            //SqlCommand cmd = new SqlCommand(sql, conn);
            //SqlDataAdapter ada = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //ada.Fill(ds);
            //conn.Close();
            //dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            xzspzl x = new xzspzl();

            x.Show();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //Rectangle myxh = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dataGridView1.RowHeadersWidth, e.RowBounds.Height);

            //// 序号

            //TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dataGridView1.RowHeadersDefaultCellStyle.Font, myxh, ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void xgbtn_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {

            //Color blue = new Color();
            //Color blue1 = new Color();
            //var row = dataGridView1.Rows[e.RowIndex];
            //if (row == dataGridView1.CurrentRow)
            //{
            //    if (row.DefaultCellStyle.ForeColor != Color.White)
            //    {
            //        blue = row.DefaultCellStyle.ForeColor;
            //        row.DefaultCellStyle.ForeColor = Color.White;

            //    }
            //    if (row.DefaultCellStyle.BackColor != Color.DeepSkyBlue)
            //    {

            //        blue = row.DefaultCellStyle.BackColor;
            //        row.DefaultCellStyle.BackColor = Color.DeepSkyBlue;

            //    }

            //}

            //else
            //{
            //    row.DefaultCellStyle.ForeColor = blue;
            //    row.DefaultCellStyle.BackColor = blue1;
            //}



        }


        private void cp1v1_Click(object sender, EventArgs e)
        {
        }

        private void zck_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void cp1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

            //int a = 5;
            //for (int i = 0; i < a; i++)
            //{
            //    UserControl1 mcontrol = new UserControl1();
            //    mcontrol.labid = "1" + i;
            //    mcontrol.lablsj = "dd" + i.ToString();
            //    mcontrol.labname = "sada" + i.ToString();
            //    mcontrol.Size = new Size(55, 55);
            //    this.flowLayoutPanel1.Controls.Add(mcontrol);

            //}


        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x02000000;
        //        return cp;
        //    }
        //}

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void cp2_Click(object sender, EventArgs e)
        {


        }

        private void btnShowMenu_Click(object sender, EventArgs e)
        {
            String connStr = "Server=111.9.116.106;Database=ceshi;uid=sa;pwd=BKLserver@123!@#";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select hh,pm,lsj from spzl", new SqlConnection(connStr));
            da.Fill(dt);

            foreach (DataRow r in dt.Rows)
            {
                this.flowLayoutPanel1.Controls.Add(
                    new UCFoodMenu(
                    r["hh"].ToString(),
                    r["pm"].ToString(),
                    r["lsj"].ToString()
                    ));
            }
        }

    }
}


