using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace studentManage
{
    public partial class Form1 : Form
    {
       

      
        private studentManager manager=new studentManager();
       

        public Form1()
        {
            InitializeComponent();
           
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
             Form2 newForm = new Form2();
            newForm.Show();
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindingData();
        }
       public  void BindingData()
        {
          
            
           
           StreamReader read = new StreamReader(@"C:\Users\Administrator\Desktop\studentManage\studentManage\listDate.txt", Encoding.Default, false);
            //创建一个DATATABLE
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(String));
            dt.Columns.Add("Sex", typeof(string ));
            dt.Columns.Add("ID", typeof(String));
            dt.Columns.Add("Major", typeof(String));
            dt.Columns.Add("Grade", typeof(String));
            dt.Columns.Add("Intake", typeof(String));
            dt.Columns.Add("Birth", typeof(String));
            dt.Columns.Add("Hostel", typeof(String));
            dt.Columns.Add("Interest", typeof(String));
           
          
            //循环读取行数，一行一行的读

            string line = "";
            while ((line = read.ReadLine()) == null)
            {
                string[] str = read.ReadLine().Replace("----", "-").Split('-');
                // string[] str = line.Split(' '); //使用--分隔的内容
                DataRow dr = dt.NewRow();
                // 也可以这样写，但是如果文本后面有空格，会出错 dr.ItemArray =str ;
                dr[0] = str[0];
                dr[1] = str[1];
                dr[2] = str[2];
                dr[3] = str[3];
                dr[4] = str[4];
                dr[5] = str[5];
                dr[6] = str[6];
                dr[7] = str[7];
                dr[8] = str[8];

             
                dt.Rows.Add(dr);
            }
            this.dataGridView1.DataSource = dt;
        }
        

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

      
    }
}
