using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace p22
{
    public partial class btn1 : Form
    {
        public btn1()
        {
            InitializeComponent();
        }

        private void SetButtonEnable()
        {
            this.button1.Enabled = !string.IsNullOrWhiteSpace(this.textBoxn.Text.Trim())
                && !string.IsNullOrWhiteSpace(this.textBoxi.Text.Trim())
                && !string.IsNullOrWhiteSpace(this.textBoxi.Text.Trim());
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            Tourist t = new Tourist(this.textBoxn.Text.Trim(),
                 this.GetGender(),
                this.textBoxi.Text.Trim(),
                this.textBoxt.Text.Trim()
                );
            if (Repository.dataTourist.Add(t, x => x.Name))
            {
                Repository.dataTourist.AddOneToListView(this.listView1, t);
                //MessageBox.Show("添加成功！");
            }
            else
            {
                MessageBox.Show("不能重复添加！");
            }
        }

        private void textBoxn_TextChanged(object sender, EventArgs e)
        {
            this.SetButtonEnable();

        }

        private void textBoxi_TextChanged(object sender, EventArgs e)
        {
            this.SetButtonEnable();

        }

        private void textBoxt_TextChanged(object sender, EventArgs e)
        {
            this.SetButtonEnable();

        }

        private string GetGender()
        {
            return this.rdMale.Checked ? "男" : "女";
        }

        private void rdMale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn1_Load(object sender, EventArgs e)
        {
            Repository.dataTourist.AddAllToListView(this.listView1);
        }

        private void btn1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Repository.dataTourist.SaveFile();

        }
    }
}
