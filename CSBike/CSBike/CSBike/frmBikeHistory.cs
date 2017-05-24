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
    public partial class frmBikeHistory : Form
    {
        public frmBikeHistory()
        {
            InitializeComponent();
        }

        private void frmBikeHistory_Load(object sender, EventArgs e)
        {
            this.listView1.BeginUpdate();
            this.listView1.Items.Clear();
            foreach(History his in BikesHistory.lstHistory)
            {
                ListViewItem item = new ListViewItem(his.BikeNO);
                item.SubItems.Add(his.UserName);
                item.SubItems.Add(his.ToBorrow?"借":"还");
                item.SubItems.Add(his.Date.ToString());
                this.listView1.Items.Add(item);
            }
            this.listView1.EndUpdate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
