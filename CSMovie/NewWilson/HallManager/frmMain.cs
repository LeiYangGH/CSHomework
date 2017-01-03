using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HallManager
{
    public partial class frmMain : Form
    {
        HallBLL bllHall = new HallBLL();
        LayoutBLL bllLayout = new LayoutBLL();
        PositionBLL bllPos = new PositionBLL();
        PositionTypeBLL bllPosType = new PositionTypeBLL();

        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            SetDataBindings();
        }
        private void SetDataBindings()
        {
            // 填充放映厅列表
            ltHall.DisplayMember = "Name";
            hallBindingSource.DataSource = bllHall.GetAllHall();
            // 绑定放映厅显示数据
            lblHallId.DataBindings.Add(new Binding("Text", hallBindingSource, "Id"));
            txtHallName.DataBindings.Add(new Binding("Text", hallBindingSource, "Name"));
            txtHallTheme.DataBindings.Add(new Binding("Text", hallBindingSource, "Theme"));

            // 填充位置类型选择框
            positionTypeBindingSource.DataSource = bllPosType.GetALLPositionType();

            // 设定右键菜单选项
            foreach (PositionType pt in positionTypeBindingSource)
            {
                ToolStripMenuItem tsmi = new ToolStripMenuItem();
                tsmi.Text = pt.Name;
                tsmi.Tag = pt;
                tsmi.Click += TsmiNewPositionTypeSelected_Click;
                tsmiPositionTypeChange.DropDownItems.Add(tsmi);
            }
            btnLayoutSaveChange.Enabled = false;
        }

        private void layoutBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            Layout lay = layoutBindingSource.Current as Layout;
            List<Position> posList = bllPos.SearchByLayout(lay.Id);
            FillDataGridView(posList);

            Layout l = layoutBindingSource.Current as Layout;

           if (l.RefNum == 0)
            {
                btnLayoutSaveChange.Enabled =
                    btnLayoutDelete.Enabled =
                    btnLayoutSaveNew.Enabled = true;
            }
            else
            {
                btnLayoutSaveChange.Enabled =
                    btnLayoutDelete.Enabled =
                    btnLayoutSaveNew.Enabled = false;
            }

        }
        private void hallBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            FillLayoutCombox();
        }
        private void FillLayoutCombox()
        {
            layoutBindingSource.DataSource = bllLayout.GetAllLayout();
            Hall hall = hallBindingSource.Current as Hall;
            if (hall == null)
                return;

            Layout lay = null;
            foreach (Layout layout in layoutBindingSource)
            {
                if (layout.Id == hall.LayoutId)
                {
                    lay = layout; break;
                }
            }
            layoutBindingSource.Position = layoutBindingSource.IndexOf(lay);
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

        private void btnHallNew_Click(object sender, EventArgs e)
        {
            Hall hall = new Hall();
            Layout layout = layoutBindingSource.Current as Layout;
            hall.LayoutId = layout.Id;
            hall.LayoutStyle = layout.Style;
            hall.Name = txtHallName.Text;
            hall.Theme = txtHallTheme.Text;

            hall.Id = bllHall.AddHall(hall);
            hallBindingSource.Add(hall);

        }
        private void btnHallSaveChange_Click(object sender, EventArgs e)
        {
            Hall hall = hallBindingSource.Current as Hall;
            Layout layout = layoutBindingSource.Current as Layout;
            hall.LayoutId = layout.Id;
            hall.LayoutStyle = layout.Style;
            hall.Name = txtHallName.Text;
            hall.Theme = txtHallTheme.Text;
            bllHall.ResetHall(hall);
            FillLayoutCombox();
        }
        private void btnHallDrop_Click(object sender, EventArgs e)
        {
            Hall hall = hallBindingSource.Current as Hall;
            bllHall.DropHall(hall.Id);
            hallBindingSource.RemoveCurrent();
            Layout layout = layoutBindingSource.Current as Layout;
            layout.RefNum -= 1;
        }

        private void btnLayoutDelete_Click(object sender, EventArgs e)
        {
            Layout layout = layoutBindingSource.Current as Layout;
            if (layout.RefNum != 0)
                return;
            try
            {
                bllPos.DropPositionBelongLayout(layout.Id);
                bllLayout.DropLayout(layout.Id);
                layoutBindingSource.RemoveCurrent();
            }
            catch (Exception)
            {
                string msg = string.Format("删除失败! 标识: {0}, 风格: {1}, 被放映厅引用次数: {2}"
                    , layout.Id, layout.Style, layout.RefNum);
                MessageBox.Show(msg, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnLayoutCreate_Click(object sender, EventArgs e)
        {
            #region 非法输入检测
            if (txtStyle.Text == string.Empty)
            {
                txtStyle.Focus();
                return;
            }
            if (txtRowNum.Text == string.Empty)
            {
                txtRowNum.Focus();
                return;
            }
            if (txtColNum.Text == string.Empty)
            {
                txtColNum.Focus();
                return;
            } 
            #endregion
            string style = Convert.ToString(txtStyle.Text);
            Layout newLayout = new Layout();
            newLayout.Style = style;
            newLayout.Id = bllLayout.AddLayout(newLayout);
            newLayout.RefNum = 0;
            layoutBindingSource.Insert(0, newLayout);
            layoutBindingSource.Position = 0;

            int rows = Convert.ToInt32(txtRowNum.Text);
            int cols = Convert.ToInt32(txtColNum.Text);

            PositionType positionType = positionTypeBindingSource.Current as PositionType;
            List<Position> positions = new List<Position>();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Position pos = new Position();
                    pos.PositionTypeId = positionType.Id;
                    pos.PositionTypeName = positionType.Name;
                    pos.RowNum = i + 1;
                    pos.ColNum = j + 1;
                    pos.UseAble = true;
                    positions.Add(pos);
                }
            }
            FillDataGridView(positions);
        }
        private void btnLayoutSaveNew_Click(object sender, EventArgs e)
        {
            Layout layout = layoutBindingSource.Current as Layout;
            bllPos.DropPositionBelongLayout(layout.Id);
            dgvPosition.SelectAll();
            foreach (DataGridViewCell cell in dgvPosition.SelectedCells)
            {
                Position p = cell.Value as Position;
                if (p == null) continue;
                p.LayoutId = layout.Id;
                p.Id = bllPos.AddPosition(p);
            }
            btnLayoutSaveNew.Enabled = false;
        }
        private void btnLayoutSaveChange_Click(object sender, EventArgs e)
        {
            dgvPosition.SelectAll();
            foreach (DataGridViewCell cell in dgvPosition.SelectedCells)
            {
                Position p = cell.Value as Position;
                if (p == null) continue;
                bllPos.ChangePositionType(p.Id, p.PositionTypeId);
            }
        }

        private void dgvPosition_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1) return;
            // 如果不是右键点击也不进行任何操作
            if (e.Button != MouseButtons.Right) return;

            // 根据鼠标相对于屏幕左上角的坐标设置右键菜单
            // 这个位置不是相对于网络控件左上角的坐标
            cmsPosition.Show(MousePosition.X, MousePosition.Y);
        }

        private void TsmiNewPositionTypeSelected_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            PositionType pt = tsmi.Tag as PositionType;
            foreach (DataGridViewCell cell in dgvPosition.SelectedCells)
            {
                Position p = cell.Value as Position;
                if (p == null) continue;
                p.PositionTypeId = pt.Id;
                p.PositionTypeName = pt.Name;
            }
            btnLayoutSaveChange.Enabled = true;
            dgvPosition.Refresh();
        }
        private void tsmiPositionEnable_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in dgvPosition.SelectedCells)
            {
                Position p = cell.Value as Position;
                if (p == null) continue;
                p.UseAble = true;
            }
            dgvPosition.Refresh();
        }
        private void tsmiPositionDisable_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in dgvPosition.SelectedCells)
            {
                Position p = cell.Value as Position;
                if (p == null) continue;
                p.UseAble = false;
            }
            dgvPosition.Refresh();
        }
        private void tsmiPositionTypeNew_Click(object sender, EventArgs e)
        {
            PositionType ptype = new PositionType();
            frmPositionTypeNew from = new frmPositionTypeNew(ptype);
            if (from.ShowDialog() != DialogResult.OK)
                return;
            if (from.PositionType.Name.Trim() == string.Empty)
                return;
            ptype.Id = bllPosType.AddNewPositionType(ptype);
            ToolStripMenuItem tsmi = new ToolStripMenuItem();
            tsmi.Text = ptype.Name;
            tsmi.Tag = ptype;
            tsmi.Click += TsmiNewPositionTypeSelected_Click;
            tsmiPositionTypeChange.DropDownItems.Add(tsmi);
        }
    }
}
