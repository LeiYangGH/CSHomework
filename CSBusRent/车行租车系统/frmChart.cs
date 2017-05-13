using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 车行租车系统
{
    public partial class frmChart : Form
    {
        private DataTable dt;
        public frmChart()
        {
            InitializeComponent();
        }

        private void GetTable()
        {
            string sql = @"SELECT j. [ID],[LeiXing],u.Sex,[StartTime],[EndTime]
                          FROM [CheHang].[dbo].[TB_JieYue] j
                          left join [CheHang].[dbo].[TB_User] u
                          on u.UserName = j.UserName";
            this.dt = DBHelper.GetDate(sql).Tables[0];
        }

        private void frmChart_Load(object sender, EventArgs e)
        {
            this.GetTable();
            this.dataGridView1.DataSource = this.dt;
        }
    }
}
