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
            //frmLogin.userName = "张总";
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

        private void ClearTextBoxes()
        {
            this.txtBasicSalary.Text = "0";
            this.txtYearSalary.Text = "0";
            this.txtBonus.Text = "0";
            this.txtDeduct.Text = "0";
        }

        private string GetNameById(string id)
        {
            var row = frmLogin.AllUsersDt.FirstOrDefault(x => x.员工编号.Trim() == id.Trim());
            if (row == null)
                return "";
            else
                return row.姓名;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var selRow = this.GetSelectedRowByID();
            if (selRow == null)
            {
                this.ClearTextBoxes();
                this.txtName.Text = this.GetNameById(this.txtID.Text.Trim());
            }
            else
            {
                this.RefreshSelectRowToTextBoxes(selRow);
            }

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
            var selRow = this.GetSelectedRowByID();
            if (selRow == null)
            {
                biyeshejiDataSet.gongzibiaoALLRow row = this.dt.NewgongzibiaoALLRow();
                this.SetFieldValues(row);
                this.dt.Rows.Add(row);
            }
            else
            {
                MessageBox.Show("已有ID对应的数据，一个员工一个天只能添加一次！");
            }

        }

        biyeshejiDataSet.gongzibiaoALLRow GetSelectedRowByID()
        {
            DateTime date = DateTime.Now.Date;
            return this.dt.FirstOrDefault(x =>
            x.员工编号 == this.txtID.Text.Trim()
            && x.年月.Date == date
            );
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

        private void btnDel_Click(object sender, EventArgs e)
        {
            var selRow = this.GetSelectedRowByID();
            if (selRow == null)
            {
                MessageBox.Show("没有ID对应的数据，无法删除！");
                return;
            }
            this.dt.Rows.Remove(selRow);
        }

        private void RefreshSelectRowToTextBoxes(biyeshejiDataSet.gongzibiaoALLRow row)
        {
            this.txtID.Text = row.员工编号;
            this.txtName.Text = row.姓名;
            this.txtBasicSalary.Text = row.基本工资.ToString();
            this.txtYearSalary.Text = row.工龄工资.ToString();
            if (row["奖金"] == DBNull.Value)
                this.txtBonus.Text = "0";
            else
                this.txtBonus.Text = row.奖金.ToString();
            //this.txtBonus.Text = row["奖金"].ToString();
            if (row["扣除"] == DBNull.Value)
                this.txtDeduct.Text = "0";
            else
                this.txtDeduct.Text = row.扣除.ToString();
        }

        private void gongzibiaoALLDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            var selrows = gongzibiaoALLDataGridView.SelectedRows;
            if (selrows != null && selrows.Count > 0)
            {
                string id = selrows[0].Cells["员工编号"].Value.ToString().Trim();
                DateTime date = Convert.ToDateTime(selrows[0].Cells["年月"].Value).Date;
                if (this.txtID.Text.Trim() != id)
                {
                    this.RefreshSelectRowToTextBoxes(this.dt.First(x =>
                    x.员工编号 == id && x.年月.Date == date
                    ));
                }
            }
        }
    }
}
