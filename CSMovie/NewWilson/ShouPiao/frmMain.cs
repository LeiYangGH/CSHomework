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


        private void FrmCinema_Load(object sender, EventArgs e)
        {
            //加载treeview
            BingTreeView();
            dgvPosition.RowCount = 10;
            dgvPosition.ColumnCount = 10;
        }


        private void tvMovies_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void GetAndBindMoviesInType(TreeNode tNode, MovieType t)
        {
            MovieBLL mbll = new MovieBLL();
            var lstMovies = mbll.GetAllFromSqlSever(t.Id);
            foreach (Movie m in lstMovies)
            {
                tNode.Nodes.Add(m.Name);
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
                TreeNode tNode = this.tvMovies.Nodes.Add(t.Name);
                this.GetAndBindMoviesInType(tNode, t);
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


