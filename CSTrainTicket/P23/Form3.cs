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

        private void Form3_Load(object sender, EventArgs e)
        {
            this.lbPeople.Items.Clear();
            this.lbPeople.Items.AddRange(Repository.lstPassengers.Select(x => x.Id).ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxid.Text.Trim() == "")
                MessageBox.Show("请先输入再点新建");
            else
            {
                var t = new Passenger(this.textBoxid.Text.Trim(),
                 this.textBoxname.Text.Trim(),
                 this.textBoxgender.Text.Trim(),
                    Convert.ToInt32(this.textBoxage.Text.Trim()));
                Repository.lstPassengers.Add(t);
                this.lbPeople.Items.Add(t.Id);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.lbPeople.SelectedItem == null)
                MessageBox.Show("请先选择再点修改");
            else
            {
                var t = Repository.lstPassengers.First(x => x.Id == this.lbPeople.SelectedItem.ToString());
                t.Name = this.textBoxname.Text.Trim();
                t.Gender = this.textBoxgender.Text.Trim();
                t.Age = Convert.ToInt32(this.textBoxage.Text.Trim());
                MessageBox.Show("修改成功");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.lbPeople.SelectedItem == null)
                MessageBox.Show("请先选择再点删除");
            else
            {
                var t = Repository.lstPassengers.First(x => x.Id == this.lbPeople.SelectedItem.ToString());
                Repository.lstPassengers.Remove(t);
                this.lbPeople.Items.Remove(this.lbPeople.SelectedItem.ToString());
                MessageBox.Show("删除成功");
            }
        }
    }
}
