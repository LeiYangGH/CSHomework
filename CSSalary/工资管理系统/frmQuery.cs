using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 工资管理系统.biyeshejiDataSetTableAdapters;

namespace 工资管理系统
{
    public partial class frmQuery : Form
    {
        private DateTime startDt;
        private DateTime endDt;
        private gongzibiaoALLTableAdapter gongzibiaoALLTableAdapter = new gongzibiaoALLTableAdapter();
        private biyeshejiDataSet.gongzibiaoALLDataTable dt = new biyeshejiDataSet.gongzibiaoALLDataTable();

        public frmQuery()
        {
            InitializeComponent();
        }

        private void frmQuery_Load(object sender, EventArgs e)
        {
            this.txtId.Text = frmLogin.userID;
            this.txtName.Text = frmLogin.userName;
            this.gongzibiaoALLTableAdapter.Fill(this.dt);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.startDt = this.dtpStart.Value.Date;
            this.endDt = this.dtpEnd.Value.Date;

            biyeshejiDataSet.gongzibiaoALLDataTable dtemp = new biyeshejiDataSet.gongzibiaoALLDataTable();
            foreach (biyeshejiDataSet.gongzibiaoALLRow row in this.dt.Where(x =>
                   x.员工编号 == frmLogin.userID
                   && x.年月 >= this.startDt
                   && x.年月 <= this.endDt))
            {
                dtemp.ImportRow(row);
            }
            this.dataGridView1.DataSource = dtemp;
        }
    }
}
