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
        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string a;
            a= listBox2.SelectedIndex.ToString();
            FileStream fs = new FileStream(Application.StartupPath + @"a.txt", FileMode.Open);
            StreamReader b = new StreamReader(fs, System.Text.Encoding.Default);
            textBox3.Text = b.ReadToEnd();
            b.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog s = new FolderBrowserDialog();
            DialogResult x = s.ShowDialog();
            if (x == DialogResult.OK)
                textBox1.Text = s.SelectedPath;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileInfo f = new FileInfo(textBox1.Text);
            string[] a = Directory.GetDirectories(textBox1.Text);
            
            listBox1.Items.AddRange(a);
            string[] b = Directory.GetFiles(textBox1.Text);
            listBox2.Items.AddRange(b);

            


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
