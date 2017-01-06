using Newtonsoft.Json;
using System;
using System.Linq;
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

        private void button1_Click(object sender, EventArgs e)
        {
            string json = this.textBox1.Text.Trim();
            this.layeredHeaderDataGridView1.SetColumnsHeaderJson(json);
        }
    }
}
