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
    public partial class btn2 : Form
    {
        private data<Employee> data;
        public btn2()
        {
            InitializeComponent();
            this.data = new data<Employee>("Employee",
                (x) =>
                {
                    return new string[] {
                        x.No,
                        x.Name
                };
                });
        }

        private void btn2_Load(object sender, EventArgs e)
        {
            this.data.ReadFile();
            this.data.AddAllToListView(this.listView1);
        }

        private void SetButtonEnable()
        {
            this.btn1.Enabled = !string.IsNullOrWhiteSpace(this.textBox1.Text.Trim())
                && !string.IsNullOrWhiteSpace(this.textBox2.Text.Trim());
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            this.btn1.Enabled = false;
            Employee t = new Employee(this.textBox1.Text.Trim(), this.textBox2.Text.Trim());
            if (this.data.Add(t, x => x.No))
            {
                this.data.AddOneToListView(this.listView1, t);
                //MessageBox.Show("添加成功！");
            }
            else
            {
                MessageBox.Show("不能重复添加！");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.SetButtonEnable();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.SetButtonEnable();

        }

        private void btn2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.data.SaveFile();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
