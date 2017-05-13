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
    public partial class Admin_List : Form
    {
        public static bool isEditingAdminTable = true;
        public Admin_List()
        {
            InitializeComponent();
        }

        private void Admin_List_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView2.AutoGenerateColumns = false;

            GetDate();

        }

        public void GetDate()
        {
            string SQL1 = "select * from TB_Admin";
            DataSet ds1 = DBHelper.GetDate(SQL1);
            this.dataGridView1.DataSource = ds1.Tables[0];

            string SQL2 = "select * from [TB_Employee]";
            DataSet ds2 = DBHelper.GetDate(SQL2);
            this.dataGridView2.DataSource = ds2.Tables[0];
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //调用窗体
            Admin_List.isEditingAdminTable = true;

            if (this.dataGridView1.SelectedRows.Count <= 0)
            {
                return;
            }
            Admin frm = new Admin();
            frm.ID = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            frm.U = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            frm.P = this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            frm.Q = this.dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            frm.ShowDialog();
            GetDate();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {//调用窗体
            Admin_List.isEditingAdminTable = true;

            if (this.dataGridView1.SelectedRows.Count <= 0)
            {
                return;
            }

            if (MessageBox.Show("确定删除?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string tid = dataGridView1.SelectedCells[0].Value.ToString();
                string SQL = "delete from TB_Admin where ID=" + tid;
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
            Admin_List.isEditingAdminTable = true;
            Admin frm = new Admin();
            frm.ID = "";
            frm.ShowDialog();
            GetDate();
        }

        private void button4add_Click(object sender, EventArgs e)
        {
            Admin_List.isEditingAdminTable = false;
            Admin frm = new Admin();
            frm.ID = "";
            frm.ShowDialog();
            GetDate();
        }

        private void button5edit_Click(object sender, EventArgs e)
        {
            Admin_List.isEditingAdminTable = false;

            if (this.dataGridView2.SelectedRows.Count <= 0)
            {
                return;
            }
            Admin frm = new Admin();
            frm.ID = this.dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            frm.U = this.dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            frm.P = this.dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
            frm.Q = this.dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
            frm.ShowDialog();
            GetDate();
        }

        private void button6delete_Click(object sender, EventArgs e)
        {
            Admin_List.isEditingAdminTable = false;
            if (this.dataGridView1.SelectedRows.Count <= 0)
            {
                return;
            }

            if (MessageBox.Show("确定删除?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string tid = dataGridView2.SelectedCells[0].Value.ToString();
                string SQL = "delete from [TB_Employee] where ID=" + tid;
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
    }
}
