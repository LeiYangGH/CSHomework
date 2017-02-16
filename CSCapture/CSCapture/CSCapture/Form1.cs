using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSCapture
{
    public partial class frmMain : Form
    {
        string dir = "Captures";

        public frmMain()
        {
            InitializeComponent();
        }

        private void CreateDirectory()
        {
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
        }

        private void CaptureEntireScreen(string fileName)
        {
            var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                           Screen.PrimaryScreen.Bounds.Height,
                                           PixelFormat.Format32bppArgb);

            var gfxScreenshot = Graphics.FromImage(bmpScreenshot);

            gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                        Screen.PrimaryScreen.Bounds.Y,
                                        0,
                                        0,
                                        Screen.PrimaryScreen.Bounds.Size,
                                        CopyPixelOperation.SourceCopy);

            bmpScreenshot.Save(fileName, ImageFormat.Png);
        }

        private string GenerateTimeFileName()
        {
            string timeString = DateTime.Now.ToString("HHmmss");
            string fileName = Path.Combine(Environment.CurrentDirectory, dir, timeString);
            return fileName + ".png";

        }

        private void btnDesktop_Click(object sender, EventArgs e)
        {
            string fileName = this.GenerateTimeFileName();
            this.CaptureEntireScreen(fileName);
            MessageBox.Show(fileName);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.CreateDirectory();
        }

        private void btnCalculator_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
        }

        private int tickCount = 5;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tickCount-- <= 0)
            {
                this.timer1.Enabled = false;
                //ScreenCapturer capturer = new ScreenCapturer();

                //Bitmap bm = ScreenCapturer1.Capture();

                ScreenCapture2 capturer = new ScreenCapture2();

                Image bm = capturer.CaptureFougroundWindow();

                string fileName = this.GenerateTimeFileName();
                bm.Save(fileName, ImageFormat.Png);
                //MessageBox.Show(fileName);
            }
            else
            {
                this.Text = "倒计时：" + tickCount.ToString();
            }
        }
    }
}
