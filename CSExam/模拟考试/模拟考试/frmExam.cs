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
    public partial class frmExam : Form
    {
        private Questions qs = new Questions();
        public int score = 0;
        public frmExam()
        {
            InitializeComponent();
        }

        private void frmExam_Load(object sender, EventArgs e)
        {
            this.label111.Text = qs.TrueFalseQuestions[0].Title;
            this.label121.Text = qs.TrueFalseQuestions[1].Title;
            this.label131.Text = qs.TrueFalseQuestions[2].Title;
        }

        private void Stop()
        {
            this.score = 0;
            this.score += this.radioButton112.Checked == qs.TrueFalseQuestions[0].IsCorrect ? 1 : 0;
            this.score += this.radioButton122.Checked == qs.TrueFalseQuestions[1].IsCorrect ? 1 : 0;
            this.score += this.radioButton132.Checked == qs.TrueFalseQuestions[2].IsCorrect ? 1 : 0;
            this.Text = this.score.ToString();
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            this.Stop();
        }
    }
}
