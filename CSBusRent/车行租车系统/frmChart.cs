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
        int[] yval = { 5, 6, 4, 6, 3 };
        string[] xval = { "A", "B", "C", "D", "E" };
        public frmChart()
        {
            InitializeComponent();
        }

        private void GetTable()
        {
            string sql = @"SELECT j. [ID],[LeiXing],u.Sex,[StartTime],[EndTime]
                          FROM [CheHang].[dbo].[TB_JieYue] j
                          left join [CheHang].[dbo].[TB_User] u
                          on u.UserName = j.UserName";
            this.dt = DBHelper.GetDate(sql).Tables[0];
        }

        private void frmChart_Load(object sender, EventArgs e)
        {
            this.GetTable();
            var rows = this.dt.Rows.OfType<DataRow>();
            this.xval = rows
                .Select(r => r[1].ToString())
                .Distinct().ToArray();
            this.yval = this.xval.Select(x => rows.Count(r => x == r[1].ToString())).ToArray();
        }

        private void button2_Click(object sender, EventArgs e)
        {
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
            chart.Series["Data"].Points.DataBindXY(xval, yval);
        }
    }
}
