using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 反坦克导弹数据查询软件
{
    public partial class frmUpdate : Form
    {
        public frmUpdate()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.aKDTableAdapter.Update(this.dDDataSet.AKD);
            MessageBox.Show("ok");
        }

        private void frmUpdate_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dDDataSet.AKD' table. You can move, or remove it, as needed.
            this.aKDTableAdapter.Fill(this.dDDataSet.AKD);


        }
    }
}
