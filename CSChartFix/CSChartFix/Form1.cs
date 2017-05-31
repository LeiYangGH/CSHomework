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
using System.Windows.Forms.DataVisualization.Charting;

namespace CSChartFix
{
    public partial class Form1 : Form
    {
        //下面这两句看你那里哪句能运行，改成你原来可以读取的连接字符串
        //
        string connStr = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Student.mdb";
        //string connStr = "provider=Microsoft.ACE.OLEDB.12.0;Data Source=Student.mdb";
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

                string[] xval = null;
                double[] yval = null;
                int[] yval1 = null;

                //加时间限制，统计当天，下同
                //.Where(x=>Convert.ToDateTime(x["st"]).Date<=DateTime.Now.Date
                //&& Convert.ToDateTime(x["et"]).Date >= DateTime.Now.Date);
                xval = lstStudents
                   .Select(x => x.Name)
                   .Distinct().ToArray();
                yval = lstStudents
                     .Select(x => x.Ave)
                     .ToArray();
                yval1 = lstStudents
                     .Select(x => x.Min)
                     .ToArray();

                Chart chart = new Chart();
                panel1.Controls.Add(chart);
                chart.Dock = DockStyle.Fill;
                chart.ChartAreas.Add(new ChartArea());

                chart.Series.Add(new Series("Ave"));
                chart.Series["Ave"].ChartType = SeriesChartType.Column;
                chart.Series["Ave"]["PieLabelStyle"] = "Outside";
                chart.Series["Ave"]["PieLineColor"] = "Black";
                chart.Series["Ave"].IsValueShownAsLabel = true;
                chart.Series["Ave"].Points.DataBindXY(xval, yval);
                chart.Series["Ave"].LegendText = "平均成绩";

                chart.Series.Add(new Series("Min"));
                chart.Series["Min"].ChartType = SeriesChartType.Column;
                chart.Series["Min"]["PieLabelStyle"] = "Outside";
                chart.Series["Min"]["PieLineColor"] = "Black";
                chart.Series["Min"].IsValueShownAsLabel = true;
                chart.Series["Min"].Points.DataBindXY(xval, yval1);
                chart.Series["Min"].LegendText = "最低成绩";

                Legend leg = new Legend();

                leg.Docking = Docking.Right;
                chart.Legends.Add(leg);
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
