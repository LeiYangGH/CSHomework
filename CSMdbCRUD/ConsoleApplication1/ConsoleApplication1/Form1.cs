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
namespace ConsoleApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“peifang2DataSet.peifang2”中。您可以根据需要移动或删除它。
            this.peifang2TableAdapter.Fill(this.peifang2DataSet.peifang2);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.peifang2TableAdapter.Update(this.peifang2DataSet.peifang2);
                MessageBox.Show("ok");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.peifang2DataSet.peifang2.Rows.Add(this.peifang2DataSet.peifang2.NewRow());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.peifang2DataSet.peifang2.Rows[this.dataGridView1.CurrentCell.RowIndex].Delete();
        }
    }
}
