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
                this.lbTicket.Items.Add(t.No);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.lbTicket.SelectedItem == null)
                MessageBox.Show("请先选择再点修改");
            else
            {
                var t = Repository.lstTickets.First(x => x.No == this.lbTicket.SelectedItem.ToString());
                t.Date = this.dateTimePicker1.Value;
                t.Price = Convert.ToInt32(this.textBox3.Text.Trim());
                MessageBox.Show("修改成功");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.lbTicket.SelectedItem == null)
                MessageBox.Show("请先选择再点删除");
            else
            {
                var t = Repository.lstTickets.First(x => x.No == this.lbTicket.SelectedItem.ToString());
                Repository.lstTickets.Remove(t);
                this.lbTicket.Items.Remove(this.lbTicket.SelectedItem.ToString());

                MessageBox.Show("删除成功");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.lbTicket.Items.Clear();
            this.lbTicket.Items.AddRange(Repository.lstTickets.Select(x=>x.No).ToArray());
        }
    }
}
