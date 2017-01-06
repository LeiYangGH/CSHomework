using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSPluginDemo
{
    public partial class frmContainer : Form
    {
        public frmContainer()
        {
            InitializeComponent();
        }

        private void 容器菜单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("容器自带菜单而已");
        }
    }
}
