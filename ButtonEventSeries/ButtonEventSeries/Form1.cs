using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ButtonEventSeries
{
    public partial class Form1 : Form
    {
        Action[] acts;
        public Form1()
        {
            InitializeComponent();
            this.acts = new Action[]
            {
                ()=> this.button1_Click(null,null),
                ()=> this.button2_Click(null,null),
                ()=> this.button3_Click(null,null),
                ()=> this.button4_Click(null,null),
            };
        }

        private void AddText(string txt)
        {
            this.textBox1.Text += $"{txt}\r\n";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.AddText("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.AddText("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.AddText("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.AddText("4");
        }

        bool Done;
        private void button5_Click(object sender, EventArgs e)
        {

            if (this.Done)
                this.timer1.Stop();
            else
            {
                this.Done = true;
                this.timer1.Start();
            }
        }

        private int cnt = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.acts[++this.cnt % this.acts.Length].Invoke();
        }
    }
}
