using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections;
using Model;
using BLL;
namespace ShouPiao
{
    public partial class frmMain : Form
    {
        //选中的项目，作为全局变量，以减少函数之间传递参数
        private Movie selMovie;
        private string selCusTypeName;
        private List<Position> selPositions;

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
            GetAndBindAllMovies();
            dgvPosition.RowCount = 10;
            dgvPosition.ColumnCount = 10;
            this.GetAndBindPositions();
        }

        //显示已售
        private void ShowSoldPositonsByListPositions(List<Position> positions)
        {
            foreach (DataGridViewRow row in this.dgvPosition.Rows)
                foreach (DataGridViewColumn col in this.dgvPosition.Columns)
                {
                    DataGridViewCell cell = row.Cells[col.Index];
                    var foundPosition = positions.FirstOrDefault(p => p.RowNum == row.Index + 1 && p.ColNum == col.Index + 1);
                    if (foundPosition != null)
                    {
                        this.EnableCell(cell, false);
                        (cell.Value as Position).PositionTypeName = "已售";
                    }
                }
        }

        //显示某部电影的已售
        private void ShowSoldPositonsByMovieName(string movieName)
        {
            SaleBLL sbll = new SaleBLL();
            var lstPositions = sbll.GetSoldPositionsByMovieName(movieName);
            ShowSoldPositonsByListPositions(lstPositions);
        }

        private void tvMovies_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode sel = this.tvMovies.SelectedNode;
            Movie m = sel.Tag as Movie;

            if (m != null)
            {
                this.selMovie = m;
                this.lblMovieName.Text = m.Name;
                this.lblType.Text = m.MovieTypeName;
                this.lblTime.Text = ((int)m.Duration).ToString();
                this.picMovie.Image = m.Poster;
                this.lblPrice.Text = "60";
                this.ShowSoldPositonsByMovieName(m.Name);
            }
            else
            {
                this.lblMovieName.Text = "";
                this.lblType.Text = "";
                this.lblTime.Text = "";
                this.picMovie.Image = null;
                this.lblPrice.Text = "";
            }

        }

        //获取和显示所有座位
        private void GetAndBindPositions()
        {
            PositionBLL pbll = new PositionBLL();
            var lstPositions = pbll.GetAllPosition();
            this.FillPositions(lstPositions);
        }

        //显示某类型电影列表
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
        /// 显示所有类型电影列表
        /// </summary>
        private void GetAndBindAllMovies()
        {
            this.tvMovies.Nodes.Clear();
            MovieTypeBLL tbll = new MovieTypeBLL();
            var lstTypes = tbll.GetLeixi();

            foreach (MovieType t in lstTypes)
            {
                this.GetAndBindMoviesInType(t);
            }
        }

        private int CalcTotal()
        {
            //总价算法需要改
            return 60 * this.selPositions.Count;
        }

        private bool SaveSale()
        {
            Sale sale = new Sale(this.selMovie.Name, this.selCusTypeName, 60f, this.selPositions);
            SaleBLL sbll = new SaleBLL();
            if (sbll.InsertSale(sale))
            {
                ShowSoldPositonsByListPositions(this.selPositions);
                MessageBox.Show("购票成功！");
                return true;
            }
            else
            {
                MessageBox.Show("购票失败！");
                return false;
            }
        }

        //confirm
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.selMovie == null
                || string.IsNullOrWhiteSpace(this.selCusTypeName)
                || this.selPositions.Count == 0)
            {
                MessageBox.Show("请先选择电影、客户类型、座位");
                return;
            }
            string msg = this.selMovie.Name + "\r\n" + this.selCusTypeName + "\r\n";
            msg += string.Join("\r\n", this.selPositions.Select(x => x.GetMessagePoint()));
            msg += "\r\n总价：" + this.CalcTotal().ToString();
            if (MessageBox.Show(msg, "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //确认购买
                this.SaveSale();
            }
            else
                MessageBox.Show("您取消了购买。");


        }

        private void tpCinema_Click(object sender, EventArgs e)
        {

        }

        private bool CanCellSelect(Position p)
        {
            return p != null && p.UseAble
                && p.PositionTypeName != "通道"
                && p.PositionTypeName != "已售";
        }

        private bool CanCellSelect(DataGridViewCell cell)
        {
            Position p = cell.Value as Position;
            return CanCellSelect(p);
        }

        private void FillPositions(List<Position> posList)
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
                DataGridViewCell cell = dgvPosition.Rows[p.RowNum - rowMin].Cells[p.ColNum - colMin];
                cell.Value = p;
                this.EnableCell(cell, CanCellSelect(p));
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.selCusTypeName = this.comboBox1.Text;
        }

        private void EnableCell(DataGridViewCell dc, bool enabled)
        {
            dc.ReadOnly = !enabled;
            if (enabled)
            {
                dc.Style.BackColor = dc.OwningColumn.DefaultCellStyle.BackColor;
                dc.Style.ForeColor = dc.OwningColumn.DefaultCellStyle.ForeColor;
            }
            else
            {
                dc.Style.BackColor = Color.LightGray;
                dc.Style.ForeColor = Color.DarkGray;
            }
        }


        private void dgvPosition_SelectionChanged(object sender, EventArgs e)
        {
            this.selPositions = this.dgvPosition.SelectedCells
                .OfType<DataGridViewCell>().Where(x => this.CanCellSelect(x))
                .Select(c => c.Value as Position).ToList();
        }

        private void dgvPosition_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = this.dgvPosition.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (!this.CanCellSelect(cell))
            {
                MessageBox.Show("请选择其他座位！");
                this.dgvPosition.ClearSelection();
                this.dgvPosition.CurrentCell = null;
            }
        }
    }
}


