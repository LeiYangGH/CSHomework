using System;
using System.Windows.Forms;

namespace StackedHeader
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {

        }

        private void Add1()
        {
            DataGridViewTextBoxColumn Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn e = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn ee = new System.Windows.Forms.DataGridViewTextBoxColumn();

            Column1.HeaderText = "Parent.Child 1.Input 1";
            Column1.Name = "Column1";

            e.HeaderText = "Parent.Child 1.Input 2";
            e.Name = "e";

            Column2.HeaderText = "Parent.Input 3";
            Column2.Name = "Column2";

            ee.HeaderText = "Parent.Input 4";
            ee.Name = "ee";

            this.layeredHeaderDataGridView1.Columns.AddRange(
                new System.Windows.Forms.DataGridViewColumn[]
                {
                    Column1,
                    e,
                   Column2,
                   ee
                });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Add1();
        }
    }
}
