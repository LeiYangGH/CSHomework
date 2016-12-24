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

    public partial class Registration_information : Form
    {
        List<PlayerInfo> PlayerInfoList = new List<PlayerInfo>();

        //string pathConfigurationInfo = Application.StartupPath + "\\" + "peopleInfos" + ".txt";
        public Registration_information()
        {
            InitializeComponent();
        }
        private void Registration_information_Load(object sender, EventArgs e)
        {
            
        }
        public bool save()
        {
            //添加用户
            string team = textBox6.Text;
            string name = textBox7.Text;
            //性别
            string gender = string.Empty;
            if (radioButton4.Checked)
            {
                gender = "女";
            }
            else
            {
                gender = "男";
            }
            //联系电话
            string telephone = textBox9.Text;
            //身份证号
            string ID_number = textBox8.Text;
            //报名费
            string Registration_fee = textBox10.Text;
            if (team.Equals("") || team == null || name.Equals("") || name == null || telephone.Equals("") || telephone == null || ID_number.Equals("") || ID_number == null || Registration_fee.Equals("") || Registration_fee == null)
            {
                return false;
            }
            string filePath = Application.StartupPath + @"\text.txt";
            StreamReader objReader = new StreamReader(filePath, Encoding.GetEncoding("gb2312"));
            string sLine = "";
            string[] s = null;

            while (sLine != null)
            {
                sLine = objReader.ReadLine();

                if (sLine != null && !sLine.Equals(""))
                {
                    s = sLine.Split(new char[] { '#' });
                    if (ID_number.Equals(s[3]))
                    {
                        objReader.Close();
                        return false;
                    }
                }
            }
            objReader.Close();


            //string txt = team + "#" + name + "#" + gender + "#" + ID_number + "#" + telephone + "#" + Registration_fee ;

            //StreamWriter file = new StreamWriter(filePath, true, Encoding.GetEncoding("gb2312"));
            //file.WriteLine(txt);
            //file.Flush();
            //file.Close();

            return true;

            // File.WriteAllText(filePath, txt, Encoding.Default);
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (save())
            {
                //添加用户
                string team = textBox6.Text;
                string name = textBox7.Text;
                //性别
                string gender = string.Empty;
                if (radioButton4.Checked)
                {
                    gender = "女";
                }
                else
                {
                    gender = "男";
                }
                //联系电话
                string telephone = textBox9.Text;
                //身份证号
                string ID_number = textBox8.Text;
                //报名费
                string Registration_fee = textBox10.Text;
                int itemNumber = this.listView1.Items.Count;
                //int row = listView1.Items.Count;
                //int[] indexs = new int[row];
                //for (int i = 1; i <= row; i++)
                //{
                //    indexs[i] = i + 1;
                //} 
                string[] subItem = { name, team, gender, ID_number, telephone, Registration_fee ,"" };
                this.listView1.Items.Insert(itemNumber, new ListViewItem(subItem));
                this.listView1.Items[itemNumber].ImageIndex = 0;
                this.textBox6.Clear();
                this.textBox7.Clear();
                this.textBox8.Clear();
                this.textBox9.Clear();
                this.textBox10.Clear();

                int index = 1;
                foreach (var item in this.listView1.Items
                    .OfType<ListViewItem>())
                {
                    item.SubItems[6].Text =
                        (index++).ToString().PadLeft(3, '0');
                }
                string pathConfigurationInfo = Application.StartupPath + @"\text.txt";
                string filePath = pathConfigurationInfo;
                string[] lines = new string[this.listView1.Items.Count];
                string text = "";
                ListViewItem itemView = null;
                for (int i = 0; i < this.listView1.Items.Count; i++)
                {
                    itemView = this.listView1.Items[i];
                    text = itemView.SubItems[1].Text + "#" + itemView.SubItems[0].Text + "#" + itemView.SubItems[2].Text + "#" + itemView.SubItems[3].Text + "#" + itemView.SubItems[4].Text + "#" + itemView.SubItems[5].Text + "#" + itemView.SubItems[6].Text ;
                    lines[i] = text;
                    //sw.WriteLine(text);
                    //sw.Flush();
                }
                System.IO.File.WriteAllLines(filePath, lines, Encoding.GetEncoding("gb2312"));

            }
            else
            {
                MessageBox.Show("身份证号已经被注册！", "插入失败");
            }
            //int index = 0;
            //foreach (var item in this.listView1.Items
            //    .OfType<ListViewItem>())
            //{
            //    item.SubItems[6].Text =
            //        (index++).ToString().PadLeft(3, '0');
            //}

        }

        private void button7_Click(object sender, EventArgs e)
        {
            for (int i = this.listView1.SelectedItems.Count - 1; i >= 0; i--)
            {
                ListViewItem item =
                this.listView1.SelectedItems[i];
                this.listView1.Items.Remove(item);
            }
            int index = 1;
            foreach (var item in this.listView1.Items
                .OfType<ListViewItem>())
            {
                item.SubItems[6].Text =
                    (index++).ToString().PadLeft(3, '0');
            }
            changeFile();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dx = MessageBox.Show("确认导入覆盖？", "确认", messButton);
            if (dx == DialogResult.OK)//如果点击“确定”按钮
            {
                //this.listView1.Items.Clear();
                OpenFileDialog fd = new OpenFileDialog();
                fd.Title = "请选择文件";
                fd.Filter = "所有文件（*.*）|*.*";
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    this.listView1.Items.Clear();
                    string filepath = fd.FileName;
                    //此连接可以操作.xls与.xlsx文件 (支持Excel2013版本及以下)
                    string strCon = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + filepath + ";Extended Properties='Excel 12.0; HDR=Yes; IMEX=1'";
                    OleDbConnection myConn = new OleDbConnection(strCon);
                    string strCom = " SELECT * FROM [Sheet1$] ";
                    myConn.Open();
                    //打开数据连接，得到一个数据集
                    OleDbDataAdapter myCommand = new OleDbDataAdapter(strCom, myConn);
                    //创建一个DataSet对象
                    DataSet myDataSet = new DataSet();
                    //得到自己的DataSet对象
                    myCommand.Fill(myDataSet, "[Sheet1$]");

                    PlayerInfoList.Clear();
                    foreach (DataTable dt in myDataSet.Tables)   //遍历所有的datatable
                    {
                        foreach (DataRow dr in dt.Rows)   ///遍历所有的行
                        {
                            PlayerInfo pi = new PlayerInfo();
                            foreach (DataColumn dc in dt.Columns)   //遍历所有的列
                            {
                                if (dc.ToString() == "团队")
                                {
                                    pi.Teamname = dr[dc].ToString();
                                }
                                else if (dc.ToString() == "姓名")
                                {
                                    pi.Peoplename = dr[dc].ToString();
                                }
                                else if (dc.ToString() == "性别")
                                {
                                    pi.Sexname = dr[dc].ToString();
                                }
                                else if (dc.ToString() == "身份证")
                                {
                                    pi.Crdname = dr[dc].ToString();
                                }
                                else if (dc.ToString() == "手机号")
                                {
                                    pi.Phonename = dr[dc].ToString();
                                }
                                else if (dc.ToString() == "报名费")
                                {
                                    pi.Money = dr[dc].ToString();
                                }
                            }
                            PlayerInfoList.Add(pi);
                        }
                    }
                    // 关闭此数据链接
                    myConn.Close();
                    //在listview上显示
                    foreach (PlayerInfo pi in PlayerInfoList)
                    {
                        ListViewItem item = this.listView1.Items.Add(pi.Peoplename);
                        item.SubItems.Add(pi.Teamname);
                        item.SubItems.Add(pi.Sexname);
                        item.SubItems.Add(pi.Crdname);
                        item.SubItems.Add(pi.Phonename);
                        item.SubItems.Add(pi.Money.ToString());
                        item.SubItems.Add("");
                    }
                    int index = 1;
                    foreach (var item in this.listView1.Items
                        .OfType<ListViewItem>())
                    {
                        item.SubItems[6].Text =
                            (index++).ToString().PadLeft(3, '0');
                    }

                    changeFile();
                    //保存在txt文件中
                }
            }

            else
            {
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.listView1.Items.Count==0)
            {
                MessageBox.Show("请导入数据！", "查找失败");
            }
            else 
            { 
                    ListViewItem foundItem = this.listView1.FindItemWithText(this.textBox1.Text, false, 0);    //参数1：要查找的文本；参数2：是否子项也要查找；参数3：开始查找位置 
                    ListViewItem item = null;
                    bool test = "65123".Contains("65");
                    Console.WriteLine(test + "---------------------");
                    for (int i = 0; i < this.listView1.Items.Count; i++)
                    {
                        item = this.listView1.Items[i];
                        item.ForeColor = Color.Black;
                        if (this.textBox1.Text != "" && this.textBox1.Text != null)
                        {

                            if (item.SubItems[0].Text.Contains(this.textBox1.Text))
                            {
                                item.ForeColor = Color.Red;
                                this.listView1.TopItem = foundItem;  //定位到该项
                            }
                        }
                    }   
             }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //ListViewItem item = this.listView1.SelectedItems[0];
            //ListViewItem item = null;
            int length = this.listView1.SelectedItems.Count;
            Console.WriteLine(length);
            if (length != 1)
            {
                MessageBox.Show("请选中一条记录进行修改！", "操作失败");
            }
            else
            {
                ListViewItem lvi = this.listView1.SelectedItems[0];
                this.textBox2.Text = lvi.SubItems[1].Text;
                this.textBox3.Text = lvi.SubItems[0].Text;
                //this.textBox2.Text = item.SubItems[1].Text;
                if (lvi.SubItems[2].Text.Equals("男"))
                {
                    this.radioButton1.Checked = true;
                }
                else
                {
                    this.radioButton2.Checked = true;
                }
                this.textBox11.Text = lvi.SubItems[3].Text;
                this.textBox5.Text = lvi.SubItems[4].Text;
                this.textBox4.Text = lvi.SubItems[5].Text;
            }
        }
        public void changeFile()
        {

            string filePath = Application.StartupPath + @"\text.txt";
            string[] lines = new string[this.listView1.Items.Count];

            //FileStream fs = new FileStream(filePath, FileMode.Create);
            //StreamWriter sw = new StreamWriter(fs);
            string text = "";
            ListViewItem itemView = null;
            for (int i = 0; i < this.listView1.Items.Count; i++)
            {
                itemView = this.listView1.Items[i];
                text = itemView.SubItems[1].Text + "#" + itemView.SubItems[0].Text + "#" + itemView.SubItems[2].Text + "#" + itemView.SubItems[3].Text + "#" + itemView.SubItems[4].Text + "#" + itemView.SubItems[5].Text + "#" + itemView.SubItems[6].Text;
                lines[i] = text;
                //sw.WriteLine(text);
                //sw.Flush();
            }
            System.IO.File.WriteAllLines(filePath, lines, Encoding.GetEncoding("gb2312"));
        }
        private void button4_Click(object sender, EventArgs e)
        {
            {
                string team = this.textBox2.Text;
                string name = this.textBox3.Text;
                //性别
                string gender = string.Empty;
                if (this.radioButton1.Checked)
                {
                    gender = "男";
                }
                else
                {
                    gender = "女";
                }
                //联系电话
                string telephone = this.textBox5.Text;
                //身份证号
                string ID_number = this.textBox11.Text;
                //报名费
                string Registration_fee = this.textBox4.Text;
                //int itemNumber = this.listView1.Items.Count;
                //string[] subItem = { name, team, gender, ID_number, telephone, Registration_fee };
                ListViewItem item = null;
                for (int i = 0; i < this.listView1.Items.Count; i++)
                {
                    item = this.listView1.Items[i];
                    if (ID_number.Equals(item.SubItems[3].Text))
                    {
                        
                        item.SubItems[0].Text = name;
                        item.SubItems[1].Text = team;
                        item.SubItems[2].Text = gender;
                        item.SubItems[3].Text = ID_number;
                        item.SubItems[4].Text = telephone;
                        item.SubItems[5].Text = Registration_fee;
                        Font f = new Font(Control.DefaultFont, FontStyle.Bold);
                        item.SubItems[0].Font = f;
                        item.SubItems[1].Font = f;
                        item.SubItems[2].Font = f;
                        item.SubItems[3].Font = f;
                        item.SubItems[4].Font = f;
                        item.SubItems[5].Font = f;

                        //item.ForeColor = Color.White;
                        //item.BackColor = Color.Blue;

                        //break;
                    }

                }
                changeFile();
                //this.listView1.Items[itemNumber].ImageIndex = 0;
                this.textBox2.Clear();
                this.textBox3.Clear();
                this.textBox4.Clear();
                this.textBox5.Clear();
                this.textBox11.Clear();
                
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            int index = 0;
            foreach (var item in this.listView1.Items
                .OfType<ListViewItem>())
            {
                item.SubItems[6].Text =
                    (index++).ToString().PadLeft(3, '0');
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();
            if (System.IO.File.Exists("text.txt"))
            {
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
                        string[] subItem = { s[1], s[0], s[2], s[3], s[4], s[5], s[6] };
                        this.listView1.Items.Insert(itemNumber, new ListViewItem(subItem));
                        Console.WriteLine(sLine);
                    }

                }
                objReader.Close();
            }
            else
            {
                MessageBox.Show("无历史保存记录", "导入失败");
            }
            


        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ExportToExecl();
        }
        /// <summary>
        /// 执行导出数据
        /// </summary>
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
    }
}
