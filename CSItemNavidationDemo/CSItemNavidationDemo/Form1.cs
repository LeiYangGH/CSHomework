using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSItemNavidationDemo
{
    public partial class Form1 : Form
    {
        private string fileName = "data.txt";
        private List<List<string>> lines;
        private TextBox[] txts;
        private int curIndex = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void ReadFile()
        {
            this.lines = new List<List<string>>();
            if (File.Exists(fileName))
            {

                foreach (var line in File.ReadLines(this.fileName, Encoding.UTF8))
                {
                    string[] ss = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    this.lines.Add(ss.ToList());
                }
            }
        }

        private void ShowItem(List<string> line)
        {
            int cnt = line.Count;
            for (int i = 0; i < cnt; i++)
            {
                this.txts[i].Text = line[i];
            }
            for (int i = cnt; i < 7; i++)
            {
                this.txts[i].Text = "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.txts = new TextBox[]
            {
                this.textBox1,
                this.textBox2,
                this.textBox3,
                this.textBox4,
                this.textBox5,
                this.textBox6,
                this.textBox7
            };
            this.ReadFile();
            this.ShowItem(this.lines[curIndex]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (--curIndex < 0)
            {
                curIndex = 0;
            }
            this.ShowItem(this.lines[curIndex]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (++curIndex > this.lines.Count - 1)
            {
                curIndex = this.lines.Count - 1;
            }
            this.ShowItem(this.lines[curIndex]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            curIndex = 0;
            this.ShowItem(this.lines[curIndex]);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            curIndex = this.lines.Count - 1;
            this.ShowItem(this.lines[curIndex]);
        }
    }
}
