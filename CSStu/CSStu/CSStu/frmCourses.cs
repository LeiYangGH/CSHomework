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
    public partial class frmCourses : Form
    {
        private BindingList<Course> lstCourse;//绑定的表
        public frmCourses()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 根据是否特价查看
        /// </summary>
        private void ViewAllCourses()
        {
            this.lstCourse = new BindingList<Course>(Repository.Default.ListCourses);
            this.dgvCourse.DataSource = this.lstCourse;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCourseEditor editor = new frmCourseEditor();
            if (editor.ShowDialog() == DialogResult.OK)
            {
                Repository.Default.ListCourses.Add(editor.Course);
                this.ViewAllCourses();
            }
        }

        /// <summary>
        /// 获取选中的第一行
        /// </summary>
        /// <returns></returns>
        private Course GetFirstSelectedCourse()
        {
            var selectedRows = this.dgvCourse.SelectedRows;
            if (selectedRows == null)
                return null;
            else
            {
                int id = (int)selectedRows[0].Cells[0].Value;
                return this.lstCourse.First(x => x.Id == id);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Course selCourse = this.GetFirstSelectedCourse();
            if (selCourse != null)
            {
                frmCourseEditor editor = new frmCourseEditor(selCourse);
                int oldId = selCourse.Id;
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    Course course = Repository.Default.ListCourses.First(x => x.Id == oldId);
                    course.Name = selCourse.Name;
                    course.StartDate = selCourse.StartDate;
                    course.Duration = selCourse.Duration;
                    this.ViewAllCourses();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Repository.Default.SaveCoursesToFile();
        }

        private void frmCourses_Load(object sender, EventArgs e)
        {
            this.ViewAllCourses();
        }
    }
}
