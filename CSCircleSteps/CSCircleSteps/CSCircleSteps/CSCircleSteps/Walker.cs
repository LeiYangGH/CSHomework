using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSCircleSteps
{
    public class Walker
    {
        public Walker()
        {
            this.historyLocations = new List<Point>();
            this.historyMoves = new List<Point>();
            //原点比较特殊，单独加
            Point p0 = new Point(0, 0);
            this.currentLocation = p0;
            this.historyLocations.Add(p0);
            this.historyMoves.Add(p0);
        }

        /// <summary>
        /// 添加一圈
        /// </summary>
        /// <param name="layer">圈数</param>
        public void AddLayer(int layer)
        {
            //int cnt = layer * (layer + 1) * 4 + 1;//这个公式是我推了半天得到的，根据圈数求总步数（包括0）
#if DEBUG
            Console.WriteLine("---layer={0}---", layer);
#endif
            this.Move(-1, 0);//第一个是上一圈结束往左移
            int layer2 = layer * 2;
            //4个边依次加
            for (int y = 1; y <= layer2 - 1; y++)
            {
                this.Move(0, -1);
            }
            for (int x = 1; x <= layer2; x++)
            {
                this.Move(1, 0);
            }
            for (int y = 1; y <= layer2; y++)
            {
                this.Move(0, 1);
            }
            for (int x = 1; x <= layer2; x++)
            {
                this.Move(-1, 0);
            }
        }

        //相对上次移动某个距离
        private void Move(int dx, int dy)
        {
            this.currentLocation.X += dx;
            this.currentLocation.Y += dy;
            this.historyMoves.Add(new Point(dx, dy));
            this.HistoryLocations.Add(this.currentLocation);
#if DEBUG
            Console.WriteLine(this.currentLocation);
#endif
        }

        //当前位置
        private Point currentLocation;
        public Point CurrentLocation
        {
            get
            {
                return this.currentLocation;
            }
        }

        //所有历史位置
        private List<Point> historyLocations;
        public List<Point> HistoryLocations
        {
            get
            {
                return this.historyLocations;
            }
        }

        //所有历史位移
        private List<Point> historyMoves;
        public List<Point> HistoryMoves
        {
            get
            {
                return this.historyMoves;
            }
        }
    }
}
