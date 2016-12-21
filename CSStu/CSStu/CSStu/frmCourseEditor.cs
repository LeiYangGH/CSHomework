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
    public partial class frmCourseEditor : Form
    {
        public Course Course;//待编辑或增加的商品
        private bool isAdding;//是添加（还是编辑）
        public frmCourseEditor()
        {
            InitializeComponent();
            this.Course = new Course();
            this.isAdding = true;
        }


        /// <summary>
        /// 编辑时调用的构造函数
        /// </summary>
        /// <param name="Course"></param>
        public frmCourseEditor(Course Course) : this()
        {
            this.Course = Course;
            this.isAdding = false;
            this.SyncFromCourseToControl();
        }

        /// <summary>
        /// 把（编辑时）传进来的商品信息显示到控件
        /// </summary>
        private void SyncFromCourseToControl()
        {
            this.txtId.Text = this.Course.Id.ToString();
            this.txtName.Text = this.Course.Name;
            this.dtpDate.Value = this.Course.StartDate;
            this.numDuration.Value = this.Course.Duration;
        }

        /// <summary>
        /// 把控件信息传递到商品
        /// </summary>
        private void SyncFromControlToCourse()
        {
            this.Course.Name = this.txtName.Text;
            this.Course.StartDate = this.dtpDate.Value;
            this.Course.Duration = (int)this.numDuration.Value;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.SyncFromControlToCourse();
            this.DialogResult = DialogResult.OK;
        }
    }
}
