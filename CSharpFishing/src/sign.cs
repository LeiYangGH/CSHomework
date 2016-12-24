using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace Main_interface
{
    public partial class sign : Form
    {
        public sign()
        {
            InitializeComponent();
        }

        private void sign_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.listView1.Items.Count == 0)
            {
                MessageBox.Show("请输入“首次录入”或“导入历史”！", "查找失败");
            }
            else
            {

                ListViewItem foundItem = this.listView1.FindItemWithText(this.textBox2.Text, false, 0);
                ListViewItem item = null;
                for (int i = 0; i < this.listView1.Items.Count; i++)
                {
                    item = this.listView1.Items[i];
                    item.ForeColor = Color.Black;
                    if (this.textBox2.Text != "" && this.textBox2.Text != null)
                    {

                        if (item.SubItems[0].Text.Contains(this.textBox2.Text))
                        {
                            item.ForeColor = Color.Red;
                            //this.listView1.TopItem = foundItem;  //定位到该项
                            //ListViewItem sel = this.listView1.Item[i];
                            this.listView1.Items.Remove(item);
                            this.listView1.Items.Insert(0, item);
                        }
                    }
                }
            }
            this.textBox2.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.listView1.Items.Count == 0)
            {
                MessageBox.Show("请输入“首次录入”或“导入历史”！", "查找失败");
            }
            else
            {
                ListViewItem foundItem = this.listView1.FindItemWithText(this.textBox3.Text, false, 0);
                ListViewItem item = null;
                for (int i = 0; i < this.listView1.Items.Count; i++)
                {
                    item = this.listView1.Items[i];
                    item.ForeColor = Color.Black;
                    if (this.textBox3.Text != "" && this.textBox3.Text != null)
                    {

                        if (item.SubItems[5].Text.Contains(this.textBox3.Text))
                        {
                            item.ForeColor = Color.Red;
                            //this.listView1.TopItem = foundItem;  //定位到该项
                            this.listView1.Items.Remove(item);
                            this.listView1.Items.Insert(0, item);

                        }
                    }
                }
            }
            this.textBox3.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (var item in this.listView1.Items.OfType<ListViewItem>().Where(x => x.Checked))
            {
                //自己数一下具体列
                item.SubItems[6].Text = "是";
            }
            foreach (var item in this.listView1.Items
                .OfType<ListViewItem>()
                .Where(x => x.Checked))
            {
                item.Checked = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (var item in this.listView1.Items.OfType<ListViewItem>().Where(x => x.Checked))
            {
                //自己数一下具体列
                item.SubItems[7].Text = "是";
            }
            foreach (var item in this.listView1.Items
                .OfType<ListViewItem>()
                .Where(x => x.Checked))
            {
                item.Checked = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //List<PlayerInfo> PlayerInfoList = new List<PlayerInfo>();
            string pathConfigurationInfo = Application.StartupPath + @"\sign.txt";
            string filePath = pathConfigurationInfo;
            string[] lines = new string[this.listView1.Items.Count];

            //FileStream fs = new FileStream(filePath, FileMode.Create);
            //StreamWriter sw = new StreamWriter(fs);
            string text = "";
            ListViewItem itemView = null;
            for (int i = 0; i < this.listView1.Items.Count; i++)
            {
                itemView = this.listView1.Items[i];
                text = itemView.SubItems[0].Text + "#" + itemView.SubItems[1].Text + "#" + itemView.SubItems[2].Text + "#" + itemView.SubItems[3].Text + "#" + itemView.SubItems[4].Text + "#" + itemView.SubItems[5].Text + "#" + itemView.SubItems[6].Text + "#" + itemView.SubItems[7].Text;
                lines[i] = text;
                //sw.WriteLine(text);
                //sw.Flush();
            }
            System.IO.File.WriteAllLines(filePath, lines, Encoding.GetEncoding("gb2312"));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确认首次录入？", "确认", messButton);
            if (dr == DialogResult.OK)//如果点击“确定”按钮
            {

                if (System.IO.File.Exists("text.txt"))
                {
                    this.listView1.Items.Clear();
                    string path = Application.StartupPath + @"\text.txt";
                    StreamReader objReader = new StreamReader(path, Encoding.GetEncoding("gb2312"));
                    string sLine = "";
                    string[] s = null;
                    int itemNumber = -1;

                    while (sLine != null)
                    {
                        sLine = objReader.ReadLine();
                        if (sLine != null && !sLine.Equals(""))
                        {
                            s = sLine.Split(new char[] { '#' });
                            itemNumber = this.listView1.Items.Count;
                            string[] subItem = { s[1], s[6], s[2], s[3], s[4], s[0], "", "" };
                            this.listView1.Items.Insert(itemNumber, new ListViewItem(subItem));
                            Console.WriteLine(sLine);
                        }

                    }
                    objReader.Close();
                }
                else
                {
                    MessageBox.Show("未找到报名信息！", "操作失败");
                }
            }
            else
            { 
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists("sign.txt"))
            {
                string path = Application.StartupPath + @"\sign.txt";
                StreamReader objReader = new StreamReader(path, Encoding.GetEncoding("gb2312"));
                string sLine = "";
                string[] s = null;
                int itemNumber = -1;

                while (sLine != null)
                {
                    sLine = objReader.ReadLine();
                    if (sLine != null && !sLine.Equals(""))
                    {
                        s = sLine.Split(new char[] { '#' });
                        itemNumber = this.listView1.Items.Count;
                        string[] subItem = { s[0], s[1], s[2], s[3], s[4], s[0], s[6], s[7] };
                        this.listView1.Items.Insert(itemNumber, new ListViewItem(subItem));
                        Console.WriteLine(sLine);
                    }

                }
                objReader.Close();
            }
            else 
            {
                MessageBox.Show("无历史记录！", "操作失败");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.listView1.Items.Count == 0) 
            {
                MessageBox.Show("请输入“首次录入”或“导入历史”！", "查找失败");
            }
            else
            {
                ListViewItem foundItem = this.listView1.FindItemWithText(this.textBox2.Text, false, 0);
            ListViewItem item = null;
            for (int i = 0; i < this.listView1.Items.Count; i++)
            {
                item = this.listView1.Items[i];
                item.ForeColor = Color.Black;
                if (this.textBox1.Text != "" && this.textBox1.Text != null)
                {

                    if (item.SubItems[1].Text.Equals(this.textBox1.Text))
                    {
                        item.ForeColor = Color.Red;
                        //this.listView1.TopItem = foundItem;  //定位到该项
                        //ListViewItem sel = this.listView1.Item[i];
                        this.listView1.Items.Remove(item);
                        this.listView1.Items.Insert(0, item);
                    }
                }
            }
            this.textBox1.Clear();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
             MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
             DialogResult dr = MessageBox.Show("确定取消签到？", "提示", messButton);
             if (dr == DialogResult.OK)//如果点击“确定”按钮
             {
                foreach (var item in this.listView1.Items.OfType<ListViewItem>().Where(x => x.Checked))
            {
                //自己数一下具体列
                item.SubItems[6].Text = "";
            }
            foreach (var item in this.listView1.Items
                .OfType<ListViewItem>()
                .Where(x => x.Checked))
            {
                item.Checked = false;
            }
             }
             else//如果点击“取消”按钮
             {
             }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确定取消签到？", "提示", messButton);
            if (dr == DialogResult.OK)//如果点击“确定”按钮
            {
                foreach (var item in this.listView1.Items.OfType<ListViewItem>().Where(x => x.Checked))
                {
                    //自己数一下具体列
                    item.SubItems[7].Text = "";
                }
                foreach (var item in this.listView1.Items
                    .OfType<ListViewItem>()
                    .Where(x => x.Checked))
                {
                    item.Checked = false;
                }
            }
            else//如果点击“取消”按钮
            {
            }        }

        private void button7_Click(object sender, EventArgs e)
        {
            ExportToExecl();
        }
        public void ExportToExecl()
        {
            System.Windows.Forms.SaveFileDialog sfd = new SaveFileDialog();
            //string path = Application.StartupPath + @"\例如.xls";
            //sfd.DefaultExt = path;
            sfd.Filter = "Excel文件(*.xls)|*.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                DoExport(this.listView1, sfd.FileName);
            }
        }
        /// <summary>
        /// 具体导出的方法
        /// </summary>
        /// <param name="listView">ListView</param>
        /// <param name="strFileName">导出到的文件名</param>
        private void DoExport(ListView listView, string strFileName)
        {
            int rowNum = listView.Items.Count;
            int columnNum = listView.Items[0].SubItems.Count;
            int rowIndex = 1;
            int columnIndex = 0;
            if (rowNum == 0 || string.IsNullOrEmpty(strFileName))
            {
                return;
            }
            if (rowNum > 0)
            {

                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
                if (xlApp == null)
                {
                    MessageBox.Show("无法创建excel对象，可能您的系统没有安装excel");
                    return;
                }
                xlApp.DefaultFilePath = "";
                xlApp.DisplayAlerts = true;
                xlApp.SheetsInNewWorkbook = 1;
                Microsoft.Office.Interop.Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
                //将ListView的列名导入Excel表第一行
                foreach (ColumnHeader dc in listView.Columns)
                {
                    columnIndex++;
                    xlApp.Cells[rowIndex, columnIndex] = dc.Text;
                }
                //将ListView中的数据导入Excel中
                for (int i = 0; i < rowNum; i++)
                {
                    rowIndex++;
                    columnIndex = 0;
                    for (int j = 0; j < columnNum; j++)
                    {
                        columnIndex++;
                        //注意这个在导出的时候加了“\t” 的目的就是避免导出的数据显示为科学计数法。可以放在每行的首尾。
                        xlApp.Cells[rowIndex, columnIndex] = Convert.ToString(listView.Items[i].SubItems[j].Text) + "\t";
                    }
                }
                //例外需要说明的是用strFileName,Excel.XlFileFormat.xlExcel9795保存方式时 当你的Excel版本不是95、97 而是2003、2007 时导出的时候会报一个错误：异常来自 HRESULT:0x800A03EC。 解决办法就是换成strFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal。
                xlBook.SaveAs(strFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                xlApp = null;
                xlBook = null;

            }
        }

        private void sign_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("确定已保存并退出吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                e.Cancel = false; ;
            }
            else
            {
                e.Cancel = true;
            }
        }

    }
}
