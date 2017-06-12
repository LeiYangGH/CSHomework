using CSBike;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P23
{
    public partial class frmStart : Form
    {
        public frmStart()
        {
            InitializeComponent();
        }

        private void frmStart_Load(object sender, EventArgs e)
        {
            frmSuperPassword frmSuper = new frmSuperPassword();
            var result = frmSuper.ShowDialog();
            if (result != DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
