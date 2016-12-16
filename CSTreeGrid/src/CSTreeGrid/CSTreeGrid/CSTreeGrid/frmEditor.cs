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
    public partial class frmEditor : Form
    {
        public Goods goods;//待编辑或增加的商品
        private bool isAdding;//是添加（还是编辑）

        /// <summary>
        /// 添加时调用的构造函数
        /// </summary>
        public frmEditor()
        {
            InitializeComponent();
            this.goods = new Goods();
            this.isAdding = true;
        }
        /// <summary>
        /// 编辑时调用的构造函数
        /// </summary>
        /// <param name="goods"></param>
        public frmEditor(Goods goods) : this()
        {
            this.goods = goods;
            this.isAdding = false;
            this.SyncFromGoodsToControl();
            //
        }

        /// <summary>
        /// 把（编辑时）传进来的商品信息显示到控件
        /// </summary>
        private void SyncFromGoodsToControl()
        {
            //if (!this.isAdding)
            //    this.txtGoodsName.Enabled = false;
            this.txtGoodsName.Text = this.goods.Name;
            this.cboCatetory.Text = this.goods.Category;
            this.numPrePrice.Value = (int)this.goods.PrePrice;
            this.numPrice.Value = (int)this.goods.Price;
            this.chkIsSpecial.Checked = this.goods.isSpecial;
        }

        /// <summary>
        /// 把控件信息传递到商品
        /// </summary>
        private void SyncFromControlToGoods()
        {
            this.goods.Name = this.txtGoodsName.Text;
            this.goods.Category = this.cboCatetory.Text;
            this.goods.isSpecial = this.chkIsSpecial.Checked;
            this.goods.PrePrice = (double)this.numPrePrice.Value;
            this.goods.Price = (double)this.numPrice.Value;
            this.numPrice.Text = this.goods.Price.ToString();
        }



        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.SyncFromControlToGoods();
            this.DialogResult = DialogResult.OK;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //TODO:验证逻辑，比如重复、空值等
            this.SyncFromControlToGoods();
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
