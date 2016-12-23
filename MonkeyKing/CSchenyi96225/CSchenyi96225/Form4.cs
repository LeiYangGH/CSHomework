using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSchenyi96225
{
    public partial class Form4 : Form
    {
        private List<int> notdiv3;

        public Form4()
        {
            InitializeComponent();
        }

        private void ShowSum()
        {
            this.textBox1.Text = string.Join("\t", this.notdiv3);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.notdiv3 = new List<int>();
            for (int i = 100; i <= 200; i++)
            {
                if (i % 3 != 0)
                    this.notdiv3.Add(i);
            }
            this.ShowSum();
        }
    }
}
