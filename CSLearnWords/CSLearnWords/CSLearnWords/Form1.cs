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

namespace CSLearnWords
{
    public partial class Form1 : Form
    {
        string[] english;
        string[] chinese;
        Random r = new Random();
        Button[] buttons;
        int total;
        int correct;
        string correctCh;
        public Form1()
        {
            InitializeComponent();
            this.RegisterButtons();
        }

        private void Judge(string selection)
        {
            if (selection == this.correctCh)
            {
                this.pictureBox1.Image = Properties.Resources.ok;
                this.correct++;
            }
            else
                this.pictureBox1.Image = Properties.Resources.fail;
            this.txtPercent.Text = string.Format("{0}/{1},{2:P2}",
            this.correct, this.total,
            this.correct / (float)this.total);
            this.Refresh();
        }

        private void RegisterButtons()
        {
            this.buttons = new Button[] { button1, button2, button3, button4 };
            foreach (var btn in this.buttons)
                btn.Click += (s, e) =>
                  {
                      this.Judge((s as Button).Text);
                      this.Test();
                  };
        }

        private void Test()
        {

            string en = english.OrderBy(x => r.Next()).First();
            this.txtWord.Text = en;
            string[] chi = chinese.OrderBy(x => r.Next()).ToArray();
            for (int i = 0; i < 4; i++)
            {
                this.buttons[i].Text = chi[i];
            }
            this.correctCh = this.chinese[this.english.ToList().IndexOf(en)];
            this.total++;
        }

        private void ReadWords()
        {
            string wordsFile = "words.txt";
            this.english = new string[4];
            this.chinese = new string[4];
            if (File.Exists(wordsFile))
            {
                string[] ss = File.ReadAllText(wordsFile, Encoding.UTF8)
                    .Split(new char[] { '|', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < 4; i++)
                {
                    this.english[i] = ss[i * 2];
                    this.chinese[i] = ss[i * 2 + 1];
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ReadWords();
            this.Test();
        }
    }
}
