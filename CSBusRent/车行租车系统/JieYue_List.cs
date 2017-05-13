using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 车行租车系统
{
    public partial class JieYue_List : Form
    {
        public JieYue_List()
        {
            InitializeComponent();
        }

        private void JieYue_List_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoGenerateColumns = false;

            GetDate();

        }

        public void GetDate()
        {
            string SQL = "select * from TB_JieYue";
            DataSet ds = DBHelper.GetDate(SQL);
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //调用窗体
            if (this.dataGridView1.SelectedRows.Count <= 0)
            {
                return;
            }
            JieYue frm = new JieYue();
            frm.ID = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            frm.ShowDialog();
            GetDate();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {//调用窗体
            if (this.dataGridView1.SelectedRows.Count <= 0)
            {
                return;
            }

            if (MessageBox.Show("确定删除?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string tid = dataGridView1.SelectedCells[0].Value.ToString();
                string SQL = "delete from TB_JieYue where ID=" + tid;
                int B = DBHelper.Exec(SQL);
                if (B > 0)
                {
                    MessageBox.Show("操作成功"); GetDate();
                }
                else
                {
                    MessageBox.Show("操作错误，请检查数据是否合法！");
                }
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0)
            {
                return;
            }

            if (MessageBox.Show("确定归还吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string tid = dataGridView1.SelectedCells[0].Value.ToString();
                string SQL1 = "select * from TB_JieYue where ID=" + tid;
                DataSet ds = DBHelper.GetDate(SQL1);
                DateTime NW = DateTime.Now;
                DateTime JY = Convert.ToDateTime(ds.Tables[0].Rows[0]["StartTime"]);
                double ZuJin = Convert.ToDouble(ds.Tables[0].Rows[0]["ZuJIn"]);
                System.TimeSpan sp = NW - JY;
                int TS = sp.Days;
                double FeiYong = 0;

                FeiYong = TS * ZuJin;
                if (FeiYong == 0)
                    FeiYong = ZuJin;

                string SQL = "Update  TB_JieYue  set State='已归还', EndTime='" + DateTime.Now.ToString() + "' ,JinE=" + FeiYong + "  where ID=" + tid;
                int B = DBHelper.Exec(SQL);
                if (B > 0)
                {
                    MessageBox.Show("操作成功"); GetDate();
                }
                else
                {
                    MessageBox.Show("操作错误，请检查数据是否合法！");
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string SQL = "select * from TB_JieYue where 1=1";
            if (!string.IsNullOrEmpty(this.textBox1.Text))
            {
                SQL = SQL + "  and BBianHao='" + this.textBox1.Text + "'";
            }
            if (!string.IsNullOrEmpty(this.textBox2.Text))
            {
                SQL = SQL + " and  JieYueZhe='" + this.textBox2.Text + "'";
            }

            DataSet ds = DBHelper.GetDate(SQL);
            this.dataGridView1.DataSource = ds.Tables[0];

        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            frmChart frm = new frmChart();
            frm.ShowDialog();
        }
    }
}
