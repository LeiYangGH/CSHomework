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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void ticket_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddItem(Ticket t)
        {
            ListViewItem item = new ListViewItem(t.No);
            item.SubItems.Add(t.Date.ToString());
            item.SubItems.Add(t.Price.ToString());
            this.listView1.Items.Add(item);
        }

        //new
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
                MessageBox.Show("请先输入再点新建");
            else
            {
                var t = new Ticket(this.textBox1.Text.Trim(),
                    this.dateTimePicker1.Value,
                    Convert.ToInt32(this.textBox3.Text.Trim()));
                Repository.lstTickets.Add(t);
                //this.lbTicket.Items.Add(t.No);
                this.AddItem(t);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems == null)
                MessageBox.Show("请先选择再点修改");
            else
            {
                var t = Repository.lstTickets.First(x => x.No == this.listView1.SelectedItems[0].Text);
                t.Date = this.dateTimePicker1.Value;
                t.Price = Convert.ToInt32(this.textBox3.Text.Trim());
                MessageBox.Show("修改成功");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems == null)
                MessageBox.Show("请先选择再点删除");
            else
            {
                var t = Repository.lstTickets.First(x => x.No == this.listView1.SelectedItems[0].Text);
                if (History.IsTicketSold(this.listView1.SelectedItems[0].Text))
                {
                    MessageBox.Show("此票已售不能删除");
                }
                else
                {
                    Repository.lstTickets.Remove(t);
                    this.listView1.Items.Remove(this.listView1.SelectedItems[0]);
                    MessageBox.Show("删除成功");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.listView1.BeginUpdate();
            this.listView1.Items.Clear();
            var allTNos = Repository.lstTickets
                .Select(x => x.No).ToArray();
            var allSoldNos = Repository.lstHistorys.Select(h => h.TicketNO).ToArray();
            foreach (string s in allTNos.Except(allSoldNos))
            {
                Ticket t = Repository.lstTickets.First(x => x.No == s);
                ListViewItem item = new ListViewItem(t.No);
                item.SubItems.Add(t.Date.ToString());
                item.SubItems.Add(t.Price.ToString());
                this.listView1.Items.Add(item);
            }
            this.listView1.EndUpdate();
        }
    }
}
