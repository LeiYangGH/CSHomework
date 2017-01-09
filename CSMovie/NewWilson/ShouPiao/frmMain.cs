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
        //private Movie selMovie;
        private Play selPlay;
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
        private void ShowSoldPositonsByPlayId()
        {
            TicketBLL tbll = new TicketBLL();
            var lstPositions = tbll.GetSoldPositionsByPlayId(this.selPlay.Id);
            ShowSoldPositonsByListPositions(lstPositions);
        }

        private void tvMovies_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.selPlay = this.tvMovies.SelectedNode?.Tag as Play;
            if (this.selPlay == null)
            {
                return;
            }
            MovieBLL mbll = new MovieBLL();
            Movie movie = mbll.GetMovie(this.selPlay.MovieId);

            if (this.selPlay != null)
            {
                this.lblMovieName.Text = movie.Name;
                this.lblType.Text = movie.MovieTypeName;
                this.lblTime.Text = (movie.Duration).ToString();
                this.picMovie.Image = movie.Poster;
                this.lblPrice.Text = "60";
                //换选电影时候先清空，再绑定，再把已售加上
                this.ClearAllPositions();
                this.GetAndBindPositions();
                this.ShowSoldPositonsByPlayId( );
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

        private DateTime GetPlayTime(DateTime date, DateTime time)
        {
            return date.Date.AddHours(time.Hour).AddMinutes(time.Minute);
        }


        private bool MsgBuyAndConfirm()
        {

            string msg = this.selPlay.MovieName;
            //日期有问题，所以用当前选择的控件日期，而不是Play里数据库的日期
            DateTime dt = this.GetPlayTime(this.dateTimePicker1.Value, this.selPlay.BeginTime);
            msg += "\r\n" + dt.ToString();
            msg += "\r\n" + this.selCusTypeName;
            msg += "\r\n" + string.Join("\r\n", this.selPositions.Select(x =>
           (x.RowNum + 1).ToString() + "排 " + (x.ColNum + 1).ToString() + "座"));//+ "\r\n"
            msg += "\r\n总价：" + this.CalcTotal().ToString();
            //弹出框应该是和其他接口的地方
            if (MessageBox.Show(msg, "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //确认购买
                return true;
            }
            else
            {
                MessageBox.Show("您取消了购买。");
                return false;
            }

        }

        private void SaveTicket(Ticket ticket)
        {
            TicketBLL tbll = new TicketBLL();
            tbll.Insert(ticket);
            //后面主要是TicketDAL.Insert(Ticket ticket)
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.IsPlaySelected() && this.MsgBuyAndConfirm())
            {
                Play play = tvMovies.SelectedNode.Tag as Play;
                CustomerType ct = comboBox1.SelectedItem as CustomerType;
                DateTime sellTime = DateTime.Now;
                decimal sellPrice = 60;
                foreach (Position p in this.selPositions)
                {
                    Ticket ticket = new Ticket();
                    ticket.PlayId = play.Id;
                    ticket.CustomerTypeId = ct.Id;
                    ticket.SellDateTime = sellTime;
                    ticket.PositionId = p.Id;
                    ticket.SellPrice = sellPrice;
                    //保存售票到数据库
                    this.SaveTicket(ticket);
                    //在当前绑定架构下，如果直接对Cell.Value赋值为"已售"会引起不一致
                    //所以对PositionTypeName赋值
                    p.PositionTypeName = "已售";
                }
                MessageBox.Show("售票成功，已存储售票信息。");
            }
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

        private bool IsPlaySelected()
        {
            if (this.selPlay == null)
            {
                MessageBox.Show("请先选择电影和放映时间！");
                return false;
            }
            else
                return true;
        }

        private void dgvPosition_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.IsPlaySelected())
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
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            GetAndBindAllMovies(tvMovies, dateTimePicker1.Value);
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }
        //选择5号
        private void button2_Click(object sender, EventArgs e)
        {
            this.dateTimePicker1.Value = new DateTime(2017, 1, 5);
            GetAndBindAllMovies(tvMovies, dateTimePicker1.Value);
        }
    }
}


