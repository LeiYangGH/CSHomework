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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {

            DataGridViewCell hc = this.dataGridView1.Columns[3].HeaderCell;
            Rectangle hcRct = this.dataGridView1.GetCellDisplayRectangle(hc.ColumnIndex, -1, true);

            int multiHeaderWidth = this.dataGridView1.Columns[hc.ColumnIndex].Width + this.dataGridView1.Columns[hc.ColumnIndex + 1].Width + this.dataGridView1.Columns[hc.ColumnIndex + 2].Width + this.dataGridView1.Columns[hc.ColumnIndex + 3].Width;
            Rectangle headRct = new Rectangle(hcRct.Left, hc.ContentBounds.Y + 2, multiHeaderWidth, this.dataGridView1.ColumnHeadersHeight);
            headRct.Height -= 3;

            SizeF sz = e.Graphics.MeasureString("My Big Header", this.dataGridView1.Font);
            int headerTop = Convert.ToInt32((headRct.Height / 2) - (sz.Height / 2)) + 2;
            e.Graphics.FillRectangle(new SolidBrush(SystemColors.Control), headRct);
            e.Graphics.DrawString("My Big Header", this.dataGridView1.ColumnHeadersDefaultCellStyle.Font, Brushes.Black, hcRct.Left + 2, headerTop);
        }
    }
}
