using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSBike
{
    public partial class frmBikeDetail : Form
    {
        clsBike theBike;
        public frmBikeDetail(clsBike tmp)
        {
            InitializeComponent();
            theBike = tmp;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Empty ID is not allowed.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(clsData.isExist(txtID.Text))
            {
                MessageBox.Show("ID duplicated.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            theBike.ID = txtID.Text;
            theBike.Price =(float) numPrice.Value;
            theBike.DOP = dpDOP.Value;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void frmBikeDetail_Load(object sender, EventArgs e)
        {
            txtID.Text = theBike.ID;
            numPrice.Value = (decimal)theBike.Price;
            dpDOP.Value = theBike.DOP;
        }
    }
}
