using System;
using System.Windows.Forms;

namespace StackedHeader
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();

            Decorator objREnderer = new Decorator(dataGridView1);
            //dataGridView1.Columns[0].Visible = false;
            //dataGridView1.Columns[2].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; ++i)
            {
                int columnCount = dataGridView1.Columns.Count;
                dataGridView1.Columns.Add("Column" + dataGridView1.Columns.Count,
                                          "Parent[" + columnCount + "].Child 1.Child 2.Input Name");
                dataGridView1.Columns.Add("Column" + dataGridView1.Columns.Count ,
                                          "Parent[" + columnCount + "].Child 1.Child 2.Input Name 2");
                dataGridView1.Columns.Add("Column" + dataGridView1.Columns.Count,
                                          "Parent[" + columnCount + "].Child 1.Child 3.Input Name 3");
                dataGridView1.Columns.Add("Column" + dataGridView1.Columns.Count ,
                                          "Parent[" + columnCount + "].Child 1.Input Name 4");
                dataGridView1.Columns.Add("Column" + dataGridView1.Columns.Count ,
                                          "Parent[" + columnCount + "].Input Name 5");
            }
        }
    }
}
