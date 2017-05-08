using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSBike
{
    public partial class frmBike : Form
    {

        public frmBike()
        {
            InitializeComponent();
        }

        private void frmBike_Load(object sender, EventArgs e)
        {
            //clsBike k = new clsBike("1-1", DateTime.Now, 100.50f);
            //clsData.Bikes.Add(k);
            ShuaXinLB();
        }

        private void ShuaXinLB()
        {
            lbBike.Items.Clear();
            foreach (clsBike bk in clsData.Bikes)
                lbBike.Items.Add(string.Format("{0,-8} {1:yy/MM/dd}  ￥{2:###.00}",
                    bk.ID, bk.DOP, bk.Price));
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            clsBike newBike = new clsBike("", DateTime.Today, 120.89f);//Convert.ToDateTime("01-01-01"), 0f);
            frmBikeDetail bd = new frmBikeDetail(newBike);
            bd.ShowDialog();
            if (bd.DialogResult == DialogResult.OK)
            {
                clsData.Bikes.Add(newBike);
                ShuaXinLB();
            }

        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            Close(); 
        }
    }
}
