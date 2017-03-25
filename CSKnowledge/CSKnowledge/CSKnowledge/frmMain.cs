using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //KB kb = DBHelper.GetKnowledge(1);
            //Image img;
            //using (var ms = new MemoryStream(kb.Pic))
            //{
            //    img = Image.FromStream(ms);
            //}

            //this.pictureBox1.Image = img;
        }
    }
}
