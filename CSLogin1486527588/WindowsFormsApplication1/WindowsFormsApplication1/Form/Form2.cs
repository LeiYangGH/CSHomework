using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void tsmnAbout_Click(object sender, EventArgs e)
        {
            frAbout fa = new frAbout();
            fa.Show();
        }

        private void tsmnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 药品查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
        }

        private void tsmnCourse_Click(object sender, EventArgs e)
        {
            Mulu ml = new Mulu();
            ml.Show();
        }
    }
}
