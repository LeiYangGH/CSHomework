using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSchenyi96225
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private int WorkDays(DateTime fromDate, DateTime toDate)
        {
            int totalDays = 0;
            for (var date = fromDate; date < toDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek != DayOfWeek.Saturday
                    && date.DayOfWeek != DayOfWeek.Sunday)
                    totalDays++;
            }
            return totalDays;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime fromDate;
            DateTime toDate;
            if (!DateTime.TryParse(this.textBox1.Text.Trim(), out fromDate))
            {
                MessageBox.Show("输入的开始日期不合法，请重新输入!");
            }
            else if (!DateTime.TryParse(this.textBox2.Text.Trim(), out toDate))
            {
                MessageBox.Show("输入的结束日期不合法，请重新输入!");
            }
            else if (fromDate >= toDate)
            {
                MessageBox.Show("输入的开始日期大于结束日期，请重新输入!");
            }
            else
            {
                int workDays = this.WorkDays(fromDate, toDate);
                this.lblMsg.Text = workDays.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = DateTime.Now.ToShortDateString();
            this.textBox2.Text = DateTime.Now.AddDays(10).ToShortDateString();
        }
    }
}
