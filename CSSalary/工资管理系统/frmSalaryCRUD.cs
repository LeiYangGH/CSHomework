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
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            biyeshejiDataSet.gongzibiaoALLRow row = this.dt.NewgongzibiaoALLRow();
            row.员工编号 = "123";
            row.基本工资 = "10000";
            row.工龄工资 = "1000";
            this.dt.Rows.Add(row);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.gongzibiaoALLTableAdapter.Update(this.dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
