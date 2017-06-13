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
        private DataReadWriteDisplay<Route> data;
        public 路线价格()
        {
            InitializeComponent();
            this.data = new DataReadWriteDisplay<Route>("Route",
           (x) =>
           {
               return new string[] {
                        x.Descriptions,
                        x.Date.ToString(),
                        x.Price.ToString()
           };
           });
        }

        private void 路线价格_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.data.SaveFile();

        }

        private void 路线价格_Load(object sender, EventArgs e)
        {
            this.data.ReadFile();
            this.data.AddAllToListView(this.listView1);
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
            if (this.data.Add(t, x => x.Descriptions))
            {
                this.data.AddOneToListView(this.listView1, t);
                //MessageBox.Show("添加成功！");
            }
            else
            {
                MessageBox.Show("不能重复添加！");
            }
        }
    }
}
