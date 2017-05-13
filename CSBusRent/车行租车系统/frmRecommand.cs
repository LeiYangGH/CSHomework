using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 车行租车系统
{
    public partial class frmRecommand : Form
    {
        public frmRecommand()
        {
            InitializeComponent();
            this.GetRandCarImage();
        }

        private void GetRandCarImage()
        {
            var r = new Random();
            Bitmap[] bmp = Directory.GetFiles("Image", "*.jpg")
                .OrderBy(x => r.Next()).Take(3).Select(x => (Bitmap)Image.FromFile(x)).ToArray();

            this.pictureBox1.Image = bmp[0];
            this.pictureBox2.Image = bmp[1];
            this.pictureBox3.Image = bmp[2];
        }

        public Image GetImage()
        {
            Bitmap b = new Bitmap(this.panel1.Width, this.panel1.Height);
            this.panel1.DrawToBitmap(b, new Rectangle(0, 0, b.Width, b.Height));
            return b;
        }

        private void frmRecommand_Load(object sender, EventArgs e)
        {
        }
    }
}
