using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace studentManage
{
    public partial class Form2 : Form
    {
        public Student stu;



        public Form2()
        {
            InitializeComponent();
            this.stu = new Student();
        }

        public Form2(Student currentStudent)
        {
            this.stu = currentStudent;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }



        private void 取消_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /*    private void 确定_Click(object sender, EventArgs e)
            {

                    StreamWriter sw = new StreamWriter(@"C:\Users\Administrator\Desktop\1.txt", true);
                    //sw.Write(textBox1.Text);
                    sw.WriteLine(textName.Text + "----" + comboSex.Text + "----" + textID.Text + "----" +
                        textMajor.Text + "----" + textGrade.Text + "----" + textIntake.Text + "----" + textBirth.Text +
                        "----" + textHostel.Text + "----" + textInterest.Text);
                    sw.Flush();
                    sw.Close();
                    this.Close();

                }

                  /*  StreamReader read = new StreamReader(@"C:\Users\Administrator\Desktop\studentManage\studentManage\listDate.txt", Encoding.Default, false);
                    //创建一个DATATABLE
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Name",typeof(String));
                    dt.Columns.Add("Sex", typeof(String));
                    dt.Columns.Add("Grade", typeof(String));
                    dt.Columns.Add("Intake", typeof(String));
                    dt.Columns.Add("Birth", typeof(String));
                    dt.Columns.Add("Interest", typeof(String));
                    dt.Columns.Add("Major", typeof(String));
                    dt.Columns.Add("Hostel", typeof(String));
                    //循环读取行数，一行一行的读

                    string line = "";
                    while ((line = read.ReadLine()) != null)
                    {
                        string[] str = read.ReadLine().Replace("----", "-").Split('-');
                        // string[] str = line.Split(' '); //使用空格分隔的内容
                        DataRow dr = dt.NewRow();
                        // 也可以这样写，但是如果文本后面有空格，会出错 dr.ItemArray =str ;
                        dr[0] = str[0];
                        dr[1] = str[1];
                        dr[2] = str[2];
                        dt.Rows.Add(dr);
                    }
                //this.dataGridView1.DataSource = dt;
                MessageBox.Show("写入成功");
                */




        /* FileStream fs = new FileStream(@"C:\Users\Administrator\Desktop\1.txt", FileMode.Create);
         StreamWriter sw = new StreamWriter(fs);
         sw.WriteLine(textName.Text+"----"+comboSex.Text+"----"+textID.Text+"----"+
             textMajor.Text+"----"+ textGrade.Text+"----"+ textIntake.Text+"----"+ textBirth.Text+
             "----"+textHostel.Text+"----"+textInterest.Text);
         sw.Close();
         fs.Close();
         this.Close();
         */
        private void 确定_Click_1(object sender, EventArgs e)
        {
            this.stu.Name = textName.Text;
            this.stu.Sex = comboSex.Text;

            this.DialogResult = DialogResult.OK;
        }



        private void 跳转_Click(object sender, EventArgs e)
        {

        }


    }


}

