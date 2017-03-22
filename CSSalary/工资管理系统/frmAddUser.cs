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
    public partial class frmAddUser : Form
    {
        private usersTableAdapter dAUsers = new usersTableAdapter();
        private yuangongbiaoTableAdapter dAEmployees = new yuangongbiaoTableAdapter();
        private string name;
        private string id;
        private string pwd;
        biyeshejiDataSet.usersDataTable dtUsers = new biyeshejiDataSet.usersDataTable();
        biyeshejiDataSet.yuangongbiaoDataTable dtEmployees = new biyeshejiDataSet.yuangongbiaoDataTable();

        public frmAddUser()
        {
            InitializeComponent();
        }

        private void GetUserFromControl()
        {
            this.name = this.txtName.Text.Trim();
            this.id = this.txtID.Text.Trim();
            this.pwd = this.txtPwd.Text;
        }



        private void AddUser()
        {
            try
            {

                dAUsers.Fill(dtUsers);
                dAEmployees.Fill(dtEmployees);

                if (dtUsers.Any(x => x.ygbh == this.id))
                {
                    MessageBox.Show("user表已经存在相同编号的员工！");
                }
                else if (dtEmployees.Any(x => x.姓名 == this.name))
                {
                    MessageBox.Show("yuangongbiao表已经存在相同姓名的员工！！");
                }
                else if (dtEmployees.Any(x => x.员工编号 == this.id))
                {
                    MessageBox.Show("yuangongbiao表已经存在相同员工编号的员工！！");
                }
                else
                {

                    using (OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.bysj))
                    {
                        OleDbCommand cmd1 = new OleDbCommand("insert into [users] (ygbh,pwd) values (@ygbh,@pwd)", conn);
                        cmd1.Parameters.Add("@ygbh", OleDbType.VarChar, 20).Value = this.id;
                        cmd1.Parameters.Add("@pwd", OleDbType.VarChar, 20).Value = this.pwd;
                        conn.Open();
                        cmd1.ExecuteNonQuery();

                        OleDbCommand cmd2 = new OleDbCommand("insert into [yuangongbiao] (姓名,员工编号) values (@name,@id)", conn);
                        cmd2.Parameters.Add("@name", OleDbType.VarChar, 20).Value = this.name;
                        cmd2.Parameters.Add("@id", OleDbType.VarChar, 20).Value = this.id;
                        cmd2.ExecuteNonQuery();
                    }
                    MessageBox.Show("添加成功！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.txtPwd.Text == this.txtPwd2.Text)
            {
                this.GetUserFromControl();
                if (string.IsNullOrWhiteSpace(this.name))
                {
                    MessageBox.Show("姓名不能为空！");
                }
                else if (string.IsNullOrWhiteSpace(this.id))
                {
                    MessageBox.Show("id不能为空！");
                }
                else
                {
                    this.AddUser();
                }
            }
            else
            {
                MessageBox.Show("两次密码不一致！");
            }
        }

        private void frmAddUser_Load(object sender, EventArgs e)
        {

        }
    }
}
