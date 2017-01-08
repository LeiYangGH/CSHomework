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
            InitialData();
        }
        private void InitialData()
        {
            // 填充放映厅列表
            hallBindingSource.DataSource = bllHall.GetAllHall();
            //填充布局选择框
            layoutBindingSource.DataSource = bllLayout.GetAllLayout();
            // 填充位置类型选择框
            positionTypeBindingSource.DataSource = bllPosType.GetALLPositionType();
            foreach (ToolStripMenuItem tsmi in cmsPosition.Items)
            {
                tsmi.DropDownOpened += Tsmi_DropDownOpened;
            }

            #region 右键菜单中启停位置选项初始化
            bool[] pu = new bool[] { true, false };
            foreach (bool b in pu)
            {
                ToolStripMenuItem tsmi = new ToolStripMenuItem();
                tsmi.Text = b == true ? "可用" : "不可用";
                tsmi.Tag = b;
                tsmi.Click += TsmiPositionUseableStateUpdate;
                tsmiPositionTypeState.DropDownItems.Add(tsmi);
            } 
            #endregion
            #region 设定布局按钮停用/启用规则
            btnLayoutCreate.Click += btnLayoutSaveNewEnable;
            btnLayoutSaveChange.Click += buttonDisableAfterPress;
            btnLayoutSaveNew.Click += buttonDisableAfterPress;
            btnLayoutSaveNew.Click += btnLayoutUpdateDisable;
            layoutBindingSource.CurrentChanged += btnLayoutAdditionTest;
            btnHallSaveChange.Click += btnLayoutAdditionTest;
            btnHallDrop.Click += btnLayoutAdditionTest;
            #endregion
            #region 放映厅按钮停用/启用规则
            txtHallName.KeyPress += btnHallSaveChangeEnable;
            txtHallTheme.KeyPress += btnHallSaveChangeEnable;
            cboLayout.Click += btnHallSaveChangeEnable;
            hallBindingSource.CurrentChanged += btnHallSaveChangeDisable;
            btnHallNew.Click += btnHallSaveChangeDisable;
            btnHallDrop.Click += btnHallSaveChangeDisable;
            btnHallSaveChange.Click += buttonDisableAfterPress;
            #endregion
        }

        #region 按钮可用状态方法
        private void btnHallSaveChangeEnable(object sender, EventArgs e)
        {
            btnHallSaveChange.Enabled = true;
        }
        private void btnHallSaveChangeDisable(object sender, EventArgs e)
        {
            btnHallSaveChange.Enabled = false;
        }
        private void btnLayoutUpdateEnable(object sender, EventArgs e)
        {
            btnLayoutSaveChange.Enabled = true;
        }
        private void btnLayoutUpdateDisable(object sender, EventArgs e)
        {
            btnLayoutSaveChange.Enabled = false;
        }
        private void btnLayoutSaveNewEnable(object sender, EventArgs e)
        {
            btnLayoutSaveNew.Enabled = true;
        }
        private void btnLayoutAdditionTest(object sender, EventArgs e)
        {
            Layout lay = layoutBindingSource.Current as Layout;
            if (lay == null)
                return;
            if (lay.RefNum == 0)
            {
                btnLayoutDelete.Enabled = true;
            }
            else
            {
               btnLayoutDelete.Enabled = false;
            }
            btnLayoutSaveChange.Enabled =
            btnLayoutSaveNew.Enabled = false;
        }
        private void Tsmi_DropDownOpened(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            foreach (ToolStripMenuItem t in tsmi.DropDownItems)
            {
                t.Click += btnLayoutUpdateEnable;
            }
        }
        private void buttonDisableAfterPress(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.Enabled = false;
        } 
        #endregion

        private void layoutBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            Layout lay = layoutBindingSource.Current as Layout;
            if (lay == null)
                return;
            List<Position> posList = bllPos.SearchByLayout(lay.Id);
            FillDataGridView(posList);
        }
        private void hallBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            Hall hall = hallBindingSource.Current as Hall;
            if (hall == null)
                return;
            lblHallId.Text = hall.Id.ToString();
            txtHallName.Text = hall.Name;
            txtHallTheme.Text = hall.Theme;
            foreach (Layout layout in layoutBindingSource)
            {
                if (hall != null && layout.Id == hall.LayoutId)
                {
                    layoutBindingSource.Position = layoutBindingSource.IndexOf(layout);
                    break;
                }
            }

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
            #region 输入合法检测
            Layout layout = layoutBindingSource.Current as Layout;
            if (layout == null)
            {
                MessageBox.Show("请提供一个布局");
                txtStyle.Focus();
                return;
            }
            if (txtHallName.Text == string.Empty)
            {
                txtHallName.Focus();
                return;
            }
            foreach (Hall h in hallBindingSource)
            {
                if (h.Name == txtHallName.Text)
                {
                    MessageBox.Show("影厅名不能相同");
                    return;
                }
            }
            if (txtHallTheme.Text == string.Empty)
            {
                txtHallTheme.Focus();
                return;
            } 
            #endregion

            hall.LayoutId = layout.Id;
            hall.LayoutStyle = layout.Style;
            hall.Name = txtHallName.Text;
            hall.Theme = txtHallTheme.Text;

            try
            {
                hall.Id = bllHall.AddHall(hall);
                hallBindingSource.Insert(0,hall);
                hallBindingSource.Position = 0;
                layout.RefNum += 1;
            }
            catch (Exception)
            {
                MessageBox.Show("添加失败");
            }

        }
        private void btnHallSaveChange_Click(object sender, EventArgs e)
        {
            Hall hall = hallBindingSource.Current as Hall;
            #region 输入合法性检测
            Layout layout = layoutBindingSource.Current as Layout;
            if (hall == null)
                return;
            if (layout == null)
            {
                MessageBox.Show("请提供一个布局");
                txtStyle.Focus();
                return;
            }
            if (txtHallName.Text == string.Empty)
            {
                txtHallName.Focus();
                return;
            }
            if (txtHallTheme.Text == string.Empty)
            {
                txtHallTheme.Focus();
                return;
            }
            #endregion
            Layout old = null;
            foreach (Layout ly in layoutBindingSource)
            {
                if (ly.Id == hall.LayoutId)
                {
                    old = ly;
                    break;
                }
            }
            
            hall.LayoutId = layout.Id;
            hall.LayoutStyle = layout.Style;
            hall.Name = txtHallName.Text;
            hall.Theme = txtHallTheme.Text;

            try
            {
                bllHall.ResetHall(hall);
                old.RefNum -= 1;
                layout.RefNum += 1;
            }
            catch (Exception)
            {
                hall = bllHall.GetHall(hall.Id);
            }


        }
        private void btnHallDrop_Click(object sender, EventArgs e)
        {
            Hall hall = hallBindingSource.Current as Hall;
            if (hall == null)
                return;
            bllHall.DropHall(hall.Id);
            hallBindingSource.RemoveCurrent();
            Layout layout = layoutBindingSource.Current as Layout;
            if (layout == null) return;
            if (hall.LayoutId == layout.Id)
                layout.RefNum -= 1;
        }

        private void btnLayoutDelete_Click(object sender, EventArgs e)
        {
            Layout layout = layoutBindingSource.Current as Layout;
            if (layout == null || layout.RefNum != 0)
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
            Layout lay = layoutBindingSource.Current as Layout;
            PositionType positionType = positionTypeBindingSource.Current as PositionType;
            int rows = 0, cols = 0;
            #region 非法输入检测
            //名称不能为空 并且不能同名
            if (txtStyle.Text == string.Empty
                || lay != null && txtStyle.Text == lay.Style)
            {
                txtStyle.Focus();
                return;
            }
            // 行数与列数正确并且不能为0及以下
            if (txtRowNum.Text == string.Empty 
                || int.TryParse(txtRowNum.Text, out rows) == false
                || rows < 1)
            {
                txtRowNum.Focus();
                return;
            }
            if (txtColNum.Text == string.Empty 
                || int.TryParse(txtColNum.Text,out cols) == false
                || cols < 1)
            {
                txtColNum.Focus();
                return;
            }
            // 必须提供至少一个位置类型
            if (positionType == null)
            {
                MessageBox.Show("没有合适的位置类型");
                txtPositionTypeName.Focus();
                return;
            }
            #endregion
            Layout newLayout = new Layout();
            newLayout.Style = Convert.ToString(txtStyle.Text);
            newLayout.Id = bllLayout.AddLayout(newLayout);
            newLayout.RefNum = 0;
            layoutBindingSource.Insert(0, newLayout);
            layoutBindingSource.Position = 0;

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
            if (layout == null)
                return;
            bllPos.DropPositionBelongLayout(layout.Id);
            dgvPosition.SelectAll();
            foreach (DataGridViewCell cell in dgvPosition.SelectedCells)
            {
                Position p = cell.Value as Position;
                if (p == null) continue;
                p.LayoutId = layout.Id;
                p.Id = bllPos.AddPosition(p);
            }
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

        private void btnPositionTypeNew_Click(object sender, EventArgs e)
        {
            string newName = txtPositionTypeName.Text;
            if (newName == string.Empty)
            {
                txtPositionTypeName.Focus();
                return;
            }
            foreach (PositionType ptype in positionTypeBindingSource)
            {
                if (ptype.Name == newName)
                {
                    MessageBox.Show("已经有同名的位置类型");
                    return;
                }
            }
            try
            {
                PositionType pt = new PositionType();
                pt.Name = newName;
                pt.Id = bllPosType.AddNewPositionType(pt);
                positionTypeBindingSource.Insert(0, pt);
            }
            catch (Exception)
            {
            }
        }
        private void btnPositionTypeChangeName_Click(object sender, EventArgs e)
        {
            string newName = txtPositionTypeName.Text;
            foreach (PositionType  ptype in positionTypeBindingSource)
            {
                if (ptype.Name == newName)
                {
                    MessageBox.Show("已经有同名的位置类型");
                    return;
                }
            }
            PositionType pt = positionTypeBindingSource.Current as PositionType;
            try
            {
                pt.Name = newName;
                bllPosType.ResetPosition(pt);
            }
            catch (Exception)
            {
            }
        }
        private void btnPositionTypeDelete_Click(object sender, EventArgs e)
        {
            PositionType pt = positionTypeBindingSource.Current as PositionType;
            if (pt == null) return;
            try
            {
                bllPosType.RemovePositionTypeById(pt.Id);
                positionTypeBindingSource.RemoveCurrent();
            }
            catch (Exception)
            {
                MessageBox.Show("禁止删除");
            }
        }

        private void dgvPosition_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1) return;
            // 如果不是右键点击也不进行任何操作
            if (e.Button != MouseButtons.Right) return;
            // 设定右键菜单选项
            tsmiPositionTypeChange.DropDownItems.Clear();
            foreach (PositionType pt in positionTypeBindingSource)
            {
                ToolStripMenuItem tsmi = new ToolStripMenuItem();
                tsmi.Text = pt.Name;
                tsmi.Tag = pt;
                tsmi.Click += TsmiPositionTypeUpdate;
                tsmiPositionTypeChange.DropDownItems.Add(tsmi);
            }
            // 根据鼠标相对于屏幕左上角的坐标设置右键菜单
            // 这个位置不是相对于网络控件左上角的坐标
            cmsPosition.Show(MousePosition.X, MousePosition.Y);
        }
        private void TsmiPositionUseableStateUpdate(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            
            foreach (DataGridViewCell cell in dgvPosition.SelectedCells)
            {
                Position p = cell.Value as Position;
                p.UseAble = Convert.ToBoolean(tsmi.Tag);
            }
            dgvPosition.Refresh();
        }
        private void TsmiPositionTypeUpdate(object sender, EventArgs e)
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
            dgvPosition.Refresh();
        }

    }
}
