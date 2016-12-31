using BLL;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieManage
{
    public partial class frmMain : Form
    {
        MovieBLL mb = new MovieBLL();
       
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowLeiXi();
        }

        private void ShowLeiXi()
        {
            List<MovieType> mts = GetLeixi();
            MovieType mt = new MovieType()
            {
                Name = "全部"

            };
            mts.Insert(0, mt);
            this.comboBox1.DisplayMember = "name";
            this.comboBox1.ValueMember = "id";
            this.comboBox1.DataSource = mts;
        }

        private List<MovieType> GetLeixi()
        {
            List<MovieType> mts = new List<MovieType>();
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM movieType ";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MovieType mt = new MovieType(reader);
                    mts.Add(mt);

                }
            }
            return mts;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = string.Format("{0}-{1}", this.comboBox1.Text, this.comboBox1.SelectedValue);
            this.Text = text;

            byte depID = Convert.ToByte(this.comboBox1.SelectedValue);
            List<Movie> mes = mb.Search(depID);
            movieBindingSource.DataSource = mes;
        }
    }
}
