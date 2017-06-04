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
    public partial class Form5 : Form
    {
        OleDbConnection myConnection;
        string strConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=DD.mdb";
        DataTable dt;
        public Form5()
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
            增加 form = new 增加();
            form.Show();
            this.Hide();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            改删 form = new 改删();
            form.Show();
            this.Hide();
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

        private void BtSearch_Click(object sender, EventArgs e)
        {
            //myConnection = new OleDbConnection(strConnection);
            //myDataSet = new DataSet();
            //myConnection.Open();
            //myDataSet.Clear();
            //string strDa = "SELECT * from AKD";
            //OleDbDataAdapter myDa = new OleDbDataAdapter(strDa, myConnection);

            //myDa.Fill(myDataSet, "AKD");
            //dataGridView1.DataSource = myDataSet.Tables["AKD"];

            //myBind = this.BindingContext[myDataSet, "AKD"];

            //myConnection.Close();


            if (this.dt == null)
            {
                this.dt = new DataTable();
                myConnection = new OleDbConnection(strConnection);
                myConnection.Open();

                string strDa = "SELECT * from AKD";
                OleDbDataAdapter myDa = new OleDbDataAdapter(strDa, myConnection);

                myDa.Fill(dt);
                myConnection.Close();

            }

            var lstFruits = dt.Rows.OfType<DataRow>()
                .Select(x => new Fruit(
                    x[0].ToString(),
                    x[1].ToString(),
                    x[2].ToString(),
                    x[3].ToString(),
                    x[4].ToString(),
                    x[5].ToString(),
                    x[6].ToString(),
                    x[7].ToString()
                    ));

            if (this.checkBox1.Checked)
                lstFruits = lstFruits.Where(x => x.P1.Trim().Contains(this.txtSearch1.Text.Trim()));
            if (this.checkBox2.Checked)
                lstFruits = lstFruits.Where(x => x.P2.Trim().Contains(this.txtSearch2.Text.Trim()));
            if (this.checkBox3.Checked)
                lstFruits = lstFruits.Where(x => x.P3.Trim().Contains(this.txtSearch3.Text.Trim()));
            if (this.checkBox4.Checked)
                lstFruits = lstFruits.Where(x => x.P4.Trim().Contains(this.txtSearch4.Text.Trim()));
            if (this.checkBox5.Checked)
                lstFruits = lstFruits.Where(x => x.P5.Trim().Contains(this.txtSearch5.Text.Trim()));
            if (this.checkBox6.Checked)
                lstFruits = lstFruits.Where(x => x.P6.Trim().Contains(this.txtSearch6.Text.Trim()));
            if (this.checkBox7.Checked)
                lstFruits = lstFruits.Where(x => x.P7.Trim().Contains(this.txtSearch7.Text.Trim()));
            if (this.checkBox8.Checked)
                lstFruits = lstFruits.Where(x => x.P8.Trim().Contains(this.txtSearch8.Text.Trim()));


            dataGridView1.DataSource = lstFruits.ToList();

            //myBind = this.BindingContext[myDataSet, "sg"];


            dataGridView1.Columns[0].Width = 50;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                //导弹名称.Text = dataGridView1.CurrentRow.Cells["导弹名称"].Value.ToString();
                //国家.Text = dataGridView1.CurrentRow.Cells["国家"].Value.ToString();
                //导弹弹长.Text = dataGridView1.CurrentRow.Cells["导弹弹长"].Value.ToString();
                //导弹弹径.Text = dataGridView1.CurrentRow.Cells["导弹弹径"].Value.ToString();
                //导弹翼展.Text = dataGridView1.CurrentRow.Cells["导弹翼展"].Value.ToString();
                //导弹弹重.Text = dataGridView1.CurrentRow.Cells["导弹弹重"].Value.ToString();
                //导弹最小射程.Text = dataGridView1.CurrentRow.Cells["导弹最小射程"].Value.ToString();
                //导弹最大射程.Text = dataGridView1.CurrentRow.Cells["导弹最大射程"].Value.ToString();
                //飞行速度.Text = dataGridView1.CurrentRow.Cells["飞行速度"].Value.ToString();
                //破甲厚度.Text = dataGridView1.CurrentRow.Cells["破甲厚度"].Value.ToString();
                //战斗部.Text = dataGridView1.CurrentRow.Cells["战斗部"].Value.ToString();
                //制导方式.Text = dataGridView1.CurrentRow.Cells["制导方式"].Value.ToString();
                //导引头.Text = dataGridView1.CurrentRow.Cells["导引头"].Value.ToString();
                //动力装置.Text = dataGridView1.CurrentRow.Cells["动力装置"].Value.ToString();
                //命中概率.Text = dataGridView1.CurrentRow.Cells["命中概率"].Value.ToString();
                //发射载体.Text = dataGridView1.CurrentRow.Cells["发射载体"].Value.ToString();
                //使用条件.Text = dataGridView1.CurrentRow.Cells["使用条件"].Value.ToString();
                //生产厂家.Text = dataGridView1.CurrentRow.Cells["生产厂家"].Value.ToString();


            }
        }

    }

    public class Fruit
    {
        public Fruit(string p1, string p2, string p3, string p4, string p5, string p6, string p7, string p8)
        {
            this.P1 = p1;
            this.P2 = p2;
            this.P3 = p3;
            this.P4 = p4;
            this.P5 = p5;
            this.P6 = p6;
            this.P7 = p7;
            this.P8 = p8;
        }
        [DisplayName("导弹名称")]
        public string P1 { get; set; }

        [DisplayName("国家")]
        public string P2 { get; set; }

        [DisplayName("制导方式")]
        public string P3 { get; set; }

        [DisplayName("战斗部")]
        public string P4 { get; set; }

        [DisplayName("导引头")]
        public string P5 { get; set; }

        [DisplayName("飞行速度")]
        public string P6 { get; set; }

        [DisplayName("射程")]
        public string P7 { get; set; }

        [DisplayName("破甲厚度")]
        public string P8 { get; set; }
    }
}
