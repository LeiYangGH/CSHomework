using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSTreeGrid.DAL;
namespace CSTreeGrid
{
    public partial class frmMain : Form
    {
        private IGoodsRepository goodsRepository;//数据提供者
        private BindingList<Goods> lstGoods;//绑定的表
        public frmMain()
        {
            InitializeComponent();

        }

        /// <summary>
        /// 调用的是这个构造函数
        /// </summary>
        /// <param name="goodsRepository"></param>
        public frmMain(IGoodsRepository goodsRepository) : this()
        {
            this.goodsRepository = goodsRepository;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定要退出吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// 根据是否特价查看
        /// </summary>
        private void ViewAllGoods()
        {
            bool? isSpecial = this.GetIsSpecialFromTreeView();
            List<Goods> lst = this.goodsRepository.ViewGoods(isSpecial).ToList();
            this.lstGoods = new BindingList<Goods>(lst);
            this.dgvGoods.DataSource = this.lstGoods;
        }

        /// <summary>
        /// 根据树节点的选择状态判断应该显示的价格种类
        /// </summary>
        /// <returns></returns>
        private bool? GetIsSpecialFromTreeView()
        {
            TreeNode selNode = this.tvwCategory.SelectedNode;
            if (selNode != null)
            {
                switch (selNode.Name)
                {
                    case "nodeNormal":
                        return true;
                    case "nodeSpecial":
                        return false;
                    case "nodeRoot":
                        return null;
                    default:
                        return null;
                }
            }
            return null;
        }

        /// <summary>
        /// 加载窗体自动显示所有数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.tvwCategory.ExpandAll();
            this.ViewAllGoods();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmEditor editor = new frmEditor();
            if (editor.ShowDialog() == DialogResult.OK)
            {
                this.goodsRepository.AddGoods(editor.goods);
                //添加后重新查询、绑定数据，保证一致性
                //也有其他做法，不用再查询加载，而只添加一行，
                //但那样验证逻辑要复杂一点，
                //下同
                this.ViewAllGoods();
            }
        }

        /// <summary>
        /// 获取选中的第一行
        /// </summary>
        /// <returns></returns>
        private Goods GetFirstSelectedGoods()
        {
            var selectedRows = this.dgvGoods.SelectedRows;
            if (selectedRows == null)
                return null;
            else
            {
                int id = (int)selectedRows[0].Cells[0].Value;
                return this.lstGoods.First(x => x.Id == id);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Goods selGoods = this.GetFirstSelectedGoods();
            if (selGoods != null)
            {
                frmEditor editor = new frmEditor(selGoods);
                int oldId = selGoods.Id;
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    this.goodsRepository.EditGoods(oldId, selGoods);
                    this.ViewAllGoods();
                }
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Goods selGoods = this.GetFirstSelectedGoods();
            this.goodsRepository.DeleteGoods(selGoods.Id);
            this.ViewAllGoods();

        }

        private void tvwCategory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.ViewAllGoods();
        }
    }
}