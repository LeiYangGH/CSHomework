using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class splbcx : Form
    {
        public splbcx()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {





        }


        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle ysplbxh = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dataGridView1.RowHeadersWidth, e.RowBounds.Height);

            // 序号

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dataGridView1.RowHeadersDefaultCellStyle.Font, ysplbxh, ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }


        private void splbcx_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“ceshiDataSet1.splb”中。您可以根据需要移动或删除它。
            this.splbTableAdapter.Fill(this.ceshiDataSet1.splb);

        }
    }
}
