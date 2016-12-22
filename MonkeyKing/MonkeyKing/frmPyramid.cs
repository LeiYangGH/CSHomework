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

        private bool CheckInput(out int delta, out int layer)
        {
            delta = (int)this.numericUpDown1.Value;
            layer = (int)this.numericUpDown2.Value;
            if (delta % 2 != 0)
            {
                MessageBox.Show("每行多的应该是偶数！");
                return false;
            }
            else
                return true;
        }

        private void DrawPyramid(Graphics g, int delta, int layer)
        {
            for (int lay = 0; lay < layer; lay++)
            {
                int dx = 9;
                int xm = lay * delta / 2 * dx;
                int y = lay * 10;
                for (int x = 0; x < xm; x += dx)
                {
                    DrawAt(g, x, y);
                    DrawAt(g, -x, y);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Graphics g = this.pictureBox1.CreateGraphics();
            g.TranslateTransform(this.pictureBox1.Width / 2, 0);

            int delta;
            int layer;
            g.Clear(SystemColors.Control);
            if (this.CheckInput(out delta, out layer))
            {
                this.DrawPyramid(g, delta, layer);
            }
        }

        private void DrawAt(Graphics g, int x, int y)
        {
            g.DrawString("G", this.Font, Brushes.Black, new Point(x, y));

        }
    }
}
