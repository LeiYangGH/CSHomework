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
        public Form1()
        {
            InitializeComponent();
        }

        private void Test()
        {
            string en = english.OrderBy(x => r.Next()).First();
            this.txtWord.Text = en;
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
