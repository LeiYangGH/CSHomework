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
        public int btnsCount;
        Keys[] keys = { Keys.Left, Keys.Right, Keys.Up, Keys.Down };
        int xEmpty, yEmpty, iCounter;
        private List<Button> lstButtons;
        public Form1()
        {
            InitializeComponent();
        }

        private void AddButtons()
        {
            int cnt = 0;
            Size btnSize = new Size(50, 50);
            this.lstButtons = new List<Button>();
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
                    this.lstButtons.Add(btn);
                    this.Controls.Add(btn);
                }
            }
            Button last = this.lstButtons.Last();
            this.Controls.Remove(last);
            this.lstButtons.Remove(last);
            this.btnsCount = this.level * this.level - 1;
        }

        private void Shuffle()
        {
            Random r = new Random();
            var randIds = Enumerable.Range(1, this.btnsCount)
                .OrderBy(x => r.Next()).ToArray();
            for (int i = 0; i < btnsCount; i++)
            {
                this.lstButtons[i].Text = randIds[i].ToString();
            }
        }

        private void btnShuffle_Click(object sender, EventArgs e)
        {
            this.Shuffle();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AddButtons();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }


    }
}
