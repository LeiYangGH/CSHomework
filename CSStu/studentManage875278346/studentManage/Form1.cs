using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
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
            Form2 f2 = new Form2();
            if (f2.ShowDialog() == DialogResult.OK)
            {
                this.lstStudents.Add(f2.stu);
                this.Refresh();
            }
        }

        public void ReadAndBind()
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

        private void Form1_Load(object sender, EventArgs e)
        {
            ReadAndBind();
        }

        public void ReadFromFile()
        {
            this.lstStudents = File.ReadLines(txtFileName)
                .Select(x => Student.CreateStudentFromLine(x))
                .ToList();
            this.Refresh();
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
