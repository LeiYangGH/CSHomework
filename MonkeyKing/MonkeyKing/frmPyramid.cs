using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonkeyKing
{
    public partial class frmPyramid : Form
    {
        public frmPyramid()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {

        }

        private void frmPyramid_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = this.pictureBox1.CreateGraphics();
            g.TranslateTransform(this.pictureBox1.Width / 2, 10);
            DrawAt(g, -10, -10);
        }

        private void DrawAt(Graphics g, int x, int y)
        {
            g.DrawString("G", this.Font, Brushes.Black, new Point(x, y));

        }
    }
}
