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
    public partial class 路线价格 : Form
    {
        public 路线价格()
        {
            InitializeComponent();
        }

        private void 路线价格_FormClosing(object sender, FormClosingEventArgs e)
        {
            Repository.dataRoute.SaveFile();

        }

        private void 路线价格_Load(object sender, EventArgs e)
        {
            Repository.dataRoute.AddAllToListView(this.listView1);
        }

        private void SetButtonEnable()
        {
            this.btnSave.Enabled = !string.IsNullOrWhiteSpace(this.textBox1.Text.Trim())
                && this.numPrice.Value > 0;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.SetButtonEnable();

        }

        private void numPrice_ValueChanged(object sender, EventArgs e)
        {
            this.SetButtonEnable();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.btnSave.Enabled = false;
            Route t = new Route(this.textBox1.Text.Trim(), this.dpDOP.Value, (int)this.numPrice.Value);
            if (Repository.dataRoute.Add(t, x => x.Descriptions))
            {
                Repository.dataRoute.AddOneToListView(this.listView1, t);
                //MessageBox.Show("添加成功！");
            }
            else
            {
                MessageBox.Show("不能重复添加！");
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dpDOP_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
