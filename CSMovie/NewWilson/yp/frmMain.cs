using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yp
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HallManager.frmMain form = new HallManager.frmMain();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MovieManage.frmMain form = new MovieManage.frmMain();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PlayManager.frmMain form = new PlayManager.frmMain();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DiscountManager.frmMain form = new DiscountManager.frmMain();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PlayManager.frmMain form = new PlayManager.frmMain();
            form.Show();
        }
    }
}
