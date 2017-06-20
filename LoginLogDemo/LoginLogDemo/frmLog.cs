using BigJob;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginLogDemo
{
    public partial class frmLog : Form
    {
        public frmLog()
        {
            InitializeComponent();
        }

        private void frmLog_Load(object sender, EventArgs e)
        {
            DataTable dt = AccessHelper.ExecuteDataSet("select * from S_log", null).Tables[0];
            this.dataGridView1.DataSource = dt;
            this.dataGridView1.Columns[1].HeaderText = "用户名";
            this.dataGridView1.Columns[2].HeaderText = "操作";
            this.dataGridView1.Columns[3].HeaderText = "时间";
        }
    }
}
