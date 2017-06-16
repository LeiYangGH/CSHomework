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
    public partial class productInfo : Form
    {
        public productInfo()
        {
            InitializeComponent();
        }
        database link = new database();

        private void productInfo_Load(object sender, EventArgs e)
        {
            string sql = "select * from S_product";
            DataSet ds = new DataSet();
            ds = link.SelectDataBase(sql, "S_product");
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].HeaderCell.Value = "产品代码";
            dataGridView1.Columns[1].HeaderCell.Value = "产品编号";
            dataGridView1.Columns[2].HeaderCell.Value = "产品名称";
            dataGridView1.Columns[3].HeaderCell.Value = "产品类型代码";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
