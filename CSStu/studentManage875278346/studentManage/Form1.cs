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
        BindingList<Student> bindingList;
        private List<Student> lstStudents;
        private string txtFileName = "students.txt";

        public Form1()
        {
            InitializeComponent();
            this.lstStudents = new List<Student>();
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Refresh()
        {
            this.bindingList = new BindingList<Student>(lstStudents);
            this.dataGridView1.DataSource = bindingList;
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            if (newForm.ShowDialog() == DialogResult.OK)
            {
                //this.dataGridView1.Rows.Add();
                //var row = this.dataGridView1.Rows.OfType<DataGridViewRow>().Last();
                this.lstStudents.Add(newForm.stu);
                this.Refresh();
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Read();
        }

        public void ReadFromFile()
        {
            this.lstStudents = File.ReadLines(txtFileName)
                .Select(x => Student.CreateStudentFromLine(x))
                .ToList();
            this.Refresh();
        }

        public void Read()
        {
            if (File.Exists(txtFileName))
            {
                try
                {
                    this.ReadFromFile();
                    this.Refresh();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SaveUsersToFile()
        {
            File.WriteAllLines(this.txtFileName, this.lstStudents.Select(x => x.ToString()));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.SaveUsersToFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
