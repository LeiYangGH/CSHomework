using System.Collections.Generic;
using System.Windows.Forms;

namespace StackedHeader
{
    public class Header
    {
        public List<Header> Children { get; set; }

        public string Name { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int ColumnId { get; set; }

        public Header()
        {
            Name = string.Empty;
            Children = new List<Header>();
            ColumnId = -1;
        }

        public void Measure(DataGridView dgv, int y, int h)
        {
            Width = 0;
            if (Children.Count > 0)
            {
                int tempY = string.IsNullOrEmpty(Name.Trim()) ? y : y + h;
                bool columnWidthSet = false;
                foreach (Header child in Children)
                {
                    child.Measure(dgv, tempY, h);
                    Width += child.Width;
                    if (!columnWidthSet && Width > 0)
                    {
                        ColumnId = child.ColumnId;
                        columnWidthSet = true;
                    }
                }
            }
            else if (-1 != ColumnId && dgv.Columns[ColumnId].Visible)
            {
                Width = dgv.Columns[ColumnId].Width;
            }
            Y = y;
            if (Children.Count == 0)
            {
                Height = dgv.ColumnHeadersHeight - y;
            }
            else
            {
                Height = h;
            }
        }

        public void AcceptRenderer(Decorator objRenderer)
        {
            foreach (Header objChild in Children)
            {
                objChild.AcceptRenderer(objRenderer);
            }
            if (-1 != ColumnId && !string.IsNullOrEmpty(Name.Trim()))
            {
                objRenderer.Render(this);
            }

        }
    }
}
