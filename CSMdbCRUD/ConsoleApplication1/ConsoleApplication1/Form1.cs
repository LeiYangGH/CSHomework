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
            var r = this.peifang2DataSet.peifang2.NewRow();
            //r[0] = this.peifang2DataSet.peifang2.Rows
            //    .OfType<peifang2DataSet.peifang2Row>()
            //    .Max(x => Convert.ToInt32(x[0]))+1;
                
            this.peifang2DataSet.peifang2.Rows.Add(r);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.peifang2DataSet.peifang2.Rows[this.dataGridView1.CurrentCell.RowIndex].Delete();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            var r = this.dataGridView1.SelectedRows;
            if(r!=null && r.Count>0)
            {
                var sel = this.dataGridView1.SelectedRows[0];
                this.label1.Text = sel.Cells[1].Value.ToString();
                this.label2.Text = sel.Cells[2].Value.ToString();
                this.label3.Text = sel.Cells[3].Value.ToString();
            }
        }
    }
}
