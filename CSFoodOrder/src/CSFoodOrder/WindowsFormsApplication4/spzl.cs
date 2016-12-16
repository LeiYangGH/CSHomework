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
    public partial class spzl : Form
    {
        public spzl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            xzspzl x = new xzspzl();

            x.Show();
        }

        private void spzl_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“ceshiDataSet.spzl”中。您可以根据需要移动或删除它。
           // this.spzlTableAdapter.Fill(this.ceshiDataSet.spzl);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle myxh = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dataGridView1.RowHeadersWidth, e.RowBounds.Height);

            // 序号

            TextRenderer.DrawText(e.Graphics,(e.RowIndex+1).ToString(),dataGridView1.RowHeadersDefaultCellStyle.Font,myxh,ForeColor,TextFormatFlags.VerticalCenter|TextFormatFlags.Right);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {

                String strcon = "Server=111.9.116.106;Database=ceshi;uid=sa;pwd=BKLserver@123!@#";
                SqlConnection myspzl = new SqlConnection(strcon);

                string sql = "select * from spzl";
                SqlDataAdapter da = new SqlDataAdapter(sql, myspzl);
                DataSet ds = new DataSet(); da.Fill(ds, "spzl");
                dataGridView1.DataSource = ds;
                dataGridView1.DataSource = ds.Tables["spzl"];
                myspzl.Close();
                ds.Dispose();
                da.Dispose();

            }

        }

        private void select_Click(object sender, EventArgs e)
        {
            String strcon = "Server=111.9.116.106;Database=ceshi;uid=sa;pwd=BKLserver@123!@#";
            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();
            String sql = string.Format("select * from spzl where [hh] like '%" + textBox1.Text + "%'");
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ada.Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {

            Color blue= new Color();
           Color blue1= new Color();
            var row = dataGridView1.Rows[e.RowIndex];
            if (row == dataGridView1.CurrentRow)
            {
                if (row.DefaultCellStyle.ForeColor != Color.White)
                {
                    blue = row.DefaultCellStyle.ForeColor;
                    row.DefaultCellStyle.ForeColor = Color.White;

                }
                if (row.DefaultCellStyle.BackColor != Color.Blue)
                {

                    blue = row.DefaultCellStyle.BackColor;
                    row.DefaultCellStyle.BackColor = Color.Blue;

                }

            }

            else {
                row.DefaultCellStyle.ForeColor = blue;
            row.DefaultCellStyle.BackColor = blue1;
            }

        }

        public Color oldForeColor { get; set; }

        private void xgbut_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false; 
           
            }

        private void bcbtn_Click(object sender, EventArgs e)
        {

        }

        private void selectshuru_Click(object sender, EventArgs e)
        {

        }
    }

        }
    



