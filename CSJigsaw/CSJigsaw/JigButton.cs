using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSJigsaw
{
    public class JigButton : Button
    {
        Point curPoint;
        public JigButton(Point p)
        {
            this.curPoint = p;
        }

        public Point CurPoint
        {
            get
            {
                return this.curPoint;
            }
        }

        public void MoveStep(int dx, int dy)
        {
            this.curPoint.X += dx;
            this.curPoint.Y += dy;
            this.Left += this.Width * dx;
            this.Top += this.Height * dy;
        }
    }
}
