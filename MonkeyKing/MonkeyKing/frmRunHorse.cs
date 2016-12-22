using System;
using System.Windows.Forms;

namespace MonkeyKing
{
    public partial class frmRunHorse : Form
    {
        int picIndex = 0;
        string[] pics =
        {
            "Capture1.png",
            "Capture2.png",
            "Capture3.png",
            "Capture4.png",
            "Capture5.png",
            "Capture6.png",
        };
        public frmRunHorse()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.timer1.Interval = (int)(2000.0f / this.trackBar1.Value);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.pictureBox1.ImageLocation = this.pics[this.picIndex++ % pics.Length];
        }

        private void frmRunHorse_Load(object sender, EventArgs e)
        {
            this.trackBar1.Value = 5;
            this.timer1.Enabled = true;
            this.Width = 800;
            this.Height = 800;
            this.pictureBox1.Width = 790;
            this.pictureBox1.Height = 700;
        }
    }
}
