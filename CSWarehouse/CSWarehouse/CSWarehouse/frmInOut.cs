using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSWarehouse
{
    public partial class frmInOut : Form
    {
        public InOut InOut;
        //private bool isAdding;//是添加（还是编辑）
        //private bool isIn;//是入库（还是出库）
        public frmInOut()
        {
            InitializeComponent();
        }

        public frmInOut(bool isIn)
        {
            InitializeComponent();
            this.BindMaterials();

            this.InOut = new InOut();
            this.InOut.IsIn = isIn;
            this.Text = isIn ? "添加入库" : "添加出库";
            //this.isAdding = true;
        }

        public frmInOut(InOut inOut)
        {
            InitializeComponent();
            this.BindMaterials();

            this.InOut = inOut;
            this.Text = this.InOut.IsIn ? "编辑入库" : "编辑出库";
            this.SyncToControl();
            //this.isAdding = true;
        }

        private void SyncFromControl()
        {
            this.InOut.MID = (int)this.cboMaterial.SelectedValue;
            this.InOut.Quantity = (int)this.numQuatity.Value;
            this.InOut.Date = DateTime.Now;
        }

        private void SyncToControl()
        {
            this.cboMaterial.Text = this.InOut.Material.Name;
            //this.selecte.Text = this.InOut.Material.Name;
            this.numQuatity.Value = this.InOut.Quantity;
        }

        private void BindMaterials()
        {
            this.cboMaterial.DisplayMember = "Name";
            this.cboMaterial.ValueMember = "ID";
            this.cboMaterial.DataSource = DAL.GetAllMaterials();
        }

        private void frmInOut_Load(object sender, EventArgs e)
        {
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.SyncFromControl();
            this.DialogResult = DialogResult.OK;
        }
    }
}
