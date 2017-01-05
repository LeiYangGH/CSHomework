using System;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace StackedHeader
{
    public class LayeredHeaderDataGridView : DataGridView
    {
        private Graphics g;
        private Header hTree;
        private int level;
        private readonly StringFormat fmt;
        private JsonHeader jh;


        public LayeredHeaderDataGridView()
        {
            fmt = new StringFormat();
            fmt.Alignment = StringAlignment.Center;
            fmt.LineAlignment = StringAlignment.Center;
            this.DoubleBuffered = true;
            this.Scroll += dgv_Scroll;
            this.Paint += dgv_Paint;
            this.ColumnRemoved += dgv_ColumnRemoved;
            this.ColumnAdded += dgv_ColumnAdded;
            this.ColumnWidthChanged += dgv_ColumnWidthChanged;
            hTree = this.GenerateStackedHeader();
        }

        public void GenerateColumns(JsonHeader jh)
        {
            this.jh = jh;
            hTree = this.GenerateStackedHeader();
        }


        private Header GenerateStackedHeader()
        {

            Header paHeader = new Header();
            if (jh == null)
                return paHeader;
            int id = -1;
            foreach (JsonHeader j1 in jh.C)
            {
                var h1 = new Header { Name = j1.T };
                if (j1.C.Count == 0)
                    id++;
                h1.ColumnId = id;
                paHeader.Children.Add(h1);
                foreach (JsonHeader j2 in j1.C)
                {
                    var h2 = new Header { Name = j2.T };
                    h2.ColumnId = ++id;
                    h1.Children.Add(h2);
                }
                paHeader.Children.Add(h1);

            }
            //Header paHeader = new Header();
            //var h11 = new Header { Name = "11" };
            //h11.ColumnId = 0;
            //var h12 = new Header { Name = "12" };
            //h12.ColumnId = 3;
            //var h111 = new Header { Name = "111" };
            //h111.ColumnId = 2;
            //var h112 = new Header { Name = "112" };
            //h112.ColumnId = 1;
            //paHeader.Children.Add(h11);
            //h11.Children.Add(h112);
            //h11.Children.Add(h111);
            //paHeader.Children.Add(h12);
            return paHeader;
        }
        private Header GenerateStackedHeader0()
        {
            Header paHeader = new Header();
            Dictionary<string, Header> hTree = new Dictionary<string, Header>();
            int iX = 0;
            foreach (DataGridViewColumn col in this.Columns)
            {
                string[] seg = col.HeaderText.Split('.');
                if (seg.Length > 0)
                {
                    string segment = seg[0];
                    Header tmpH, lastTmpHeader = null;
                    if (hTree.ContainsKey(segment))
                    {
                        tmpH = hTree[segment];
                    }
                    else
                    {
                        tmpH = new Header { Name = segment, X = iX };
                        paHeader.Children.Add(tmpH);
                        hTree[segment] = tmpH;
                        tmpH.ColumnId = col.Index;
                    }
                    for (int i = 1; i < seg.Length; ++i)
                    {
                        segment = seg[i];
                        bool found = false;
                        foreach (Header child in tmpH.Children)
                        {
                            if (0 == string.Compare(child.Name, segment, StringComparison.InvariantCultureIgnoreCase))
                            {
                                found = true;
                                lastTmpHeader = tmpH;
                                tmpH = child;
                                break;
                            }
                        }
                        if (!found || i == seg.Length - 1)
                        {
                            Header temp = new Header { Name = segment, X = iX };
                            temp.ColumnId = col.Index;
                            if (found && i == seg.Length - 1 && null != lastTmpHeader)
                            {
                                lastTmpHeader.Children.Add(temp);
                            }
                            else
                            {
                                tmpH.Children.Add(temp);
                            }
                            tmpH = temp;
                        }
                    }
                }
                iX += col.Width;
            }
            return paHeader;
        }

        void dgv_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            this.Invalidate(this.DisplayRectangle);
        }

        void dgv_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            RegenerateHeaders();
            this.Invalidate(this.DisplayRectangle);
        }

        void dgv_ColumnRemoved(object sender, DataGridViewColumnEventArgs e)
        {
            RegenerateHeaders();
            this.Invalidate(this.DisplayRectangle);
        }

        void dgv_Paint(object sender, PaintEventArgs e)
        {
            level = NoOfLevels(hTree);
            g = e.Graphics;
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ColumnHeadersHeight = level * 20;
            if (null != hTree)
            {
                RenderColumnHeaders();
            }
        }

        void dgv_Scroll(object sender, ScrollEventArgs e)
        {
            this.Invalidate(this.DisplayRectangle);
        }

        private void RegenerateHeaders()
        {
            hTree = this.GenerateStackedHeader();
        }

        private void RenderColumnHeaders()
        {
            g.FillRectangle(new SolidBrush(this.ColumnHeadersDefaultCellStyle.BackColor),
                                      new Rectangle(this.DisplayRectangle.X, this.DisplayRectangle.Y,
                                                    this.DisplayRectangle.Width, this.ColumnHeadersHeight));
            foreach (Header child in hTree.Children)
            {
                child.Measure(this, 0, this.ColumnHeadersHeight / level);
                child.AcceptRendererDgv(this);
            }
        }

        public void Render(Header header)
        {
            if (header.Children.Count == 0)
            {
                Rectangle r1 = this.GetColumnDisplayRectangle(header.ColumnId, true);
                if (r1.Width == 0)
                {
                    return;
                }
                r1.Y = header.Y;
                r1.Width += 1;
                r1.X -= 1;
                r1.Height = header.Height;
                g.SetClip(r1);

                if (r1.X + this.Columns[header.ColumnId].Width < this.DisplayRectangle.Width)
                {
                    r1.X -= (this.Columns[header.ColumnId].Width - r1.Width);
                }
                r1.X -= 1;
                r1.Width = this.Columns[header.ColumnId].Width;
                g.DrawRectangle(Pens.Gray, r1);
                g.DrawString(header.Name,
                                       this.ColumnHeadersDefaultCellStyle.Font,
                                       new SolidBrush(this.ColumnHeadersDefaultCellStyle.ForeColor),
                                       r1,
                                       fmt);
                g.ResetClip();
            }
            else
            {
                int x = this.RowHeadersWidth;
                for (int i = 0; i < header.Children[0].ColumnId; ++i)
                {
                    if (this.Columns[i].Visible)
                    {
                        x += this.Columns[i].Width;
                    }
                }
                if (x > (this.HorizontalScrollingOffset + this.DisplayRectangle.Width - 5))
                {
                    return;
                }
                Rectangle r1 = this.GetCellDisplayRectangle(header.ColumnId, -1, true);
                r1.Y = header.Y;
                r1.Height = header.Height;
                r1.Width = header.Width + 1;
                if (r1.X < this.RowHeadersWidth)
                {
                    r1.X = this.RowHeadersWidth;
                }
                r1.X -= 1;
                g.SetClip(r1);
                r1.X = x - this.HorizontalScrollingOffset;
                r1.Width -= 1;
                g.DrawRectangle(Pens.Gray, r1);
                r1.X -= 1;
                g.DrawString(header.Name, this.ColumnHeadersDefaultCellStyle.Font,
                                       new SolidBrush(this.ColumnHeadersDefaultCellStyle.ForeColor),
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
