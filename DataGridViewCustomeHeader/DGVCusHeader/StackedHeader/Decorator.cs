using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace StackedHeader
{
    public class Decorator
    {
        private readonly Generator gen = new Generator();
        private Graphics g;
        private readonly DataGridView dgv;
        private Header hTree;
        private int level;
        private readonly StringFormat fmt;

        public Decorator(DataGridView dgv)
        {
            this.dgv = dgv;
            fmt = new StringFormat();
            fmt.Alignment = StringAlignment.Center;
            fmt.LineAlignment = StringAlignment.Center;

            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, true, null);

            dgv.Scroll += (objDataGrid_Scroll);
            dgv.Paint += objDataGrid_Paint;
            dgv.ColumnRemoved += objDataGrid_ColumnRemoved;
            dgv.ColumnAdded += objDataGrid_ColumnAdded;
            dgv.ColumnWidthChanged += objDataGrid_ColumnWidthChanged;
            hTree = gen.GenerateStackedHeader(dgv);
        }

        public Decorator(Generator gen, DataGridView dgv)
            : this(dgv)
        {
            this.gen = gen;
        }

        void objDataGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            Refresh();
        }

        void objDataGrid_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            RegenerateHeaders();
            Refresh();
        }

        void objDataGrid_ColumnRemoved(object sender, DataGridViewColumnEventArgs e)
        {
            RegenerateHeaders();
            Refresh();
        }

        void objDataGrid_Paint(object sender, PaintEventArgs e)
        {
            level = NoOfLevels(hTree);
            g = e.Graphics;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = level * 20;
            if (null != hTree)
            {
                RenderColumnHeaders();
            }
        }

        void objDataGrid_Scroll(object sender, ScrollEventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            Rectangle rtHeader = dgv.DisplayRectangle;
            dgv.Invalidate(rtHeader);
        }

        private void RegenerateHeaders()
        {
            hTree = gen.GenerateStackedHeader(dgv);
        }

        private void RenderColumnHeaders()
        {
            g.FillRectangle(new SolidBrush(dgv.ColumnHeadersDefaultCellStyle.BackColor),
                                      new Rectangle(dgv.DisplayRectangle.X, dgv.DisplayRectangle.Y,
                                                    dgv.DisplayRectangle.Width, dgv.ColumnHeadersHeight));

            foreach (Header objChild in hTree.Children)
            {
                objChild.Measure(dgv, 0, dgv.ColumnHeadersHeight / level);
                objChild.AcceptRenderer(this);
            }
        }

        public void Render(Header objHeader)
        {
            if (objHeader.Children.Count == 0)
            {
                Rectangle r1 = dgv.GetColumnDisplayRectangle(objHeader.ColumnId, true);
                if (r1.Width == 0)
                {
                    return;
                }
                r1.Y = objHeader.Y;
                r1.Width += 1;
                r1.X -= 1;
                r1.Height = objHeader.Height;
                g.SetClip(r1);

                if (r1.X + dgv.Columns[objHeader.ColumnId].Width < dgv.DisplayRectangle.Width)
                {
                    r1.X -= (dgv.Columns[objHeader.ColumnId].Width - r1.Width);
                }
                r1.X -= 1;
                r1.Width = dgv.Columns[objHeader.ColumnId].Width;
                g.DrawRectangle(Pens.Gray, r1);
                g.DrawString(objHeader.Name,
                                       dgv.ColumnHeadersDefaultCellStyle.Font,
                                       new SolidBrush(dgv.ColumnHeadersDefaultCellStyle.ForeColor),
                                       r1,
                                       fmt);
                g.ResetClip();
            }
            else
            {
                int x = dgv.RowHeadersWidth;
                for (int i = 0; i < objHeader.Children[0].ColumnId; ++i)
                {
                    if (dgv.Columns[i].Visible)
                    {
                        x += dgv.Columns[i].Width;
                    }
                }
                if (x > (dgv.HorizontalScrollingOffset + dgv.DisplayRectangle.Width - 5))
                {
                    return;
                }
                Rectangle r1 = dgv.GetCellDisplayRectangle(objHeader.ColumnId, -1, true);
                r1.Y = objHeader.Y;
                r1.Height = objHeader.Height;
                r1.Width = objHeader.Width + 1;
                if (r1.X < dgv.RowHeadersWidth)
                {
                    r1.X = dgv.RowHeadersWidth;
                }
                r1.X -= 1;
                g.SetClip(r1);
                r1.X = x - dgv.HorizontalScrollingOffset;
                r1.Width -= 1;
                g.DrawRectangle(Pens.Gray, r1);
                r1.X -= 1;
                g.DrawString(objHeader.Name, dgv.ColumnHeadersDefaultCellStyle.Font,
                                       new SolidBrush(dgv.ColumnHeadersDefaultCellStyle.ForeColor),
                                       r1, fmt);
                g.ResetClip();
            }
        }

        private int NoOfLevels(Header header)
        {
            int level = 0;
            foreach (Header child in header.Children)
            {
                int temp = NoOfLevels(child);
                level = temp > level ? temp : level;
            }
            return level + 1;
        }
    }
}
