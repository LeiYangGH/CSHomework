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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddItem(Passenger p)
        {
            ListViewItem item = new ListViewItem(p.Id);
            item.SubItems.Add(p.Name);
            item.SubItems.Add(p.Gender);
            item.SubItems.Add(p.Age.ToString());
            this.listView1.Items.Add(item);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.listView1.BeginUpdate();
            this.listView1.Items.Clear();
            foreach (Passenger p in Repository.lstPassengers)
            {
                this.AddItem(p);
            }
            this.listView1.EndUpdate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxid.Text.Trim() == "")
                MessageBox.Show("请先输入再点新建");
            else
            {
                var p = new Passenger(this.textBoxid.Text.Trim(),
                 this.textBoxname.Text.Trim(),
                 this.textBoxgender.Text.Trim(),
                    Convert.ToInt32(this.textBoxage.Text.Trim()));
                Repository.lstPassengers.Add(p);
                this.AddItem(p);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems == null)
                MessageBox.Show("请先选择再点修改");
            else
            {
                var t = Repository.lstPassengers.First(x => x.Id == this.listView1.SelectedItems[0].Text);
                t.Name = this.textBoxname.Text.Trim();
                t.Gender = this.textBoxgender.Text.Trim();
                t.Age = Convert.ToInt32(this.textBoxage.Text.Trim());
                MessageBox.Show("修改成功");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems == null)
                MessageBox.Show("请先选择再点删除");
            else
            {
                var t = Repository.lstPassengers.First(x => x.Id == this.listView1.SelectedItems[0].Text);
                Repository.lstPassengers.Remove(t);
                this.listView1.Items.Remove(this.listView1.SelectedItems[0]);
                MessageBox.Show("删除成功");
            }
        }
    }
}
