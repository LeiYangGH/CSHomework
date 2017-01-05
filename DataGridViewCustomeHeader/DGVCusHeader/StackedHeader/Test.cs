using Newtonsoft.Json;
using System;
using System.Linq;
using System.Windows.Forms;

namespace StackedHeader
{
    public partial class Test : Form
    {
        JsonHeader jheader;


        public Test()
        {
            InitializeComponent();
        }


        private void GenJheader()
        {
            this.jheader = new JsonHeader("0");
            var h1 = new JsonHeader("1");
            var h2 = new JsonHeader("2");
            jheader.C.Add(h1);
            jheader.C.Add(h2);

            var h11 = new JsonHeader("11");
            var h12 = new JsonHeader("12");
            h1.C.Add(h11);
            h1.C.Add(h12);

            var h21 = new JsonHeader("21");
            var h22 = new JsonHeader("22");
            h2.C.Add(h21);
            h2.C.Add(h22);


            string exp = JsonConvert.SerializeObject(this.jheader);

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
            string json = this.textBox1.Text.Trim();
            JsonHeader jh = JsonConvert.DeserializeObject<JsonHeader>(json);
            if(jh==null)
            {
                MessageBox.Show("json不符合规定格式！");
            }
            else
            {
                int cnt = json.Count(x => x == 'T');
                for (int i=0;i< cnt;i++)
                {
                    this.layeredHeaderDataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                }
                this.layeredHeaderDataGridView1.GenerateColumns(jh);
            }
        }
    }
}
