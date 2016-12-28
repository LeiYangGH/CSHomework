using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace 金圣洁A14.课程知识演示软件
{
    public partial class Form1 : Form
    {

        private string bookFolder = @"课程内容";
        private bool goingForward;//是否在向前
        private string currentChapter;
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenSection(string sec)
        {
            string section = Path.Combine(this.currentChapter, sec);
            string content = File.ReadAllText(section, Encoding.GetEncoding("GB2312"));
            this.textBox3.Text = content;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sel = this.listBox2.SelectedItem;
            if (sel != null)
            {
                this.OpenSection(sel as string);
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            foreach (string dir in Directory.GetDirectories(this.bookFolder))
            {
                this.listBox1.Items.Add(Path.GetFileName(dir));
            }
            this.goingForward = true;//开始时默认向前
            this.listBox1.SelectedIndex = 0;
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
                //选中章的时候，根据向前还是向后设置节选中第一还是最后一项
                this.listBox2.SelectedIndex = this.goingForward ? 0 : this.listBox2.Items.Count - 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.goingForward = true;//向前
            if (this.listBox2.SelectedItem != null)
            {
                if (this.listBox2.SelectedIndex == this.listBox2.Items.Count - 1)
                {
                    string selCh = this.listBox1.SelectedItem.ToString();
                    if (this.listBox1.SelectedIndex == this.listBox1.Items.Count - 1)
                    {
                        MessageBox.Show("已经没有下一节！");
                    }
                    else
                    {
                        this.listBox1.SelectedIndex += 1;
                    }
                }
                else
                {
                    this.listBox2.SelectedIndex += 1;
                }
                this.OpenSection(this.listBox2.SelectedItem as string);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.goingForward = false;//向后
            if (this.listBox2.SelectedItem != null)
            {
                if (this.listBox2.SelectedIndex == 0)
                {
                    string selCh = this.listBox1.SelectedItem.ToString();
                    if (this.listBox1.SelectedIndex == 0)
                    {
                        MessageBox.Show("已经没有上一节！");
                    }
                    else
                    {
                        this.listBox1.SelectedIndex -= 1;
                    }
                }
                else
                {
                    this.listBox2.SelectedIndex -= 1;
                }
                this.OpenSection(this.listBox2.SelectedItem as string);
            }
        }
    }
}
