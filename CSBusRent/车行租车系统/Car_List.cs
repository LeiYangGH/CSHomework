using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace 车行租车系统
{
    public partial class Car_List : Form
    {
        public Car_List()
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
            string SQL = "select * from TB_CheLiang";
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
            Car frm = new Car();
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
                string SQL = "delete from TB_CheLiang where ID=" + tid;
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
        { //调用窗体
            Car frm = new Car();
            frm.ID = "";
            frm.ShowDialog();
            GetDate();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            string SQL = "select * from TB_CheLiang where 1=1";
            if (!string.IsNullOrEmpty(this.textBox1.Text))
            {
                SQL = SQL + "  and ChePai='" + this.textBox1.Text + "'";
            } 
           
            if (!string.IsNullOrEmpty(this.textBox3.Text))
            {
                SQL = SQL + " and  LeiXing='" + this.textBox3.Text + "'";
            }
            DataSet ds = DBHelper.GetDate(SQL);
            this.dataGridView1.DataSource = ds.Tables[0];

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("PIC"))
            {
                string path = e.Value.ToString();
                path = Application.StartupPath + path;
                e.Value = GetImage(path);
            }

        }
        public System.Drawing.Image GetImage(string path)
        {
            System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read, FileShare.ReadWrite);
        
            System.Drawing.Image result = System.Drawing.Image.FromStream(fs);

            fs.Close();

            return result;

        } 
    }
}
