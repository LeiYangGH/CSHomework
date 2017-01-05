using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DGVCusHeader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.dataGridView1.Columns.Add("JanWin", "Win");

            this.dataGridView1.Columns.Add("JanLoss", "Loss");

            this.dataGridView1.Columns.Add("FebWin", "Win");

            this.dataGridView1.Columns.Add("FebLoss", "Loss");

            this.dataGridView1.Columns.Add("MarWin", "Win");

            this.dataGridView1.Columns.Add("MarLoss", "Loss");



            for (int j = 0; j < this.dataGridView1.ColumnCount; j++)
            {

                this.dataGridView1.Columns[j].Width = 45;

            }

            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            this.dataGridView1.ColumnHeadersHeight = this.dataGridView1.ColumnHeadersHeight * 2;

            this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

            this.dataGridView1.Paint += new PaintEventHandler(dataGridView1_Paint);
        }

        void dataGridView1_Paint(object sender, PaintEventArgs e)
        {

            string[] monthes = { "January", "February", "March" };

            for (int j = 0; j < 6;)
            {

                Rectangle r1 = this.dataGridView1.GetCellDisplayRectangle(j, -1, true); //get the column header cell

                r1.X += 1;

                r1.Y += 1;

                r1.Width = r1.Width * 2 - 2;

                r1.Height = r1.Height / 2 - 2;

                e.Graphics.FillRectangle(new SolidBrush(this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor), r1);

                StringFormat format = new StringFormat();

                format.Alignment = StringAlignment.Center;

                format.LineAlignment = StringAlignment.Center;

                e.Graphics.DrawString(monthes[j / 2],

                    this.dataGridView1.ColumnHeadersDefaultCellStyle.Font,

                    new SolidBrush(this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor),

                    r1,

                    format);
                e.Graphics.DrawLine(new Pen(Color.DarkGray), new Point(r1.X, r1.Bottom), new Point(r1.X + r1.Width, r1.Bottom));

                j += 2;

            }

        }
    }
}
