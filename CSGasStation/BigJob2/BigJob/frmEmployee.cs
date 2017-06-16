using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigJob
{
    public partial class frmEmployee : Form
    {
        int G_Int_addOrUpdate = 0; //判断是修改还是增加数据
        string id = "";

        Employee employee = new Employee();
        public frmEmployee()
        {
            InitializeComponent();
        }

        private void tlBtnsave_Click(object sender, EventArgs e)
        {
            if (G_Int_addOrUpdate == 0)
            {
                try
                {
                    employee.Id = textBox1.Text.Trim();
                    employee.FullName = txtFullName.Text.Trim();
                    employee.Sex = cmbSex.Text;
                    employee.Tel = txtTel.Text.Trim();
                    employee.Dept = cmbdept.Text;
                    employee.Memo = txtMemo.Text.Trim();
                    int result = employee.AddEmployee(employee);
                    MessageBox.Show("新增成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                try
                {
                    employee.Id = id;
                    employee.FullName = txtFullName.Text.Trim();
                    employee.Sex = cmbSex.Text.Trim();
                    employee.Tel = txtTel.Text.Trim();
                    employee.Dept = cmbdept.Text.Trim();
                    employee.Memo = txtMemo.Text.Trim();
                    employee.UpdateEmployee(employee);
                    MessageBox.Show("修改成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            dgvEmployee.DataSource = employee.GetAllEmployee().Tables[0].DefaultView;
            this.SetdgvEmployeeListHeadText();
            tscancelEnabled();

        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            
        }
        private void frmEmployee_Load_1(object sender, EventArgs e)
        {
            this.tscancelEnabled();
            dgvEmployee.DataSource = employee.GetAllEmployee().Tables[0].DefaultView;
            cmbtype.SelectedIndex = 0;
            this.SetdgvEmployeeListHeadText();
        }

        private void SetdgvEmployeeListHeadText()
        {
            //dgvEmployee.Columns[0].HeaderText = "职员编号";
            //dgvEmployee.Columns[1].HeaderText = "职员姓名";
            //dgvEmployee.Columns[2].HeaderText = "性别";
            //dgvEmployee.Columns[3].HeaderText = "所在部门";
            //dgvEmployee.Columns[4].HeaderText = "联系电话";
            //dgvEmployee.Columns[5].HeaderText = "备注";
        }

        private void tscancelEnabled()
        {
            groupBox1.Enabled = false;
            tlBtnAdd.Enabled = true;
            tlBtnEdit.Enabled = true;
            tlBtnDelete.Enabled = true;
            tlBtnSave.Enabled = false;
            tlBtnCancel.Enabled = false;
        }

        private void tlBtnAdd_Click(object sender, EventArgs e)
        {
            this.editEnabled();
            this.clearText();
            G_Int_addOrUpdate = 0;   //等于０为添加数据
        }

        private void clearText()
        {
            //txtEmpployCode.Text = string.Empty;
            txtFullName.Text = string.Empty;
            //cmbSex.Text = string.Empty;
            // txtDept.Text = string.Empty;
            txtTel.Text = string.Empty;
            txtMemo.Text = string.Empty;
        }

        private void editEnabled()
        {
            groupBox1.Enabled = true;     //将容器可以使用，准备添加新的往来单位信息
            tlBtnAdd.Enabled = false;
            tlBtnEdit.Enabled = false;
            tlBtnDelete.Enabled = false;
            tlBtnSave.Enabled = true;
            tlBtnCancel.Enabled = true;
        }

        private void tlBtnFind_Click(object sender, EventArgs e)
        {
            if (cmbtype.Text == string.Empty)
            {
                MessageBox.Show("查询类别不能为空！", "错误提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbtype.Focus();
                return;
            }
            else
            {
                if (tlTxtFindEmployee.Text.Trim() == string.Empty)
                {
                    dgvEmployee.DataSource = employee.GetAllEmployee().Tables[0].DefaultView;
                    this.SetdgvEmployeeListHeadText();
                    return;
                }
                DataSet ds = new DataSet();
                if (cmbtype.Text.Trim() == "所在部门")
                {
                    employee.Dept = tlTxtFindEmployee.Text.Trim();
                    ds = employee.FindEmployeeByDept(employee);
                    dgvEmployee.DataSource = ds.Tables[0].DefaultView;

                }
                else
                {
                    employee.FullName = tlTxtFindEmployee.Text.Trim();
                    ds = employee.FindEmployeeByFullName(employee);
                    dgvEmployee.DataSource = ds.Tables[0].DefaultView;
                }
                this.SetdgvEmployeeListHeadText();
            }
        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = (this.dgvEmployee[0, dgvEmployee.CurrentCell.RowIndex].Value.ToString());
                txtFullName.Text = this.dgvEmployee[1, dgvEmployee.CurrentCell.RowIndex].Value.ToString();
                cmbSex.Text = this.dgvEmployee[2, dgvEmployee.CurrentCell.RowIndex].Value.ToString();
                cmbdept.Text = this.dgvEmployee[3, dgvEmployee.CurrentCell.RowIndex].Value.ToString();
                txtTel.Text = this.dgvEmployee[4, dgvEmployee.CurrentCell.RowIndex].Value.ToString();
                txtMemo.Text = this.dgvEmployee[5, dgvEmployee.CurrentCell.RowIndex].Value.ToString();
            }
            catch (Exception exx)
            {
                MessageBox.Show("请选择有数据的记录", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void tlBtnDelete_Click(object sender, EventArgs e)
        {
            if (id == "")
            {
                MessageBox.Show("请选择要删除的数据，删除失败！", "错误提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

                employee.Id = id;
                employee.DeleteEmployee(employee);
                MessageBox.Show("删除--公司职员数据--成功！", "成功提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvEmployee.DataSource = employee.GetAllEmployee().Tables[0].DefaultView;
                this.SetdgvEmployeeListHeadText();
                this.clearText();
            }
        }

        private void tlBtnEdit_Click(object sender, EventArgs e)
        {
            if (id == "")
            {
                MessageBox.Show("请选择要修改的数据！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                G_Int_addOrUpdate = 1;
                editEnabled();
            }
        }

        private void tlBtnCancel_Click(object sender, EventArgs e)
        {
            tscancelEnabled();
        }

        private void tsBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if ((int)e.KeyChar <= 32)
            {

                return;
            }
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

 
    }
}