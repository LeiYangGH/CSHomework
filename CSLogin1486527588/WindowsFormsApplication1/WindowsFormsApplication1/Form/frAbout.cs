using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frAbout : Form
    {
        public frAbout()
        {
            InitializeComponent();
        }

        private void frAbout_Load(object sender, EventArgs e)
        {

        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
