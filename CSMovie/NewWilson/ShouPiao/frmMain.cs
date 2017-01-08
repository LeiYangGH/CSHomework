using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Model;
using BLL;

namespace TicketManager
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
            comboBox1.DisplayMember = "Name";
            comboBox1.DataSource = cbll.GetAllCustomerType();
        }

        private void FrmCinema_Load(object sender, EventArgs e)
        {
            GetAndBindAllMovies(tvMovies, DateTime.Now);
            dgvPosition.RowCount = 10;
            dgvPosition.ColumnCount = 10;
            this.AddCustomerTypes();
            this.GetAndBindPositions();
        }

        //显示已售
        private void ShowSoldPositonsByListPositions(List<Position> positions)
        {
            foreach (DataGridViewRow row in this.dgvPosition.Rows)
                foreach (DataGridViewColumn col in this.dgvPosition.Columns)
                {
                    DataGridViewCell cell = row.Cells[col.Index];
                    //看当前坐标有没有在已售列表里
                    var foundPosition = positions.FirstOrDefault(p =>
                    p.RowNum == row.Index + 1 && p.ColNum == col.Index + 1);
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
            //SaleBLL sbll = new SaleBLL();
            //var lstPositions = sbll.GetSoldPositionsByMovieName(movieName);
            //ShowSoldPositonsByListPositions(lstPositions);
        }

        private void tvMovies_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = this.tvMovies.SelectedNode;
            if (node.Tag is Play == false)
                return;
            Play play = node.Tag as Play;
            MovieBLL bll = new MovieBLL();
            Movie mv = bll.GetMovie(play.MovieId);

            if (play != null)
            {
                this.lblMovieName.Text = mv.Name;
                this.lblType.Text = mv.MovieTypeName;
                this.lblTime.Text = (mv.Duration).ToString();
                this.picMovie.Image = mv.Poster;
                this.lblPrice.Text = "60";
                //换选电影时候先清空，再绑定，再把已售加上
                this.ClearAllPositions();
                this.GetAndBindPositions();
                //this.ShowSoldPositonsByMovieName(mv.Name);
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


        /// <summary>
        /// 显示所有类型电影列表
        /// </summary>
        private void GetAndBindAllMovies(TreeView tv, DateTime dt)
        {
            this.tvMovies.Nodes.Clear();

            PlayBLL bllPlay = new PlayBLL();
            List<Play> plays = bllPlay.Search(dt);

            foreach (Play p in plays)
            {
                //首先在树图中查找该电影的场次节点
                TreeNode node = GetTreeNodeByMovieId(tv, p.MovieId);
                if (node == null)
                {
                    // 数图中没有该电影的场次信息的时候就创建一个
                    node = new TreeNode();
                    node.Text = p.MovieName;
                    node.Tag = p.MovieId;
                    //将场次的信息放在电影节点的子节点中
                    TreeNode time = new TreeNode();
                    time.Tag = p;
                    time.Text = p.BeginTime.ToShortTimeString();
                    node.Nodes.Add(time);
                    tv.Nodes.Add(node);
                }
                else
                {
                    TreeNode time = new TreeNode();
                    time.Tag = p;
                    time.Text = p.BeginTime.ToShortTimeString();
                    node.Nodes.Add(time);

                }

            }

        }
        TreeNode GetTreeNodeByMovieId(TreeView tv, string movieId)
        {
            TreeNode node = null;
            foreach (TreeNode n in tvMovies.Nodes)
            {
                string mid = n.Tag as string;
                if (mid == movieId)
                {
                    node = n;
                    break;
                }
            }
            return node;
        }
        private int CalcTotal()
        {
            //总价算法需要改
            return 60 * this.selPositions.Count;
        }

        //private bool SaveSale()
        //{
        //    TicketBLL bllTick = new TicketBLL();
        //    foreach (Position p in selPositions)
        //    {
        //        Ticket ticket = new Ticket();
        //        ticket.CustomerTypeId = (comboBox1.SelectedItem as CustomerType).Id;
        //        ticket.PositionId = p.Id;

        //    }
        //    if (true)
        //    {
        //        //如果保存成功则把当前选中的改成已售
        //        ShowSoldPositonsByListPositions(this.selPositions);
        //        MessageBox.Show("购票成功！");
        //        return true;
        //    }
        //    else
        //    {
        //        MessageBox.Show("购票失败！");
        //        return false;
        //    }
        //}

        TicketBLL bllT = new TicketBLL();
        private void button1_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewCell cell in dgvPosition.SelectedCells)
            {
                Position p = cell.Value as Position;
                Play play = tvMovies.SelectedNode.Tag as Play;
                CustomerType ct = comboBox1.SelectedItem as CustomerType;
                DateTime sellTime = DateTime.Now;
                decimal sellPrice = 50;

                Ticket tk = new Ticket();
                tk.PlayId = play.Id;
                tk.CustomerTypeId = ct.Id;
                tk.PositionId = p.Id;
                tk.SellPrice = sellPrice;
                bllT.Insert(tk);
            }


            //if (this.selMovie == null
            //    || string.IsNullOrWhiteSpace(this.selCusTypeName)
            //    || this.selPositions.Count == 0)
            //{
            //    MessageBox.Show("请先选择电影、客户类型、座位");
            //    return;
            //}
            //string msg = this.selMovie.Name + "\r\n" + this.selCusTypeName + "\r\n";
            //msg += string.Join("\r\n", this.selPositions.Select(x => x.GetMessagePoint()));
            //msg += "\r\n总价：" + this.CalcTotal().ToString();
            ////弹出框应该是和其他接口的地方
            //if (MessageBox.Show(msg, "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            //    //确认购买
            //    this.SaveSale();
            //}
            //else
            //    MessageBox.Show("您取消了购买。");


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

        private void ClearAllPositions()
        {
            foreach (DataGridViewRow row in this.dgvPosition.Rows)
                foreach (DataGridViewColumn col in this.dgvPosition.Columns)
                {
                    DataGridViewCell cell = row.Cells[col.Index];
                    this.EnableCell(cell, true);
                }

            this.dgvPosition.ClearSelection();
            this.dgvPosition.CurrentCell = null;
        }

        private bool CanCellSelect(DataGridViewCell cell)
        {
            Position p = cell.Value as Position;
            return CanCellSelect(p);
        }

        //组长DGV代码
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

        //标记可用和不可用的样式
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
                //一旦选择不可用的就把所有选中取消，因为目前如果要实现只取消选中不可用的那个代码量会多不少
                this.dgvPosition.ClearSelection();
                this.dgvPosition.CurrentCell = null;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            GetAndBindAllMovies(tvMovies, dateTimePicker1.Value);
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }
    }
}


