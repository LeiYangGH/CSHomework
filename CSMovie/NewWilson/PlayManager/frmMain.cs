using Model;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayManager
{
    public partial class frmMain : Form
    {

        string connStr = ConfigurationManager.ConnectionStrings["yp_conn"].ConnectionString;
        public frmMain()
        {            
            InitializeComponent();
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 fo = new Form1();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.comboBox1.Text = "";
            this.comboBox3.Text = "";
            MessageBox.Show("清除成功");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Fillmovies();
        }

        private void Fillmovies()
        {
            List<Movie> mo = GetAllMovies();
        }

        private List<Movie> GetAllMovies()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select [id],[name],[beginDate],[duration]  from [schedule]";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Movie mo = new Movie();
                }
                return null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == 0 || this.comboBox3.SelectedIndex == 0)
            {
                MessageBox.Show("请完善影片信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Schedule sh = new Schedule();
            Movie Mo = new Movie();
            Mo.Name = this.comboBox1.Text;
             
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要删除吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                return; 
            }
        }
    }
}
