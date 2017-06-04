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
    public partial class 用户 : Form
    {
        OleDbConnection myConnection;
        string strConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=dl.mdb";
        public DataSet myDataSet;
        BindingManagerBase myBind;
        bool isBinding = false;
        float a, b, c, d;
        public 用户()
        {
            InitializeComponent();
        }

        private void 用户_Load(object sender, EventArgs e)
        {
            myConnection = new OleDbConnection(strConnection);
            myDataSet = new DataSet();
            myConnection.Open();
            myDataSet.Clear();
            string strDa = "SELECT * from dlxxb";
            OleDbDataAdapter myDa = new OleDbDataAdapter(strDa, myConnection);

            myDa.Fill(myDataSet, "dlxxb");
            dataGridView1.DataSource = myDataSet.Tables["dlxxb"];

            myBind = this.BindingContext[myDataSet, "dlxxb"];
            if (!isBinding)
            {
                姓名.DataBindings.Add("Text", myDataSet, "dlxxb.name");
                密码.DataBindings.Add("Text", myDataSet, "dlxxb.password");
                部职别.DataBindings.Add("Text", myDataSet, "dlxxb.bzb");
                textBox4.DataBindings.Add("Text", myDataSet, "dlxxb.yhlx");  
                isBinding = true;
            }
            myConnection.Close();

            dataGridView1.Columns[0].Width = 50;
        }

        private void 部职别_TextChanged(object sender, EventArgs e)
        {

        }

        private void 密码_TextChanged(object sender, EventArgs e)
        {

        }

        private void 姓名_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void 用户类型_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1CellClick();
        }
        private void dataGridView1CellClick()
        {
            myBind.Position = dataGridView1.CurrentCell.RowIndex;

            float.TryParse(姓名.Text, out a);
            float.TryParse(密码.Text, out b);
            float.TryParse(部职别.Text, out c);
            float.TryParse(textBox4.Text, out d);
            List<string> xData = new List<string>() { "1", "2", "3", "4", "5" };
            List<float> yData = new List<float>() { a, b, c, d };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strDele = "delete from dlxxb where name='" + 姓名.Text + "'";
            OleDbDataAdapter myDa = new OleDbDataAdapter();
            myDa = new OleDbDataAdapter(strDele, myConnection);
            myDa.Fill(myDataSet, "dlxxb");
            myDataSet.Clear();
            ///刷新dataGridView1显示

            string strDa = "SELECT * from dlxxb";
            OleDbDataAdapter myDa1 = new OleDbDataAdapter(strDa, myConnection);

            myDa1.Fill(myDataSet, "dlxxb");
            dataGridView1.DataSource = myDataSet.Tables["dlxxb"];  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            姓名.Text = myDataSet.Tables[0].Rows[dataGridView1.CurrentRow.Index][0].ToString();//显示第1行第1列的一个值
            密码.Text = myDataSet.Tables[0].Rows[dataGridView1.CurrentRow.Index][1].ToString();//显示第1行第2列的一个值
            部职别.Text = myDataSet.Tables[0].Rows[dataGridView1.CurrentRow.Index][2].ToString();//显示第1行第3列的一个值
            textBox4.Text = myDataSet.Tables[0].Rows[dataGridView1.CurrentRow.Index][3].ToString();//显示第1行第4列的一个值
            string sql = "select * from dlxxb";
            OleDbDataAdapter da = new OleDbDataAdapter(sql, myConnection);
            OleDbCommandBuilder bld = new OleDbCommandBuilder(da);
            da.UpdateCommand = bld.GetUpdateCommand();
            //把DataGridView赋值给dataTable。(DataTable)的意思是类型转换，前提是后面紧跟着的东西要能转换成dataTable类型
            DataTable dt = (DataTable)dataGridView1.DataSource;
            da.Update(dt);
            dt.AcceptChanges();
            
            string strData = "SELECT * from dlxxb";
            OleDbDataAdapter myData = new OleDbDataAdapter(strData, myConnection);
            DataSet myDataSet1 = new DataSet();
            myData.Fill(myDataSet1, "dlxxb");
            dataGridView1.DataSource = myDataSet1.Tables["dlxxb"]; 
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        

       

       
        

        

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            Form5 form = new Form5();
            form.Show();
            this.Hide();
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            增加 form = new 增加();
            form.Show();
            this.Hide();
        }

        private void toolStripButton4_Click_1(object sender, EventArgs e)
        {
            改删 form = new 改删();
            form.Show();
            this.Hide();
        }

        private void toolStripButton5_Click_1(object sender, EventArgs e)
        {
            数据展示 form = new 数据展示();
            form.Show();
            this.Hide();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            用户管理 form = new 用户管理();
            form.Show();
            this.Hide();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            DialogResult myresult;
            myresult = MessageBox.Show("是否退出程序", "退出提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (myresult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (myresult == DialogResult.No)
            {
                return;
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            登录 form = new 登录();
            form.Show();
            this.Hide();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            模糊查询 form = new 模糊查询();
            form.Show();
            this.Hide();
        }
    }
}
