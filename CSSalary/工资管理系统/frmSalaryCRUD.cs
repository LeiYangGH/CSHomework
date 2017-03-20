using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using 工资管理系统.biyeshejiDataSetTableAdapters;

namespace 工资管理系统
{
    public partial class frmSalaryCRUD : Form
    {
        private gongzibiaoALLTableAdapter gongzibiaoALLTableAdapter = new gongzibiaoALLTableAdapter();
        private biyeshejiDataSet.gongzibiaoALLDataTable dt = new biyeshejiDataSet.gongzibiaoALLDataTable();
        public frmSalaryCRUD()
        {
            InitializeComponent();
        }

        private void gongziguanli_Load(object sender, EventArgs e)
        {
            this.gongzibiaoALLTableAdapter.Fill(this.dt);
            this.gongzibiaoALLDataGridView.DataSource = this.dt;
#if TEST
            frmLogin.userName = "张总";
            frmLogin.isAdmin = true;
            this.txtBasicSalary.Text = "10000";
            this.txtYearSalary.Text = "1000";
            this.txtBonus.Text = "200";
            this.txtDeduct.Text = "10";
#endif
            this.txtID.Text = frmLogin.userID;
            this.txtName.Text = frmLogin.userName;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void SetFieldValues(biyeshejiDataSet.gongzibiaoALLRow row)
        {
            row.员工编号 = this.txtID.Text.Trim();
            row.姓名 = this.txtName.Text.Trim();
            row.基本工资 = Convert.ToDouble(this.txtBasicSalary.Text.Trim());
            row.工龄工资 = Convert.ToDouble(this.txtYearSalary.Text.Trim());
            row.奖金 = Convert.ToDouble(this.txtBonus.Text.Trim());
            row.扣除 = Convert.ToDouble(this.txtDeduct.Text.Trim());
            row.合计 = row.基本工资 + row.工龄工资 + row.奖金 - row.扣除;
            row.年月 = DateTime.Now.Date;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            biyeshejiDataSet.gongzibiaoALLRow row = this.dt.NewgongzibiaoALLRow();
            this.SetFieldValues(row);
            this.dt.Rows.Add(row);
        }

        biyeshejiDataSet.gongzibiaoALLRow GetSelectedRowByID()
        {
            return this.dt.FirstOrDefault(x => x.员工编号 == this.txtID.Text.Trim());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.gongzibiaoALLTableAdapter.Update(this.dt);
                MessageBox.Show("保存成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var selRow = this.GetSelectedRowByID();
            if (selRow == null)
            {
                MessageBox.Show("没有ID对应的数据，无法更新！");
                return;
            }
            this.SetFieldValues(selRow);
        }
    }
}
