using System.Drawing;
using System.Windows.Forms;

namespace CSJigsaw
{
    public class JigButton : Button
    {
        public readonly Point initPoint;
        Point curPoint;
        public JigButton(Point p)
        {
            this.initPoint = p;
            this.curPoint = p;
        }

        public Point CurPoint
        {
            get
            {
                return this.curPoint;
            }
        }

        public void ShuffleTo(Point newPoint)
        {
            this.curPoint = newPoint;
        }

        //返回原来的点
        public Point MoveStep(int dx, int dy)
        {
            Point oldPoint = this.curPoint;
            this.curPoint.X += dx;
            this.curPoint.Y += dy;
            this.Left += this.Width * dx;
            this.Top += this.Height * dy;
            return oldPoint;
        }

        public bool IsBack()
        {
            return this.initPoint == this.curPoint;
        }
    }
}
