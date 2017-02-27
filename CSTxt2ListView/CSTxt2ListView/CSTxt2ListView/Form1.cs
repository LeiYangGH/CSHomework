using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSTxt2ListView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileName = "所需读取的文件.e";
            //3099.0646       39.012       -4.276    3.048000
            this.listView1.Items.Clear();
            Regex r = new Regex(@"([-+]?[0-9]*\.?[0-9]+)\s+([-+]?[0-9]*\.?[0-9]+)\s+([-+]?[0-9]*\.?[0-9]+)\s+([-+]?[0-9]*\.?[0-9]+)");
            foreach (string line in File.ReadLines(fileName))
            {
                if (r.IsMatch(line))
                {
                    Match m = r.Match(line);
                    ListViewItem item = new ListViewItem(m.Groups[1].Value);
                    item.SubItems.Add(m.Groups[2].Value);
                    item.SubItems.Add(m.Groups[3].Value);
                    item.SubItems.Add(m.Groups[4].Value);
                    listView1.Items.Add(item);
                }
                //Console.WriteLine(line);
            }
        }
    }
}
