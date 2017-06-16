using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigJob
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void 系统管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManagement sm = new SystemManagement();
            sm.MdiParent = this;
            sm.WindowState = FormWindowState.Maximized;//以最大化形式打开
            sm.Show();
        }
    }
}
