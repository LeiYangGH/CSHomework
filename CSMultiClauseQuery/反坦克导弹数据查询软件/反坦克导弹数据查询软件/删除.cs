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
    public partial class 删除 : Form
    {
        OleDbConnection myConnection;
        string strConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=DD.mdb";
        public DataSet myDataSet;
        BindingManagerBase myBind;
        bool isBinding = false;
        float a, b, c, d, e1;
        
        
        public 删除()
        {
            InitializeComponent();
        }
        
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            模糊查询 form = new 模糊查询();
            form.Show();
            this.Hide();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Form5 form = new Form5();
            form.Show();
            this.Hide();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            增加 form = new 增加();
            form.Show();
            this.Hide();
        }

        private void 改删_Load(object sender, EventArgs e)
        {
            myConnection = new OleDbConnection(strConnection);
            myDataSet = new DataSet();
            myConnection.Open();
            myDataSet.Clear();
            string strDa = "SELECT * from AKD";
            OleDbDataAdapter myDa = new OleDbDataAdapter(strDa, myConnection);

            myDa.Fill(myDataSet, "AKD");
            dataGridView1.DataSource = myDataSet.Tables["AKD"];

            myBind = this.BindingContext[myDataSet, "AKD"];
            if (!isBinding)
            {
                导弹名称.DataBindings.Add("Text", myDataSet, "AKD.导弹名称");
                国家.DataBindings.Add("Text", myDataSet, "AKD.国家");
                导弹弹长.DataBindings.Add("Text", myDataSet, "AKD.导弹弹长");
                导弹弹径.DataBindings.Add("Text", myDataSet, "AKD.导弹弹径");
                导弹翼展.DataBindings.Add("Text", myDataSet, "AKD.导弹翼展");
                导弹弹重.DataBindings.Add("Text", myDataSet, "AKD.导弹弹重");
                导弹最小射程.DataBindings.Add("Text", myDataSet, "AKD.导弹最小射程");
                导弹最大射程.DataBindings.Add("Text", myDataSet, "AKD.导弹最大射程");
                飞行速度.DataBindings.Add("Text", myDataSet, "AKD.飞行速度");
                破甲厚度.DataBindings.Add("Text", myDataSet, "AKD.破甲厚度");
                战斗部.DataBindings.Add("Text", myDataSet, "AKD.战斗部");
                制导方式.DataBindings.Add("Text", myDataSet, "AKD.制导方式");
                导引头.DataBindings.Add("Text", myDataSet, "AKD.导引头");
                动力装置.DataBindings.Add("Text", myDataSet, "AKD.动力装置");
                命中概率.DataBindings.Add("Text", myDataSet, "AKD.命中概率");
                发射载体.DataBindings.Add("Text", myDataSet, "AKD.发射载体");
                使用条件.DataBindings.Add("Text", myDataSet, "AKD.使用条件");
                生产厂家.DataBindings.Add("Text", myDataSet, "AKD.生产厂家");

                isBinding = true;
            }
            myConnection.Close();

            dataGridView1.Columns[0].Width = 50;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
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
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1CellClick(); 
        }
        private void dataGridView1CellClick()
        {
            myBind.Position = dataGridView1.CurrentCell.RowIndex;

            float.TryParse(导弹名称.Text, out a);
            float.TryParse(国家.Text, out b);
            float.TryParse(导弹弹长.Text, out c);
            float.TryParse(导弹弹径.Text, out d);
            float.TryParse(导弹翼展.Text, out e1);
            List<string> xData = new List<string>() { "1", "2", "3", "4", "5" };
            List<float> yData = new List<float>() { a, b, c, d, e1 };
        }

        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            string strDele = "delete from AKD where 导弹名称='" + 导弹名称.Text + "'";
            OleDbDataAdapter myDa = new OleDbDataAdapter();
            myDa = new OleDbDataAdapter(strDele, myConnection);
            myDa.Fill(myDataSet, "AKD");
            myDataSet.Clear();
            ///刷新dataGridView1显示

            string strDa = "SELECT * from AKD";
            OleDbDataAdapter myDa1 = new OleDbDataAdapter(strDa, myConnection);

            myDa1.Fill(myDataSet, "AKD");
            dataGridView1.DataSource = myDataSet.Tables["AKD"];  
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
            修改 form = new 修改();
            form.Show();
            this.Hide();
        }
    }
}
