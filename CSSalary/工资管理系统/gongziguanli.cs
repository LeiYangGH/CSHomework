using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;


namespace 工资管理系统
{
    public partial class gongziguanli : Form
    {
        public gongziguanli()
        {
            InitializeComponent();
        }

        private void gongziguanli_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“biyeshejiDataSet.gongzibiaoALL”中。您可以根据需要移动或删除它。
            this.gongzibiaoALLTableAdapter.Fill(this.biyeshejiDataSet.gongzibiaoALL);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           


  
              
            
        }

       
    }
}
