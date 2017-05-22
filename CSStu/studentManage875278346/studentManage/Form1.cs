using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace studentManage
{
    public partial class Form1 : Form
    {
        BindingList<student> bindingList;
        private List<student> lstStudents;

        public Form1()
        {
            InitializeComponent();
            this.lstStudents = new List<student>();
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            if (newForm.ShowDialog() == DialogResult.OK)
            {
                //this.dataGridView1.Rows.Add();
                //var row = this.dataGridView1.Rows.OfType<DataGridViewRow>().Last();
                this.lstStudents.Add(newForm.stu);
                this.bindingList = new BindingList<student>(lstStudents);
                this.dataGridView1.DataSource = bindingList;
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindingData();
        }
        public void BindingData()
        {

        }


        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
