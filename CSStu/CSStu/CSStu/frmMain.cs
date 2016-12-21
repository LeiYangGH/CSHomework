using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSStu
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            Repository r = new Repository();
        }

        private void courseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCourses frmC = new frmCourses();
            frmC.ShowDialog();
        }
    }
}
