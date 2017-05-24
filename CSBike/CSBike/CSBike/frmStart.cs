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
    public partial class frmStart : Form
    {
        public frmStart()
        {
            InitializeComponent();
        }

        private void btnBike_Click(object sender, EventArgs e)
        {
            frmBike p = new frmBike();
            p.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            frmUsers frm = new frmUsers(false);
            frm.ShowDialog();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            frmSuperPassword frmSuper = new frmSuperPassword();
            var result = frmSuper.ShowDialog();
            if (result == DialogResult.OK)
            {
                frmUsers frm = new frmUsers(true);
                frm.ShowDialog();
            }
            else if (result == DialogResult.Cancel)
            {
                this.btnAdmin.Enabled = false;
            }

        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            frmBorrow frm = new frmBorrow();
            frm.ShowDialog();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            frmReturn frm = new frmReturn();
            frm.ShowDialog();
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            frmBikeHistory frm = new frmBikeHistory();
            frm.ShowDialog();
        }

        private void frmStart_Load(object sender, EventArgs e)
        {
            BikesHistory.ReadHistory();
        }

        private void frmStart_FormClosing(object sender, FormClosingEventArgs e)
        {
            BikesHistory.SaveHistory();
        }
    }
}
