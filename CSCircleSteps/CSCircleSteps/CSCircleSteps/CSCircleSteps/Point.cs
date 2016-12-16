using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSCircleSteps
{
    public struct Point
    {
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public int X;
        public int Y;
        public override string ToString()
        {
            return string.Format("{0} , {1}", this.X, this.Y);
        }

        public string MoveFromLastStepString()
        {
            return string.Format("相对移动\t\t{0}\t{1}\t{2}\t{3}",
                 this.Y == 1 ? 1 : 0,
                 this.X == 1 ? 1 : 0,
                 this.Y == -1 ? 1 : 0,
                 this.X == -1 ? 1 : 0
                );
        }

        public string MoveFromStep0String()
        {
            return string.Format("绝对移动\t\t{0}\t{1}\t{2}\t{3}",
                this.Y > 0 ? this.Y : 0,
                this.X > 0 ? this.X : 0,
                this.Y < 0 ? -this.Y : 0,
                this.X < 0 ? -this.X : 0
                );
        }
    }
}
