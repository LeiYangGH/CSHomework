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
    public partial class frmAveByStu : Form
    {
        public frmAveByStu()
        {
            InitializeComponent();
        }

        private void cboStu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string stuName = this.cboStu.Text;
            var v = Repository.Default.ListScores
                .Where(x => x.StudentName == stuName)
                .GroupBy(x => x.CourseId)
                  .Select(g => new AveCourse(
                      Repository.Default.ListCourses.First(y => y.Id == g.Key).Name,
                      g.Average(x => x.Mark).ToString()))
                  .ToArray();
            this.dgvAveStu.DataSource = v;
            this.dgvAveStu.Columns[0].HeaderText = "课程名称";
            this.dgvAveStu.Columns[1].HeaderText = "平均分";
        }

        private void frmAveByStu_Load(object sender, EventArgs e)
        {
            this.cboStu.Items.AddRange(Repository.Default.ListStudents.Select
                  (x => x.Name).ToArray());
        }
    }


}
