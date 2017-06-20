using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginLogDemo
{
    public partial class frmMain : Form
    {
        private frmLog frmL = new frmLog();
        public frmMain()
        {
            InitializeComponent();
            frmL.MdiParent = this;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            var result = frm.ShowDialog();
            if (result != DialogResult.OK)
            {
                this.Close();
            }
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmL.Show();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Repository.AddLogout();
        }
    }
}
