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
    public partial class frmReturn : Form
    {
        private string bike;
        public frmReturn()
        {
            InitializeComponent();
        }

        private void frmReturn_Load(object sender, EventArgs e)
        {
            this.cboBike.Items.Clear();
            this.cboBike.Items.AddRange(
                BikesHistory.lstHistory.GroupBy(x => x.BikeNO)
                .Where(g => g.ToList().Count(x => x.ToBorrow)
                == g.ToList().Count(x => !x.ToBorrow) + 1)
                .Select(g => g.Key).Distinct()
                .ToArray());
        }

        private void cboBike_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.bike = cboBike.Text;
            string user = BikesHistory.lstHistory.Where(x => x.BikeNO == this.bike).OrderBy(x => x.Date).Last().UserName;
            this.txtUser.Text = user;
            btnOK.Enabled = !string.IsNullOrWhiteSpace(user);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.btnOK.Enabled = false;
            BikesHistory.Return(this.bike);
            this.txtUser.Clear();
            this.cboBike.Items.Remove(this.bike);
            MessageBox.Show("成功归还！");
        }
    }
}
