using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 图书馆管理系统
{
    public partial class MyGuiHuan_List : Form
    {
        public MyGuiHuan_List()
        {
            InitializeComponent();
        }

        private void MyGuiHuan_List_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoGenerateColumns = false;

            GetDate();

        }
 
        public void GetDate()
        {
            string SQL = "select * from TB_JieYue where JieYueZheng='"+UserInfo.getUserName+"'";
            DataSet ds = DBHelper.GetDate(SQL);
            this.dataGridView1.DataSource = ds.Tables[0];
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
                string SQL = "Update  TB_JieYue  set State='已归还', GuiHuanTime='"+DateTime.Now.ToString()+"' where ID=" + tid;
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
