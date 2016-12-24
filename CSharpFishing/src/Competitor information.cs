using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main_interface
{
    public partial class Competitor_information : Form
    {
        public Competitor_information()
        {
            InitializeComponent();
        }

        private void Competitor_information_Load(object sender, EventArgs e)
        {

        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

    }
}
