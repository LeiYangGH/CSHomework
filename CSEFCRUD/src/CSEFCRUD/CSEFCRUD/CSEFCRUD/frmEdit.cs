using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSEFCRUD
{
    public partial class frmEdit : Form
    {
        public Student student;//待编辑或增加的商品
        private bool isAdding;//是添加（还是编辑）
        public frmEdit()
        {
            InitializeComponent();
            this.student = new Student();
            this.isAdding = true;
        }

        public frmEdit(Student stu) : this()
        {
            this.student = stu;
            this.isAdding = false;
            this.SyncFromStudentToControl();
        }

        /// <summary>
        /// 把（编辑时）传进来的商品信息显示到控件
        /// </summary>
        private void SyncFromStudentToControl()
        {
            this.txtID.Text = this.student.ID.ToString();
            this.txtName.Text = this.student.Name;
            this.cboSex.Text = this.student.Sex;
            this.numAge.Value = (int)this.student.Age;
            this.txtPwd.Text = this.student.Pwd;
        }

        /// <summary>
        /// 把控件信息传递到商品
        /// </summary>
        private void SyncFromControlToStudent()
        {
            this.student.Name = this.txtName.Text;
            this.student.Sex = this.cboSex.Text;
            this.student.Age = (int)this.numAge.Value;
            this.student.Pwd = this.txtPwd.Text;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            this.SyncFromControlToStudent();
            this.DialogResult = DialogResult.OK;
        }
    }
}
