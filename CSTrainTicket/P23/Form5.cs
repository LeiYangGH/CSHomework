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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.listView1.BeginUpdate();
            this.listView1.Items.Clear();
            foreach (History his in Repository.lstHistorys)
            {
                ListViewItem item = new ListViewItem(his.TicketNO);
                var t = Repository.lstTickets.First(x => x.No == his.TicketNO);
                item.SubItems.Add(t.Date.ToString());
                item.SubItems.Add(t.Price.ToString());
                var p = Repository.lstPassengers.First(x => x.Id == his.PassengerId);
                item.SubItems.Add(p.Name);
                item.SubItems.Add(p.Id.ToString());
                this.listView1.Items.Add(item);
            }
            this.listView1.EndUpdate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
