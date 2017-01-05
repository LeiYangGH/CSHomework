using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StackedHeader
{
    public class Generator
    {
        public Header GenerateStackedHeader(DataGridView dgv)
        {
            Header paHeader = new Header();
            Dictionary<string, Header> headerTree = new Dictionary<string, Header>();
            int iX = 0;
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                string[] seg = col.HeaderText.Split('.');
                if (seg.Length > 0)
                {
                    string segment = seg[0];
                    Header tmpHeader, lastTmpHeader = null;
                    if (headerTree.ContainsKey(segment))
                    {
                        tmpHeader = headerTree[segment];
                    }
                    else
                    {
                        tmpHeader = new Header { Name = segment, X = iX };
                        paHeader.Children.Add(tmpHeader);
                        headerTree[segment] = tmpHeader;
                        tmpHeader.ColumnId = col.Index;
                    }
                    for (int i = 1; i < seg.Length; ++i)
                    {
                        segment = seg[i];
                        bool found = false;
                        foreach (Header child in tmpHeader.Children)
                        {
                            if (0 == string.Compare(child.Name, segment, StringComparison.InvariantCultureIgnoreCase))
                            {
                                found = true;
                                lastTmpHeader = tmpHeader;
                                tmpHeader = child;
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
                                tmpHeader.Children.Add(temp);
                            }
                            tmpHeader = temp;
                        }
                    }
                }
                iX += col.Width;
            }
            return paHeader;
        }
    }
}
