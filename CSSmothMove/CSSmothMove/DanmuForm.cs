using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSSmothMove
{
    public partial class DanmuForm : Form
    {
        public DanmuForm()
        {
            InitializeComponent();
            this.userAccount = "userAccount";
            this.userDanmuText = "userDanmuText";
            this.locationX = 1000;
            this.locationY = 100;
            this.formOpacity = 90;
            this.formSpeed = 1;
            this.formStepLength = 1;

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.  
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
        }
        string userAccount = "";
        string userDanmuText = "";
        int locationX = 0;
        int locationY = 0;
        int formOpacity = 0;
        int formSpeed = 0;
        int formStepLength = 0;

        private void DanmuForm_Load(object sender, EventArgs e)
        {
            //设置控件
            label1.Text = userDanmuText;
            this.Width = label1.Width + 40;
            //
            Timer changeFormLocationTimer = new Timer();
            changeFormLocationTimer.Interval = formSpeed;
            changeFormLocationTimer.Tick += new EventHandler(changeFormLocationThings);
            changeFormLocationTimer.Start();
            //
            //Form1.danmuFormShowCount++;
        }

        private void changeFormLocationThings(object sender, EventArgs e)
        {
            //设置透明度
            if (this.Opacity == 0)
            {
                this.Opacity = formOpacity / 100.0;
            }
            //改变位置
            this.Location = new Point(locationX -= formStepLength, locationY);
            //检测关闭
            if (this.Location.X + this.Width < 0)
                this.Close();
        }

        #region 重绘窗体圆角
        private void DanmuForm_Paint(object sender, PaintEventArgs e)
        {
            SetWindowRegion();

        }
        public void SetWindowRegion()
        {
            GraphicsPath FormPath;
            FormPath = new System.Drawing.Drawing2D.GraphicsPath();
            Rectangle rect = new Rectangle(-1, -1, this.Width + 1, this.Height);
            FormPath = GetRoundedRectPath(rect, 24);
            this.Region = new Region(FormPath);
        }
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();
            //   左上角   
            path.AddArc(arcRect, 185, 90);
            //   右上角   
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 275, 90);
            //   右下角   
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 356, 90);
            //   左下角   
            arcRect.X = rect.Left;
            arcRect.Width += 2;
            arcRect.Height += 2;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();
            return path;
        }
        #endregion

        private void DanmuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Form1.danmuFormShowCount--;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //this.Invalidate();
        }
    }
}
