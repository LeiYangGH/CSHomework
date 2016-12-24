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
        private List<JigButton> lstJigButtons;
        public Form1()
        {
            InitializeComponent();
        }

        private void AddJigButtons()
        {
            int cnt = 0;
            Size btnSize = new Size(50, 50);
            this.lstJigButtons = new List<JigButton>();
            for (int j = 0; j < level; j++)
            {
                for (int i = 0; i < level; i++)
                {
                    JigButton btn = new JigButton(new Point(i, j));
                    btn.Size = btnSize;
                    btn.Text = (++cnt).ToString();
                    //tile.MouseLeftJigButtonDown += TileOnMouseLeftJigButtonDown; ;
                    btn.Left = 10 + i * btnSize.Width;
                    btn.Top = 10 + j * btnSize.Height;
                    this.lstJigButtons.Add(btn);
                    this.Controls.Add(btn);
                }
            }
            JigButton last = this.lstJigButtons.Last();
            this.Controls.Remove(last);
            this.lstJigButtons.Remove(last);
            this.btnsCount = this.level * this.level - 1;
        }

        private void Shuffle()
        {
            Random r = new Random();
            var randIds = Enumerable.Range(1, this.btnsCount)
                .OrderBy(x => r.Next()).ToArray();
            for (int i = 0; i < btnsCount; i++)
            {
                this.lstJigButtons[i].Text = randIds[i].ToString();
            }
        }

        private void btnShuffle_Click(object sender, EventArgs e)
        {
            this.Shuffle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.lstJigButtons.Last().MoveStep(0, -1);
            //this.lstJigButtons.Last().MoveStep(1, 0);
            this.lstJigButtons[11].MoveStep(0, 1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AddJigButtons();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }


    }
}
