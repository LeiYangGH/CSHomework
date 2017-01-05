using System;
using System.Windows.Forms;

namespace StackedHeader
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();

            Decorator render = new Decorator(dataGridView1);
        }

        private void Test_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.e = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ee = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.Column1.HeaderText = "Parent.Child 1.Input 1";
            this.Column1.Name = "Column1";

            this.e.HeaderText = "Parent.Child 1.Input 2";
            this.e.Name = "e";

            this.Column2.HeaderText = "Parent.Input 3";
            this.Column2.Name = "Column2";

            this.ee.HeaderText = "Parent.Input 4";
            this.ee.Name = "ee";

            this.dataGridView1.Columns.AddRange(
                new System.Windows.Forms.DataGridViewColumn[]
                {
                    this.Column1,
                    this.e,
                    this.Column2,
                    this.ee
                });
        }
    }
}
