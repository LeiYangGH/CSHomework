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
    public partial class Form3 : Form
    {
        private List<int> odds;

        public Form3()
        {
            InitializeComponent();
        }

        private void ShowSum()
        {
            this.textBox1.Text = string.Join(" + ", this.odds);
            this.textBox1.Text += string.Format(" = {0}", this.odds.Sum());
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.odds = new List<int>();
            for (int i = 100; i <= 500; i++)
            {
                if (i % 2 == 1)
                    odds.Add(i);
            }
            this.ShowSum();
        }
    }
}
