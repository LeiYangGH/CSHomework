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
    public partial class frmMain : Form
    {

        private BindingList<Student> lstStudent;//绑定的表
        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 根据是否特价查看
        /// </summary>
        private void ViewAllStudent()
        {
            this.lstStudent = new BindingList<Student>(StuDbAccessor.SelectAll());
            this.dgvStudents.DataSource = this.lstStudent;
        }

        /// <summary>
        /// 获取选中的第一行
        /// </summary>
        /// <returns></returns>
        private Student GetFirstSelectedStudent()
        {
            var selectedRows = this.dgvStudents.SelectedRows;
            if (selectedRows == null)
                return null;
            else
            {
                int id = (int)selectedRows[0].Cells[0].Value;
                return this.lstStudent.First(x => x.ID == id);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Student selStudent = this.GetFirstSelectedStudent();
            if (selStudent != null)
            {
                frmEdit editor = new frmEdit(selStudent);
                int oldId = selStudent.ID;
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    StuDbAccessor.Update(oldId, selStudent);
                    this.ViewAllStudent();
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.ViewAllStudent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmEdit editor = new frmEdit();
            if (editor.ShowDialog() == DialogResult.OK)
            {
                StuDbAccessor.Add(editor.student);
                this.ViewAllStudent();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Student selStudent = this.GetFirstSelectedStudent();
            StuDbAccessor.Delete(selStudent.ID);
            this.ViewAllStudent();
        }
    }
}
