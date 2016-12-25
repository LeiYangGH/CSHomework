using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace 金圣洁A14.课程知识演示软件
{
    public partial class Form1 : Form
    {
        //private string bookFolder = @"C:\G\CSHomework\CSPPT\金圣洁A14.  课程知识演示软件\金圣洁A14.  课程知识演示软件\bin\Debug\课程内容";
        private string bookFolder = @"课程内容";
        private string currentChapter;
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenSection(string sec)
        {
            try
            {
                string section = Path.Combine(this.currentChapter, sec);
                string content = File.ReadAllText(section, Encoding.GetEncoding("GB2312"));
                this.textBox3.Text = content;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SelectFirstItem(ListBox lb)
        {
            if (lb.Items.Count > 0)
                lb.SelectedItem = lb.Items.OfType<string>().First();
        }

        private void SelectNextItem(ListBox lb)
        {
            lb.SelectedItem = lb.Items[lb.Items.IndexOf(lb.SelectedItem) + 1];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sel = this.listBox2.SelectedItem;
            if (sel != null)
            {
                this.OpenSection(sel as string);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog s = new FolderBrowserDialog();
            DialogResult x = s.ShowDialog();
            if (x == DialogResult.OK)
            {
                this.bookFolder = s.SelectedPath;
                textBox1.Text = this.bookFolder;
            }
            //textBox1.Text = this.bookFolder;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            foreach (string dir in Directory.GetDirectories(this.bookFolder))
            {
                this.listBox1.Items.Add(Path.GetFileName(dir));
            }
            this.SelectFirstItem(this.listBox1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sel = this.listBox1.SelectedItem;
            if (sel != null)
            {
                this.listBox2.Items.Clear();
                this.currentChapter = Path.Combine(this.bookFolder, sel as string);
                foreach (string file in Directory.GetFiles(this.currentChapter, "*.txt"))
                {
                    this.listBox2.Items.Add(Path.GetFileName(file));
                }
                this.SelectFirstItem(this.listBox2);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            object sel = this.listBox2.SelectedItem;
            if (sel != null)
            {
                if (sel.ToString() == this.listBox2.Items.OfType<string>().Last())
                {
                    string selCh = this.listBox1.SelectedItem.ToString();
                    if (selCh.ToString() == this.listBox1.Items.OfType<string>().Last())
                    {
                        MessageBox.Show("已经到了末尾！");
                    }
                    else
                    {
                        this.SelectNextItem(this.listBox1);
                    }
                }
                else
                {
                    this.SelectNextItem(this.listBox2);
                }
                this.OpenSection(this.listBox2.SelectedItem as string);
            }
        }
    }
}
