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
    public partial class LeiXing_List : Form
    {
        public LeiXing_List()
        {
            InitializeComponent();
        }

        private void LeiXing_List_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoGenerateColumns = false;

            GetDate();

        }
        private void button3_Click(object sender, EventArgs e)
        { //调用窗体
            if (this.dataGridView1.SelectedRows.Count <= 0)
            {
                return;
            }

            if (MessageBox.Show("确定删除?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string tid = dataGridView1.SelectedCells[0].Value.ToString();
                string SQL = "delete from TB_LeiXing where ID=" + tid;
                int B = DBHelper.Exec(SQL);
                if (B>0)
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
            //调用窗体
            if (this.dataGridView1.SelectedRows.Count <= 0)
            {
                return;
            }
            LeiXing frm = new LeiXing();
            frm.ID = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            frm.ShowDialog();
            GetDate();
        }

        private void button1_Click(object sender, EventArgs e)
        {  //调用窗体
            LeiXing frm = new LeiXing();
            frm.ID = "";
            frm.ShowDialog();
            GetDate();

        }
        public void GetDate()
        {
            string SQL = "select * from TB_LeiXing";
            DataSet ds = DBHelper.GetDate(SQL);
            this.dataGridView1.DataSource = ds.Tables[0];
        }
 
    }
}
