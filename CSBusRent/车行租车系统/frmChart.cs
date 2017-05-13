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
        private DataTable dt1;
        private DataTable dt2;
        public frmChart()
        {
            InitializeComponent();
        }

        private void GetTable()
        {
            this.dt1 = DBHelper.GetView("view_chart_cartype").Tables[0];
            this.dt2 = DBHelper.GetView("view_chart_sex").Tables[0];
        }

        private void frmChart_Load(object sender, EventArgs e)
        {
            this.GetTable();
            this.AddChart(this.panel1, this.dt1);
            this.AddChart(this.panel2, this.dt2);
            this.CalcAndShowTotal();
        }

        private void AddChart(Panel panel, DataTable dt)
        {
            string[] xval = null;
            int[] yval = null;
            var rows = dt.Rows.OfType<DataRow>();
            //加时间限制，统计当天，下同
            //.Where(x=>Convert.ToDateTime(x["st"]).Date<=DateTime.Now.Date
            //&& Convert.ToDateTime(x["et"]).Date >= DateTime.Now.Date);
            xval = rows
               .Select(r => r["x"].ToString())
               .Distinct().ToArray();
            yval = xval
                 .Select(x => rows.Count(r =>
                 x == r["x"].ToString()))
                 .ToArray();
            Chart chart = new Chart();
            panel.Controls.Add(chart);
            chart.Dock = DockStyle.Fill;
            chart.ChartAreas.Add(new ChartArea());

            chart.Series.Add(new Series("Data"));
            chart.Series["Data"].ChartType = SeriesChartType.Pie;
            chart.Series["Data"]["PieLabelStyle"] = "Outside";
            chart.Series["Data"]["PieLineColor"] = "Black";
            chart.Series["Data"].IsValueShownAsLabel = true;
            chart.Series["Data"].Label = "#VALX: #PERCENT{P1}";
            chart.Series["Data"].Points.DataBindXY(xval, yval);
        }

        private void CalcAndShowTotal()
        {
            var rows = this.dt1.Rows.OfType<DataRow>();
            int total = rows.Sum(x => Convert.ToInt32(x["t"]));
            this.lblTotal.Text = total.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
