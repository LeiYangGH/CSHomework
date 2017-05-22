using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 模拟考试
{
    public partial class frmMain : Form
    {
        private Student stu;
        public frmMain()
        {
            InitializeComponent();
            this.stu = new Student();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            frmExam f = new frmExam();
            if (f.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(
                    string.Format("{0}{1}同学，你的成绩是{2}分！",
                    this.stu.Class,
                    this.stu.Name,
                    f.score));
            }
        }

        private void txtNO_TextChanged(object sender, EventArgs e)
        {
            this.stu.NO = txtNO.Text;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            this.stu.Name = txtName.Text;
        }

        private void lstClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.stu.Class = lstClass.SelectedItem.ToString();
        }

        private void rdbM_CheckedChanged(object sender, EventArgs e)
        {
            this.stu.Sex = "男";
        }

        private void rdbF_CheckedChanged(object sender, EventArgs e)
        {
            this.stu.Sex = "女";
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
