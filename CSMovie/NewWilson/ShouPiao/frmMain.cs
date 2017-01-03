using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Model;
using BLL;
namespace ShouPiao
{
    public partial class frmMain : Form
    {
        DbSqlHelper db = new DbSqlHelper();
        DataSet ds = null;
        Hashtable dta = new Hashtable();
        public frmMain()
        {
            InitializeComponent();
        }


        private void AddCustomerTypes()
        {
            CustomerTypeBLL cbll = new CustomerTypeBLL();
            this.comboBox1.Items.Clear();
            foreach (CustomerType cu in cbll.GetAllCustomerType())
            {
                this.comboBox1.Items.Add(cu.Name);
            }
        }

        private void FrmCinema_Load(object sender, EventArgs e)
        {
            this.AddCustomerTypes();
            BingTreeView();
            dgvPosition.RowCount = 10;
            dgvPosition.ColumnCount = 10;
        }


        private void tvMovies_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode sel = this.tvMovies.SelectedNode;
            Movie m = sel.Tag as Movie;

            if (m != null)
            {
                this.lblMovieName.Text = m.Name;
                this.lblType.Text = m.MovieTypeName;
                this.lblTime.Text = ((int)m.Duration).ToString();
                this.picMovie.Image = m.Poster;
            }
            else
            {
                this.lblMovieName.Text = "";
                this.lblType.Text = "";
                this.lblTime.Text = "";
                this.picMovie.Image = null;

            }

        }

        private void GetAndBindMoviesTime(TreeNode t, Movie m)
        {
            //MovieScheduleBLL sbll = new MovieScheduleBLL();
            //var  = mbll.GetAllFromSqlSever(t.Id);
            //foreach (Movie m in lstMovies)
            //{
            //    this.tvMovies.Nodes.Add(m.Name).Tag = m;
            //}
        }

        private void GetAndBindMoviesInType(MovieType t)
        {
            MovieBLL mbll = new MovieBLL();
            var lstMovies = mbll.GetAllFromSqlSever(t.Id);
            foreach (Movie m in lstMovies)
            {
                this.tvMovies.Nodes.Add(m.Name).Tag = m;
            }
        }

        /// <summary>
        /// 获取放映列表绑定到TreeView
        /// </summary>
        private void BingTreeView()
        {
            this.tvMovies.Nodes.Clear();
            MovieTypeBLL tbll = new MovieTypeBLL();
            var lstTypes = tbll.GetLeixi();

            foreach (MovieType t in lstTypes)
            {
                //TreeNode tNode = this.tvMovies.Nodes.Add(t.Name);
                //tNode.Tag = t;
                this.GetAndBindMoviesInType(t);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tpCinema_Click(object sender, EventArgs e)
        {

        }
        private void FillDataGridView(List<Position> posList)
        {
            int rowMin = int.MaxValue, colMin = int.MaxValue;
            int rowMax = int.MinValue, colMax = int.MinValue;
            foreach (Position p in posList)
            {
                if (rowMin > p.RowNum) rowMin = p.RowNum;
                if (rowMax < p.RowNum) rowMax = p.RowNum;
                if (colMin > p.ColNum) colMin = p.ColNum;
                if (colMax < p.ColNum) colMax = p.ColNum;
            }
            int rows = rowMax - rowMin + 1;
            int cols = colMax - colMin + 1;

            dgvPosition.Rows.Clear();
            dgvPosition.ColumnCount = cols;
            dgvPosition.RowCount = rows;

            foreach (Position p in posList)
            {
                DataGridViewCell cell =
                    dgvPosition.Rows[p.RowNum - rowMin].Cells[p.ColNum - colMin];
                cell.Value = p;
                cell.ToolTipText = p.PositionTypeName;
            }
        }
    }
}


