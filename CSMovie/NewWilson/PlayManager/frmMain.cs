using BLL;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayManager
{
    public partial class frmMain : Form
    {
        MovieBLL mb = new MovieBLL();
        MovieDAL ml = new MovieDAL();
        MovieTypeDAL mte = new MovieTypeDAL();
        List<Movie> mes;
        public frmMain()
        {
            InitializeComponent();
        }
        private void frmschedule_Load(object sender, EventArgs e)
        {
            FilldataGridView();
        }

        private void FilldataGridView()
        {
            List<MovieType> mov = mte.GetLeixi();
            MovieType mo = new MovieType()
            {
                Name = "全部",
                Id = Convert.ToByte(0)
            };
            mov.Insert(0, mo);
            this.cmbClass.DisplayMember = "name";
            this.cmbClass.ValueMember = "id";
            this.cmbClass.DataSource = mov;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = string.Format("{0}-{1}", this.cmbClass.Text, this.cmbClass.SelectedValue);
            this.Text = text;

            byte depID = Convert.ToByte(this.cmbClass.SelectedValue);
            mes = ml.GetAllFromSqlSever(depID);
            movieBindingSource.DataSource = mes;
            this.dgvMovie.Refresh();
        }


        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string text = string.Format("{0}-{1}",
                cmbClass.Text, cmbClass.SelectedValue);
            this.Text = text;

            Convert.ToInt32(cmbClass.SelectedValue);
            List<Movie> emps = ml.GetMovie();

            this.movieBindingSource.DataSource = emps;
        }

        private void movieBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            byte movieTypeId = Convert.ToByte(this.textBox1.Text);
            List<Movie> mos = ml.Search(movieTypeId);
            movieBindingSource.DataSource = mos;
        }
    }
}
