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

namespace CSChartFix
{
    public partial class Form1 : Form
    {
        //下面这两句看你那里哪句能运行，改成你原来可以读取的连接字符串
        //
        //string connStr = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Student.mdb";
        string connStr = "provider=Microsoft.ACE.OLEDB.12.0;Data Source=Student.mdb";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                string sql = "Select b.姓名,s.成绩 from [学生成绩表] s  left join [基本情况] b on b.学号 = s.学号";
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
                da.Fill(dt);
                //dataGridView1.DataSource = dt;

                var lstRawRows = dt.Rows.OfType<DataRow>()
                    .Select(r => new RawRow(r[0].ToString(), Convert.ToInt32(r[1])));
                var lstStudents = lstRawRows.GroupBy(x => x.Name)
                    .Select(g => new Student(
                        g.Key,
                        g.Average(x => x.score),
                      g.Min(x => x.score))).ToList();
                dataGridView1.DataSource = lstStudents;

            }

            // get records from the table  
        }
    }

    public class RawRow
    {
        public RawRow(string n, int s)
        {
            this.Name = n;
            this.score = s;
        }
        public string Name;
        public int score;
    }

    public class Student
    {
        public Student(string n, double a, int m)
        {
            this.Name = n;
            this.Ave = a;
            this.Min = m;
        }
        public string Name { get; set; }
        public double Ave { get; set; }
        public int Min { get; set; }
    }
}
