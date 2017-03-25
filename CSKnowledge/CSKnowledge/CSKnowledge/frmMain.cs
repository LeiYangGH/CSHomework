using System;
using System.Windows.Forms;

namespace CSKnowledge
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAdd frm = new frmAdd();
            frm.ShowDialog();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            frmView frm = new frmView();
            frm.ShowDialog();
        }
    }
}
