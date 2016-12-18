using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPFBoardWalker
{
    public class Grid
    {
        public readonly Point point;
        public readonly Button button;
        private Dictionary<Direction, Grid> nextGrid = new Dictionary<Direction, Grid>();
        public Grid(Point point)
        {
            this.button = new Button();
            this.button.Width = 30;
            this.button.Height = 30;
            this.button.Click += (s, e) =>
              {
                  this.button.Background = Board.Instance.currentPlayer == Board.Instance.bluePlayer ? Brushes.Blue : Brushes.Red;
              };
        }

        public void SetLeftGrid(Grid nextGrid)
        {
            this.nextGrid[Direction.Left] = nextGrid;
            nextGrid.nextGrid[Direction.Right] = this;
        }

        public void SetUpGrid(Grid nextGrid)
        {
            this.nextGrid[Direction.Up] = nextGrid;
            nextGrid.nextGrid[Direction.Down] = this;
        }

        public Grid NextGrid(Direction direction)
        {
            try
            {
                return this.nextGrid[direction];

            }
            catch (Exception)
            {
                return null;
            }
        }

        public void ShowPlayer(Side side)
        {
            this.button.Content = "P";
            this.button.FontSize = 16;
            this.button.Foreground = side == Side.Blue ? Brushes.Blue : Brushes.Red;
            this.button.Background = SystemColors.ControlBrush;
        }
    }
}
