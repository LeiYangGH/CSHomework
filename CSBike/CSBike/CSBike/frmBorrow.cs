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
    public partial class frmBorrow : Form
    {
        private string bike;
        private string user;

        public frmBorrow()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.btnOK.Enabled = false;
            this.bike = this.txtBike.Text.Trim();
            this.user = this.txtUser.Text.Trim();
            if (BikesHistory.Borrow(bike, user))
            {
                MessageBox.Show("借车成功！");
            }
            else
                MessageBox.Show("此车已经借出，不能再借！");
        }

        private void SetButtonEnable()
        {
            this.btnOK.Enabled = !string.IsNullOrWhiteSpace(this.txtBike.Text)
                && !string.IsNullOrWhiteSpace(this.txtUser.Text);
        }

        private void txtBike_TextChanged(object sender, EventArgs e)
        {
            this.SetButtonEnable();
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            this.SetButtonEnable();
        }
    }
}
