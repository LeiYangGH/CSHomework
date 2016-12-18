using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPFBoardWalker
{
    public class Player
    {
        public readonly Side side;
        //private Player redPlayer;
        private Grid currentGrid;
        public Player(Side side, Grid initGrid)
        {
            this.side = side;
            this.currentGrid = initGrid;
            this.ShowMe();
        }

        public void Move(Direction direction)
        {
            Grid nextGrid = this.currentGrid.NextGrid(direction);
            if (nextGrid != null &&
                (nextGrid.button.Background == Brushes.Red
                || nextGrid.button.Background == Brushes.Blue
                || nextGrid.button.Content?.ToString() == "P")
                )
            {
                this.currentGrid.button.Background = this.currentGrid.button.Foreground;
                this.currentGrid = this.currentGrid.NextGrid(direction);
                this.ShowMe();
            }
        }

        private void ShowMe()
        {
            this.currentGrid.ShowPlayer(this.side);
        }
    }
}
