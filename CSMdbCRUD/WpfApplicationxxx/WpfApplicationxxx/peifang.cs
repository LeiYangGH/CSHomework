using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.OleDb;
using System.Data.SqlClient;



namespace WpfApplicationxxx
{
    public partial class peifang : Form
    {
        public peifang()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void peifang_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“peifang2DataSet.peifang2”中。您可以根据需要移动或删除它。
            //      this.peifang2TableAdapter1.Fill(this.peifang2DataSet1.peifang2);

            dataGridView1.DataSource = peifang2DataSet1;

        }
    }
}
