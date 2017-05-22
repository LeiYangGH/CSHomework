using System;
using System.Windows.Forms;

namespace studentManage
{
    public partial class Form2 : Form
    {
        public Student stu;

        public Form2()
        {
            InitializeComponent();
            this.stu = new Student();
        }

        public Form2(Student currentStudent)
        {
            this.stu = currentStudent;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }



        private void 取消_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void 确定_Click_1(object sender, EventArgs e)
        {
            this.stu.Name = textName.Text;
            this.stu.Sex = comboSex.Text;
            this.DialogResult = DialogResult.OK;
        }



        private void 跳转_Click(object sender, EventArgs e)
        {

        }


    }


}

