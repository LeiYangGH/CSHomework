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
    public partial class frmAveByCourse : Form
    {
        public frmAveByCourse()
        {
            InitializeComponent();
        }

        private void frmAveByCourse_Load(object sender, EventArgs e)
        {
            var v = Repository.Default.ListScores
                .GroupBy(x => x.CourseId)
                  .Select(g => new AveCourse(
                      Repository.Default.ListCourses.First(y => y.Id == g.Key).Name,
                      g.Average(x => x.Mark).ToString()))
                  .ToArray();
            this.dgvAveCourse.DataSource = v;
            this.dgvAveCourse.Columns[0].HeaderText = "课程名称";
            this.dgvAveCourse.Columns[1].HeaderText = "平均分";
        }
    }
}
