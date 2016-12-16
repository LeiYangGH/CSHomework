using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CSZoomShape
{
    public partial class Form1 : Form
    {
        private List<PointF> oldPoints = new List<PointF>();//原来的多边形的顶点集合
        private Line[] newLines;//新的多边形的边集合(顶点为任意取的两点)
        private PointF[] newPoints;//新的多边形的顶点集合

        //中心点坐标
        float centerX;
        float centerY;
        public Form1()
        {
            InitializeComponent();
        }
        private void DrawLine(PointF p1, PointF p2)
        {
            Graphics g = this.pictureBox1.CreateGraphics();
            g.DrawLine(Pens.Black, p1, p2);
        }

        private void DrawPolygon(Graphics g, Color color, PointF[] points)
        {
            g.DrawPolygon(new Pen(color), points);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    oldPoints.Add(new PointF(e.X, e.Y));
                    if (oldPoints.Count > 1)
                    {
                        this.DrawLine(oldPoints[oldPoints.Count - 2], oldPoints[oldPoints.Count - 1]);
                    }
                    break;

                case MouseButtons.Right:
                    if (oldPoints.Count > 2)
                    {
                        this.DrawLine(oldPoints[oldPoints.Count - 1], oldPoints[0]);
                    }
                    break;
            }
        }

        private void MarkPoint(float x, float y)
        {
            this.pictureBox1.CreateGraphics().FillEllipse(Brushes.Blue,
                x, y, 5, 5);
        }

        //用平均数求中心点
        private void FindCenterByAverage()
        {
            this.centerX = this.oldPoints.Average(x => x.X);
            this.centerY = this.oldPoints.Average(x => x.Y);
            this.MarkPoint(this.centerX, this.centerY);
        }

        //由于是循环遍历，所以要判断到结尾时跳转回去
        private int NextIndex(int i)
        {
            if (i < this.oldPoints.Count - 1)
                return i + 1;
            else
                return 0;
        }

        /// <summary>
        /// 求两直线交点https://en.wikipedia.org/wiki/Line%E2%80%93line_intersection
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <param name="x4"></param>
        /// <param name="y4"></param>
        /// <returns></returns>
        private PointF GetLinelineIntersection(double x1, double y1, double x2, double y2,
            double x3, double y3, double x4, double y4)
        {
            double common1 = (x1 * y2 - y1 * x2);
            double common2 = (x3 * y4 - y3 * x4);
            double common3 = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);
            double x = (common1 * (x3 - x4) - (x1 - x2) * common2) / common3;
            double y = (common1 * (y3 - y4) - (y1 - y2) * common2) / common3;
            return new PointF((float)x, (float)y);
        }

        private void CreateSamplePolygon()
        {
            int xoff = 100;
            int yoff = 100;
            this.oldPoints = new List<PointF>()
            {
                new PointF(2+xoff,-2+yoff),
                new PointF(98+xoff,2+yoff),
                new PointF(102+xoff,102+yoff),
                new PointF(58+xoff,152+yoff),
                new PointF(-4+xoff,96+yoff)
            };
            this.DrawPolygon(this.pictureBox1.CreateGraphics(), Color.Blue, this.oldPoints.ToArray());
        }
        private void btnSample_Click(object sender, EventArgs e)
        {
            this.CreateSamplePolygon();
        }

        private void GDITransformByCenter(Color color)
        {
            Graphics g = this.pictureBox1.CreateGraphics();
            //扩大系数，比如原来整体尺寸为1，后面变成1.5，系数为0.5
            //这个系数只是估算值，由于没显示尺寸也无法精确测量验证，所以简化算法
            float rate = 6.0f * ((float)this.numericUpDown1.Value /
                (Math.Abs(this.centerX) + Math.Abs(this.centerY)));

            //这里用到的知识点叫【GDI+ 坐标变换】
            //微软MSDN官方文档如下：
            //https://msdn.microsoft.com/zh-cn/library/3zxbwxch(v=vs.110).aspx

            //首先把坐标原点转移到中心点
            g.TranslateTransform(-this.centerX * rate, -this.centerY * rate);
            //再把坐标系按系数扩大
            g.ScaleTransform(rate + 1, rate + 1);
            //再用后面的坐标系绘制原来的点
            this.DrawPolygon(g, color, this.oldPoints.ToArray());
        }

        private void btnAveCenterZoom_Click(object sender, EventArgs e)
        {
            this.FindCenterByAverage();
            this.GDITransformByCenter(Color.Red);
        }


        //根据公式算平行直线和交点
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.FindCenterByAverage();
            this.MarkPoint(this.centerX, this.centerY);


            int dis = (int)this.numericUpDown1.Value;
            this.newLines = this.oldPoints.Select(p =>
              {
                  PointF A = p;
                  int bindex = this.NextIndex(this.oldPoints.IndexOf(p));
                  int cindex = this.NextIndex(bindex);
                  PointF B = this.oldPoints[bindex];
                  PointF C = this.oldPoints[cindex];
                  PointF center = new PointF();
                  center.X = (A.X + B.X + C.X) / 3.0f;
                  center.Y = (A.Y + B.Y + C.Y) / 3.0f;

                  Line line = new Line(A, B);
                  Line newLine = line.GetParallelLine(dis, center);
                  return newLine;
              }).ToArray();

            if (this.checkBox1.Checked)
                foreach (Line line in this.newLines)
                    this.DrawLine(line.Amax, line.Bmax);


            this.newPoints = this.newLines.Select(x =>
              {
                  Line line1 = x;
                  Line line2 = this.newLines[this.NextIndex(this.newLines.ToList().IndexOf(x))];
                  PointF p = this.GetLinelineIntersection(line1.Amax.X, line1.Amax.Y,
                     line1.Bmax.X, line1.Bmax.Y,
                     line2.Amax.X, line2.Amax.Y,
                     line2.Bmax.X, line2.Bmax.Y);
                  return p;
              }).ToArray();
            this.DrawPolygon(this.pictureBox1.CreateGraphics(), Color.Red, this.newPoints);
        }

    }

    public class Line
    {
        //ax + by + c = 0
        //y = kx + b // x = b

        //y2 = kx2 + b
        //y1 = kx1 + b
        //y2 + y1 = k(x2 + x1) + 2b
        //2b = (y2 + y1) - k(x2 + x1)
        public Line(PointF A, PointF B)
        {
            if (A.X == B.X)
            {
                this.IsVertical = true;
                this.b = A.X;
            }
            else
            {
                this.k = (B.Y - A.Y) / (B.X - A.X);
                this.b = ((B.Y + A.Y) - this.k * (B.X + A.X)) / 2.0d;
            }
            this.CalculateABBykb();
        }

        public Line(bool isVertical, double k, double b)
        {
            this.IsVertical = IsVertical;
            this.k = k;
            this.b = b;
            this.CalculateABBykb();
        }

        //两个随机取的点，根据斜率和截距可以计算
        public PointF Amax { get; set; }
        public PointF Bmax { get; set; }

        //垂直特殊处理
        public bool IsVertical { get; set; }

        //截距
        public double b { get; set; }

        //斜率
        public double k { get; set; }

        //计算随机取的AB点
        private void CalculateABBykb()
        {
            int max = 500;
            //y = kx + b // x = b
            Func<double, double> funcY = (x) => this.k * x + this.b;
            if (this.IsVertical)
            {
                this.Amax = new PointF((float)b, 0);
                this.Bmax = new PointF((float)this.b, max);
            }
            else
            {
                this.Amax = new PointF(0, (float)funcY(0));
                this.Bmax = new PointF(max, (float)funcY(max));
            }
        }

        //判断当前直线是否在中心外部（截距更大）
        private bool IsbGreaterThanCenter(PointF center)
        {
            //y = kx + b
            //c.y = k c.x + b
            return this.b > center.Y - this.k * center.X;//==?
        }

        //获取平行线
        public Line GetParallelLine(int distance, PointF center)
        {
            Line pline;
            double newb;
            if (this.IsVertical)
            {
                newb = distance;
            }
            else
            {
                double kAngle = Math.Atan(this.k);
                double coskAngle = Math.Cos(kAngle);
                double deltab = distance / coskAngle;
                //根据内外判断截距是+还是-
                newb = this.b + deltab * (this.IsbGreaterThanCenter(center) ? 1 : -1);
            }
            pline = new Line(this.IsVertical, k, newb);
            return pline;
        }
    }

}
