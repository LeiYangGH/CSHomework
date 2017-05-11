using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MrSmarty.CodeProject
{
    public partial class Form2 : Form
    {
        FloatingOSDWindow osd = new FloatingOSDWindow();
        private Image circleBmp;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        int x = 10;
        private void timer1_Tick(object sender, EventArgs e)
        {
            x += 1;
            this.osd.Show(new Point(x, 1), 120,
                Color.Green,
                new Font("Microsoft Sans Serif", 72f, FontStyle.Regular),
                1800,
                //FloatingWindow.AnimateMode.Blend,
                //FloatingWindow.AnimateMode.RollTopToBottom,
                FloatingWindow.AnimateMode.SlideRightToLeft,
                0, "hello world!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = (Bitmap)Image.FromFile("img.png");
            this.circleBmp = this.CropToCircle(bmp, Color.Black);
            this.pictureBox1.Image = circleBmp;
        }

        private Image CropToCircle(Image srcImage, Color backGround)
        {
            //Image dstImage = new Bitmap(srcImage.Width, srcImage.Height, srcImage.PixelFormat);
            Image dstImage = new Bitmap(200, 200, srcImage.PixelFormat);
            Graphics g = Graphics.FromImage(dstImage);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            using (Brush br = new SolidBrush(backGround))
            {
                g.FillRectangle(br, 0, 0, dstImage.Width, dstImage.Height);
            }
            GraphicsPath path = new GraphicsPath();
            //path.AddEllipse(0, 0, dstImage.Width, dstImage.Height);
            path.AddEllipse(0, 0, dstImage.Width, dstImage.Height);
            g.SetClip(path);
            g.DrawImage(srcImage, 0, 0);

            return dstImage;
        }
    }
}
