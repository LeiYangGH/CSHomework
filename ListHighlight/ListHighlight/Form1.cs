using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListHighlight
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SelecteItemByIndex(int index1)
        {
            if (index1 > this.listBox1.Items.Count)
                return;
            this.listBox1.SelectedIndex = index1 - 1;
        }

        int index1 = 1;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            //for (int i = 1; i <= 10; i++)
            //    this.listBox1.Items.Add(i);
            this.listBox1.Items.Add("Cap xx");
            this.listBox1.Items.Add("3.3V");
            this.listBox1.Items.Add("OlEDev +1V");
            this.SelecteItemByIndex(index1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.index1++;
            this.SelecteItemByIndex(index1);
        }
    }
}
