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
    public partial class qtdczck : Form


    {
        public qtdczck()
        {
            InitializeComponent();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

            string dcxxk = "server=111.9.116.106;database=ceshi;uid=sa;pwd=BKLserver@123!@#";

            SqlConnection con = new SqlConnection(dcxxk);

            string sql="select lbmc from splb where guid='11' ";
            SqlCommand cmd = new SqlCommand(sql,con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader myReader;
            con.Open();
            myReader = cmd.ExecuteReader();



            tabPage1.Text = myReader["sql"].ToString();

            cmd.Cancel();
            myReader.Close();



                con.Close();

            }

        private string flag;
        /// <summary>
        /// 接收传过来的值
        /// </summary>
        public string Flag
        {
            get { return flag; }
            set { flag = value; }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
