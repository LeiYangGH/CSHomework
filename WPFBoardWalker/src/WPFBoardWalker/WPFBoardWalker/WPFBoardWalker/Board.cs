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
    public class Board
    {
        public static Board Instance;
        public readonly int gridWidth;
        public readonly int gridHeight;
        private readonly Panel canvas1;
        public Player redPlayer;
        public Player bluePlayer;
        public Player currentPlayer;
        private List<Grid> lstGrids;
        private Grid[,] Grids;


        public Board(Panel canvas, int gridWidth, int gridHeight)
        {
            this.canvas1 = canvas;
            this.gridWidth = gridWidth;
            this.gridHeight = gridHeight;
            Board.Instance = this;
            this.InitGrids();
            this.Init2Players();
        }

        private void Init2Players()
        {
            this.redPlayer = new Player(Side.Red, this.Grids[this.gridWidth / 2, 0]);
            this.bluePlayer = new Player(Side.Blue, this.Grids[this.gridWidth / 2, this.gridHeight - 1]);
            this.currentPlayer = this.redPlayer;
        }

        private void AddGridsButtonsToPanel()
        {
            this.canvas1.Children.Clear();

            foreach (Button b in this.lstGrids
                .Select(x => x.button))
            {
                this.canvas1.Children.Add(b);
            }
        }

        private void InitGrids()
        {
            this.lstGrids = new List<Grid>();
            this.Grids = new Grid[this.gridWidth, this.gridHeight];
            for (int y = 0; y < this.gridHeight; y++)
                for (int x = 0; x < this.gridWidth; x++)
                {
                    Grid grid = new Grid(new Point(x, y));
                    this.Grids[x, y] = grid;
                    this.lstGrids.Add(grid);
                    if (x > 0)
                    {
                        grid.SetLeftGrid(this.Grids[x - 1, y]);
                    }
                    if (y > 0)
                    {
                        grid.SetUpGrid(this.Grids[x, y - 1]);
                    }
                }
            this.AddGridsButtonsToPanel();
        }
    }
}
