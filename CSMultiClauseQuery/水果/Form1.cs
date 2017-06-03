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
            myDataSet = new DataSet();
            myConnection.Open();
            myDataSet.Clear();
            string strDa = "SELECT * from sg";
            OleDbDataAdapter myDa = new OleDbDataAdapter(strDa, myConnection);

            myDa.Fill(myDataSet, "sg");
            dataGridView1.DataSource = myDataSet.Tables["sg"];

            myBind = this.BindingContext[myDataSet, "sg"];

            myConnection.Close();

            dataGridView1.Columns[0].Width = 50;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
