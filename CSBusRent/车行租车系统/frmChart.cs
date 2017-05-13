using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace 车行租车系统
{
    public partial class frmChart : Form
    {
        private DataTable dt;
        int[] yval1 = { 5, 6, 4, 6, 3 };
        string[] xval1 = { "A", "B", "C", "D", "E" };
        public frmChart()
        {
            InitializeComponent();
        }

        private void GetTable()
        {
            string sql = @"SELECT j.[ID],[LeiXing],u.Sex,[JinE],[StartTime],[EndTime]
                          FROM [CheHang].[dbo].[TB_JieYue] j
                          left join [CheHang].[dbo].[TB_User] u
                          on u.UserName = j.UserName";
            this.dt = DBHelper.GetDate(sql).Tables[0];
        }

        private void frmChart_Load(object sender, EventArgs e)
        {
            this.GetTable();
            this.AddChartByLeiXing();
            this.AddChartByUserType();
            this.CalcAndShowTotal();
        }

        private void AddChartByLeiXing()
        {
            var rows = this.dt.Rows.OfType<DataRow>();
            //加时间限制，统计当天，下同
                //.Where(x=>Convert.ToDateTime(x[4]).Date<=DateTime.Now.Date
                //&& Convert.ToDateTime(x[5]).Date >= DateTime.Now.Date);
            this.xval1 = rows
                .Select(r => r[1].ToString())
                .Distinct().ToArray();
            this.yval1 = this.xval1
                .Select(x => rows.Count(r =>
                x == r[1].ToString()))
                .ToArray();
            Chart chart = new Chart();
            this.panel1.Controls.Add(chart);
            chart.Dock = DockStyle.Fill;
            chart.ChartAreas.Add(new ChartArea());

            chart.Series.Add(new Series("Data"));
            chart.Series["Data"].ChartType = SeriesChartType.Pie;
            chart.Series["Data"]["PieLabelStyle"] = "Outside";
            chart.Series["Data"]["PieLineColor"] = "Black";
            chart.Series["Data"].IsValueShownAsLabel = true;
            chart.Series["Data"].Label = "#VALX: #PERCENT{P1}";
            chart.Series["Data"].Points.DataBindXY(xval1, yval1);
        }

        private void AddChartByUserType()
        {
            var rows = this.dt.Rows.OfType<DataRow>();
            this.xval1 = rows
                .Select(r => r[2].ToString())
                .Distinct().ToArray();
            this.yval1 = this.xval1
                .Select(x => rows.Count(r =>
                x == r[2].ToString()))
                .ToArray();
            Chart chart = new Chart();
            this.panel2.Controls.Add(chart);
            chart.Dock = DockStyle.Fill;
            chart.ChartAreas.Add(new ChartArea());

            chart.Series.Add(new Series("Data"));
            chart.Series["Data"].ChartType = SeriesChartType.Pie;
            chart.Series["Data"]["PieLabelStyle"] = "Outside";
            chart.Series["Data"]["PieLineColor"] = "Black";
            chart.Series["Data"].IsValueShownAsLabel = true;
            chart.Series["Data"].Label = "#VALX: #PERCENT{P1}";
            chart.Series["Data"].Points.DataBindXY(xval1, yval1);
        }

        private void CalcAndShowTotal()
        {
            var rows = this.dt.Rows.OfType<DataRow>();
            int total = rows.Sum(x => Convert.ToInt32(x[3]));
            this.lblTotal.Text = total.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
