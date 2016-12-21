using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSStu
{
    public partial class frmMain : Form
    {
        private BindingList<Score> lstScore;//绑定的表

        public frmMain()
        {
            InitializeComponent();
            Repository r = new Repository();
        }

        private void ViewAllCourses()
        {
            this.lstScore = new BindingList<Score>(Repository.Default.ListScores);
            this.dgvScore.DataSource = this.lstScore;
            this.dgvScore.Columns[0].HeaderText = "学号";
            this.dgvScore.Columns[1].HeaderText = "姓名";
            this.dgvScore.Columns[2].HeaderText = "专业";
            this.dgvScore.Columns[3].HeaderText = "课程编号";
            this.dgvScore.Columns[4].HeaderText = "成绩";
        }

        private void courseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCourses frmC = new frmCourses();
            frmC.ShowDialog();
        }

        private void InitStudentsAndCourses()
        {
            this.cboStu.Items.AddRange(Repository.Default.ListStudents.Select
                (x => x.Name).ToArray());
            this.cboCourse.Items.AddRange(Repository.Default.ListCourses.Select
                (x => x.Name).ToArray());
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            InitStudentsAndCourses();
            ViewAllCourses();
        }

        private void UpdateMark(string stuName, string courseName, int mark)
        {

        }

        private void AddScore(string stuName, string courseName, string major, int mark)
        {
            string stuNo = Repository.Default.ListStudents.First(x => x.Name == stuName).No;
            int courseId = Repository.Default.ListCourses.First(x => x.Name == courseName).Id;
            Score score = new Score(stuNo, stuName, major, courseId, mark);
            Repository.Default.ListScores.Add(score);
        }

        private void UpdateScore(string stuName, string courseName, string major, int mark)
        {
            int courseId = Repository.Default.ListCourses.First(x => x.Name == courseName).Id;
            Score score = Repository.Default.ListScores.First(x =>
            x.StudentName == stuName && x.CourseId == courseId);
            score.Major = major;
            score.Mark = mark;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string stuName = this.cboStu.Text;
            string courseName = this.cboCourse.Text;
            string major = this.txtMajor.Text;
            int mark = (int)this.numMark.Value;

            int courseId = Repository.Default.ListCourses.First(x => x.Name == courseName).Id;
            if (Repository.Default.ListScores.Any(x => x.StudentName == stuName && x.CourseId == courseId))
            {
                UpdateScore(stuName, courseName, major, mark);
            }
            else
            {
                AddScore(stuName, courseName, major, mark);
            }
            ViewAllCourses();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Repository.Default.SaveScoresToFile();
        }

        private void CheckControlsEmpty()
        {
            this.btnOK.Enabled = !string.IsNullOrWhiteSpace(this.cboStu.Text)
                && !string.IsNullOrWhiteSpace(this.cboCourse.Text)
                && !string.IsNullOrWhiteSpace(this.txtMajor.Text);
        }

        private void cboStu_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckControlsEmpty();
        }

        private void txtMajor_TextChanged(object sender, EventArgs e)
        {
            CheckControlsEmpty();
        }

        private void cboCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckControlsEmpty();
        }
    }
}
