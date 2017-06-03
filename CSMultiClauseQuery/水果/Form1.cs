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

namespace 水果
{

    public partial class Form1 : Form
    {
        OleDbConnection myConnection;
        string strConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=水果.mdb";
        public DataSet myDataSet;
        BindingManagerBase myBind;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myConnection = new OleDbConnection(strConnection);
            DataTable dt = new DataTable();
            myConnection.Open();
           
            string strDa = "SELECT * from sg";
            OleDbDataAdapter myDa = new OleDbDataAdapter(strDa, myConnection);

            myDa.Fill(dt);
            var lstFruits = dt.Rows.OfType<DataRow>()
                .Select(x => new Fruit(
                    x[0].ToString(),
                    x[1].ToString(),
                    x[2].ToString(),
                    x[3].ToString(),
                    x[4].ToString(),
                    x[5].ToString()
                    )).ToList();
            dataGridView1.DataSource = dt;
            dataGridView1.DataSource = lstFruits;

            //myBind = this.BindingContext[myDataSet, "sg"];

            myConnection.Close();

            //dataGridView1.Columns[0].Width = 50;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    public class Fruit
    {
        public Fruit(string n, string s, string pl, string c, string t, string pr)
        {
            this.Name = n;
            this.Season = s;
            this.Place = pl;
            this.Color = c;
            this.Type = t;
            this.Price = pr;
        }
        [DisplayName("水果名称")]
        public string Name { get; set; }

        [DisplayName("产地")]
        public string Place { get; set; }

        [DisplayName("季节")]
        public string Season { get; set; }

        [DisplayName("类型")]
        public string Type { get; set; }

        [DisplayName("颜色")]
        public string Color { get; set; }

        [DisplayName("价格")]
        public string Price { get; set; }
    }
}
