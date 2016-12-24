using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSJigsaw
{
    public partial class Form1 : Form
    {
        public int level = 4;
        Keys[] keys = { Keys.Left, Keys.Right, Keys.Up, Keys.Down };
        int xEmpty, yEmpty, iCounter;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int cnt = 0;
            Size btnSize = new Size(50, 50);
            for (int j = 0; j < level; j++)
            {
                for (int i = 0; i < level; i++)
                {
                    Button btn = new Button();
                    btn.Size = btnSize;
                    btn.Text = (++cnt).ToString();
                    //tile.MouseLeftButtonDown += TileOnMouseLeftButtonDown; ;
                    btn.Left = 10 + i * btnSize.Width;
                    btn.Top = 10 + j * btnSize.Height;
                    this.Controls.Add(btn);
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }


    }
}
