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

            this.label211.Text = qs.SingleChoiceQuestions[0].Title;
            this.radioButton211.Text = qs.SingleChoiceQuestions[0].Choices[0];
            this.radioButton212.Text = qs.SingleChoiceQuestions[0].Choices[1];
            this.radioButton213.Text = qs.SingleChoiceQuestions[0].Choices[2];
            this.radioButton214.Text = qs.SingleChoiceQuestions[0].Choices[3];
            this.label221.Text = qs.SingleChoiceQuestions[1].Title;
            this.radioButton221.Text = qs.SingleChoiceQuestions[1].Choices[0];
            this.radioButton222.Text = qs.SingleChoiceQuestions[1].Choices[1];
            this.radioButton223.Text = qs.SingleChoiceQuestions[1].Choices[2];
            this.radioButton224.Text = qs.SingleChoiceQuestions[1].Choices[3];

        }

        private void Stop()
        {
            this.score = 0;
            if (this.radioButton112.Checked == qs.TrueFalseQuestions[0].IsCorrect)
                this.score++;
            if (this.radioButton122.Checked == qs.TrueFalseQuestions[1].IsCorrect)
                this.score++;
            if (this.radioButton132.Checked == qs.TrueFalseQuestions[2].IsCorrect)
                this.score++;
            RadioButton[] rdbs21 = new RadioButton[]
            {
                this.radioButton211,
                this.radioButton212,
                this.radioButton213,
                this.radioButton214
            };
            if (rdbs21[qs.SingleChoiceQuestions[0].CorrectChoiceId].Checked)
                this.score++;

            RadioButton[] rdbs22 = new RadioButton[]
{
                this.radioButton221,
                this.radioButton222,
                this.radioButton223,
                this.radioButton224
};
            if (rdbs22[qs.SingleChoiceQuestions[1].CorrectChoiceId].Checked)
                this.score++;
            this.Text = this.score.ToString();
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            this.Stop();
        }
    }
}
