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
        private void btnDesktop_Click(object sender, EventArgs e)
        {
            string timeString = DateTime.Now.ToString("HHmmss");
            string fileName = Path.Combine(Environment.CurrentDirectory, dir, timeString);
            this.CaptureEntireScreen(fileName + ".png");
            MessageBox.Show(fileName);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.CreateDirectory();
        }
    }
}
