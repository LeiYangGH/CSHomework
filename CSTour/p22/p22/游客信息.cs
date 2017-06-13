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
        private DataReadWriteDisplay<Tourist> data;
        public btn1()
        {
            InitializeComponent();
            this.data = new DataReadWriteDisplay<Tourist>("btn1",
          (x) =>
          {
              return new string[] {
                        x.Name,
                        x.Gender,
                        x.Id,
                        x.Tel
          };
          });
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
            if (this.data.Add(t, x => x.Id))
            {
                this.data.AddOneToListView(this.listView1, t);
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
            this.data.ReadFile();
            this.data.AddAllToListView(this.listView1);
        }

        private void btn1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.data.SaveFile();

        }
    }
}
