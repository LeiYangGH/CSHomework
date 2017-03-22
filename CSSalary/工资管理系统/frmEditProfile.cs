using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 工资管理系统.biyeshejiDataSetTableAdapters;

namespace 工资管理系统
{
    public partial class frmEditProfile : Form
    {
        private biyeshejiDataSet.yuangongbiaoDataTable dtEmployees = new biyeshejiDataSet.yuangongbiaoDataTable();
        private yuangongbiaoTableAdapter yuangongbiaoTableAdapter = new yuangongbiaoTableAdapter();

        public frmEditProfile()
        {
            InitializeComponent();
        }

        private void ShowEmployee(biyeshejiDataSet.yuangongbiaoRow row)
        {
            this.rdbM.Checked = row.性别 == "男" ? true : false;
            this.rdbF.Checked = !this.rdbM.Checked;
            this.txtAdd.Text = row.家庭地址;
            this.txtDep.Text = row.部门编号;
            this.txtTel.Text = row.联系电话;
            this.txtAge.Text = row.年龄;
            this.txtBirth.Text = row.生日;
        }

        private void frmEditProfile_Load(object sender, EventArgs e)
        {
            yuangongbiaoTableAdapter.Fill(dtEmployees);
            this.txtId.Text = frmLogin.userID;
            this.txtName.Text = frmLogin.userName;
            var row = this.dtEmployees.FirstOrDefault(x => x.员工编号 == frmLogin.userID);
            if (row == null)
            {
                MessageBox.Show("在员工表里没查到登录编号，可能是因为以管理员身份登录，数据不一致");
                this.Close();
            }
            else
                this.ShowEmployee(row);
        }

        private void numAge_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpBirth_ValueChanged(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.bysj))
                {
                    OleDbCommand cmd = new OleDbCommand("update   [yuangongbiao] set 性别=@sex,家庭地址=@add,部门编号=@dep,联系电话=@tel,年龄=@age,生日=@birth where 员工编号=@id", conn);
                    cmd.Parameters.AddWithValue("@sex", this.rdbM.Checked ? "男" : "女");
                    cmd.Parameters.AddWithValue("@add", this.txtAdd.Text);
                    cmd.Parameters.AddWithValue("@dep", this.txtDep.Text);
                    cmd.Parameters.AddWithValue("@tel", this.txtTel.Text);
                    cmd.Parameters.AddWithValue("@age", this.txtAge.Text);
                    cmd.Parameters.AddWithValue("@birth", this.txtBirth.Text);
                    cmd.Parameters.AddWithValue("@id", frmLogin.userID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("更新成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
