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
        private int level = 3;
        private int btnsCount;
        private Size btnSize = new Size(50, 50);
        private List<JigButton> lstButtons;
        private Point blankPoint;
        private int stepsCount;
        public Form1()
        {
            InitializeComponent();
        }

        private void AddJigButtons()
        {
            int cnt = 0;
            this.lstButtons = new List<JigButton>();
            this.panel1.Controls.Clear();
            for (int j = 0; j < this.level; j++)
            {
                for (int i = 0; i < this.level; i++)
                {
                    JigButton btn = new JigButton(new Point(i, j));
                    btn.Size = btnSize;
                    btn.Text = (++cnt).ToString();
                    btn.Click += Btn_Click;
                    btn.Left = 10 + i * btnSize.Width;
                    btn.Top = 10 + j * btnSize.Height;
                    this.lstButtons.Add(btn);
                    this.panel1.Controls.Add(btn);
                }
            }
            JigButton last = this.lstButtons.Last();
            this.panel1.Controls.Remove(last);
            this.lstButtons.Remove(last);
            this.btnsCount = this.level * this.level - 1;
            this.blankPoint = new Point(this.level - 1, this.level - 1);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            JigButton btn = sender as JigButton;

            if (btn.CurPoint.X == this.blankPoint.X)
            {
                if (btn.CurPoint.Y == this.blankPoint.Y - 1)
                {
                    this.blankPoint = btn.MoveStep(0, 1);
                    this.stepsCount++;
                }
                else if (btn.CurPoint.Y == this.blankPoint.Y + 1)
                {
                    this.blankPoint = btn.MoveStep(0, -1);
                    this.stepsCount++;
                }
            }
            else if (btn.CurPoint.Y == this.blankPoint.Y)
            {
                if (btn.CurPoint.X == this.blankPoint.X - 1)
                {
                    this.blankPoint = btn.MoveStep(1, 0);
                    this.stepsCount++;
                }
                else if (btn.CurPoint.X == this.blankPoint.X + 1)
                {
                    this.blankPoint = btn.MoveStep(-1, 0);
                    this.stepsCount++;
                }
            }
            this.lblSteps.Text = "步数：" + this.stepsCount.ToString();
            if (this.CheckSucceed())
            {
                MessageBox.Show("恭喜你成功！");
            }
        }

        private void Shuffle()
        {
            Random r = new Random();
            var randPoints = this.lstButtons.Select(x => x.CurPoint)
                 .OrderBy(x => r.Next()).ToArray();
            for (int i = 0; i < btnsCount; i++)
            {
                JigButton btn = this.lstButtons[i];
                Point p = randPoints[i];
                btn.ShuffleTo(p);
                btn.Left = 10 + p.X * btnSize.Width;
                btn.Top = 10 + p.Y * btnSize.Height;
            }
            this.stepsCount = 0;
        }

        private void btnShuffle_Click(object sender, EventArgs e)
        {
            this.Shuffle();
        }

        private bool CheckSucceed()
        {
            return this.lstButtons.All(x => x.IsBack());
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.AddJigButtons();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.level = (int)this.numericUpDown1.Value;
            this.AddJigButtons();
        }
    }
}
