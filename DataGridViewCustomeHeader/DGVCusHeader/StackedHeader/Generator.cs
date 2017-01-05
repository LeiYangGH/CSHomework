using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StackedHeader
{
    public class Generator
    {
        public Header GenerateStackedHeader1(DataGridView dgv)
        {
            Header paHeader = new Header();
            paHeader.Name = "1";
            paHeader.ColumnId = 0;
            Header h11 = new Header();
            h11.Name = "11";
            h11.X = 20;
            h11.ColumnId = 1;

            Header h12 = new Header();
            h12.Name = "12";
            h12.X =30;
            h11.ColumnId = 2;

            paHeader.Children.Add(h11);
            paHeader.Children.Add(h12);
            return paHeader;
        }
        public Header GenerateStackedHeader(DataGridView dgv)
        {
            Header paHeader = new Header();
            Dictionary<string, Header> hTree = new Dictionary<string, Header>();
            int iX = 0;
            foreach (DataGridViewColumn col in dgv.Columns)
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
    }
}
