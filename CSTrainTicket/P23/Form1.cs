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
#if TEST
#else
            frmSuperPassword frmSuper = new frmSuperPassword();
            var result = frmSuper.ShowDialog();
            if (result != DialogResult.OK)
            {
                this.Close();
            }
#endif
            Repository.ReadTickets();
            Repository.ReadPassengers();
            Repository.ReadHistorys();

        }

        private void btnBike_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog();
        }

        private void frmStart_FormClosing(object sender, FormClosingEventArgs e)
        {
            Repository.SaveTickets();
            Repository.SavePassengers();
            Repository.SaveHistorys();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.ShowDialog();
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.ShowDialog();
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            Form6 frm = new Form6();
            frm.ShowDialog();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Form7 frm = new Form7();
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
