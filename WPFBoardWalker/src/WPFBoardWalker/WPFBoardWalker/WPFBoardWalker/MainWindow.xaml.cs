using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFBoardWalker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Board board;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.canvas1.Columns = 10;
            this.canvas1.Rows = 10;
            this.board = new Board(this.canvas1, 10, 10);
            this.canvas1.Focus();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            string k = e.Key.ToString();
            this.Title = k;
            switch (k)
            {
                case "Up":
                    this.board.currentPlayer.Move(Direction.Up);
                    break;
                case "Right":
                    this.board.currentPlayer.Move(Direction.Right);
                    break;
                case "Down":
                    this.board.currentPlayer.Move(Direction.Down);
                    break;
                case "Left":
                    this.board.currentPlayer.Move(Direction.Left);
                    break;
                default:
                    break;
            }
        }

        private void rdbRed_Checked(object sender, RoutedEventArgs e)
        {
            if (this.board != null)
                this.board.currentPlayer = this.board.redPlayer;
        }

        private void rdbBlue_Checked(object sender, RoutedEventArgs e)
        {
            if (this.board != null)
                this.board.currentPlayer = this.board.bluePlayer;
        }
    }
}
