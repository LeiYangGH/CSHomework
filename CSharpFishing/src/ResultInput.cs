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
    public partial class ResultInput : Form
    {
        public ResultInput()
        {
            InitializeComponent();
        }

        private void ResultInput_Load(object sender, EventArgs e)
        {
            string pathConfigurationInfo = Application.StartupPath + @"\site.txt";
            StreamReader objReader = new StreamReader(pathConfigurationInfo, Encoding.GetEncoding("gb2312"));
            string sLine = "";
            string[] s = null;
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null && !sLine.Equals(""))
                {
                    s = sLine.Split(new char[] { '#' });
                    int n = Convert.ToInt32(s[0]);
                    int j = Convert.ToInt32(s[1]);
                    int i;
                    for (i = 1; i <= n; i++)
                    {
                        comboBox2.Items.Add(i);
                    }
                    for (i = 1; i <= j; i++)
                    {
                        comboBox3.Items.Add(i);
                    }
                    for (i = 1; i <= j; i++)
                    {
                        comboBox1.Items.Add(i);
                    }
                    for (i = 1; i <= j; i++)
                    {
                        comboBox4.Items.Add(i);
                    }
                }
            }
            objReader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确定要重新录入？", "确认", messButton);
            if (dr == DialogResult.OK)//如果点击“确定”按钮
            {
                this.listView1.Items.Clear();
                if (System.IO.File.Exists(comboBox2.Text + "#" + comboBox3.Text + ".txt"))
                {
                    string path = Application.StartupPath + "\\" + comboBox2.Text + "#" + comboBox3.Text + ".txt";
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
                            string[] subItem = { s[0], s[1], s[2], s[3], s[4], s[5], s[6], s[7], "", "", "" };
                            this.listView1.Items.Insert(itemNumber, new ListViewItem(subItem));
                            Console.WriteLine(sLine);
                        }

                    }
                    objReader.Close();
                }
                else
                {
                    MessageBox.Show("未找到选手信息，请重新确定场次及区号信息！", "操作失败");
                }
            }
            else 
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.listView1.Items.Count; i++)
            {
                if (this.listView1.Items[i].SubItems[8].Text == "" && this.listView1.Items[i].SubItems[9].Text == "" && this.listView1.Items[i].SubItems[10].Text == "")
                {
                    this.listView1.Items[i].SubItems[0].Text = this.listView1.Items[i].SubItems[0].Text;
                    this.listView1.Items[i].SubItems[1].Text = this.listView1.Items[i].SubItems[1].Text;
                    this.listView1.Items[i].SubItems[2].Text = this.listView1.Items[i].SubItems[2].Text;
                    this.listView1.Items[i].SubItems[3].Text = this.listView1.Items[i].SubItems[3].Text;
                    this.listView1.Items[i].SubItems[4].Text = this.listView1.Items[i].SubItems[4].Text;
                    this.listView1.Items[i].SubItems[5].Text = this.listView1.Items[i].SubItems[5].Text;
                    this.listView1.Items[i].SubItems[6].Text = this.listView1.Items[i].SubItems[6].Text;
                    this.listView1.Items[i].SubItems[7].Text = this.listView1.Items[i].SubItems[7].Text;
                    this.listView1.Items[i].SubItems[8].Text = this.textBox4.Text;
                    this.listView1.Items[i].SubItems[9].Text = this.textBox5.Text;
                    this.listView1.Items[i].SubItems[10].Text = this.textBox6.Text;
                    this.textBox4.Clear();
                    this.textBox5.Clear();
                    this.textBox6.Clear();
                    break;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string pathConfigurationInfo = Application.StartupPath + "\\录入成绩" + comboBox2.Text + "#" + comboBox3.Text + ".txt";
            string filePath = pathConfigurationInfo;
            string[] lines = new string[this.listView1.Items.Count];

            //FileStream fs = new FileStream(filePath, FileMode.Create);
            //StreamWriter sw = new StreamWriter(fs);
            string text = "";
            ListViewItem itemView = null;
            for (int i = 0; i < this.listView1.Items.Count; i++)
            {
                itemView = this.listView1.Items[i];
                text = itemView.SubItems[0].Text + "#" + itemView.SubItems[1].Text + "#" + itemView.SubItems[2].Text + "#" + itemView.SubItems[3].Text + "#" + itemView.SubItems[4].Text + "#" + itemView.SubItems[5].Text + "#" + itemView.SubItems[6].Text + "#" + itemView.SubItems[7].Text + "#" + itemView.SubItems[8].Text + "#" + itemView.SubItems[9].Text + "#" + itemView.SubItems[10].Text;
                lines[i] = text;
                //sw.WriteLine(text);
                //sw.Flush();
            }
            System.IO.File.WriteAllLines(filePath, lines, Encoding.GetEncoding("gb2312"));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.listView2.Items.Clear();
            if (System.IO.File.Exists("录入成绩" + comboBox1.Text + "#" + comboBox4.Text + ".txt"))
            {
                string path = Application.StartupPath + "\\录入成绩" + comboBox1.Text + "#" + comboBox4.Text + ".txt";
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
                        if (textBox1.Text.Equals(s[1]))
                        {
                            itemNumber = this.listView2.Items.Count;
                            string[] subItem = { s[0], s[1], s[2], s[3], s[4], s[5], s[6], s[7], s[8], s[9], s[10], "", "" };
                            this.listView2.Items.Insert(itemNumber, new ListViewItem(subItem));
                        }
                    }

                }
                objReader.Close();
                this.textBox1.Clear();
            }
            else
            {
                MessageBox.Show("请确认该选手成绩是否保存！", "查找失败");
            }
            
        }



        private void button7_Click(object sender, EventArgs e)
        {
            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确认已经保存并重新导入？", "确认", messButton);
            if (dr == DialogResult.OK)//如果点击“确定”按钮
            {

                if (System.IO.File.Exists("录入成绩" + comboBox2.Text + "#" + comboBox3.Text + ".txt"))
                {
                    this.listView1.Items.Clear();
                    string[] lines = new string[this.listView1.Items.Count];
                    string filePath = Application.StartupPath + "\\录入成绩" + comboBox2.Text + "#" + comboBox3.Text + ".txt";
                    StreamReader objReader = new StreamReader(filePath, Encoding.GetEncoding("gb2312"));//新建
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
                            string[] subItem = { s[0], s[1], s[2], s[3], s[4], s[5], s[6], s[7],s[8],s[9],s[10] };
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
            else
            {

            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
              MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确认修改？", "确认", messButton);
            if (dr == DialogResult.OK)//如果点击“确定”按钮
            {
                this.listView2.Items[0].SubItems[0].Text = this.listView2.Items[0].SubItems[0].Text;
                this.listView2.Items[0].SubItems[1].Text = this.listView2.Items[0].SubItems[1].Text;
                this.listView2.Items[0].SubItems[2].Text = this.listView2.Items[0].SubItems[2].Text;
                this.listView2.Items[0].SubItems[3].Text = this.listView2.Items[0].SubItems[3].Text;
                this.listView2.Items[0].SubItems[4].Text = this.listView2.Items[0].SubItems[4].Text;
                this.listView2.Items[0].SubItems[5].Text = this.listView2.Items[0].SubItems[5].Text;
                this.listView2.Items[0].SubItems[6].Text = this.listView2.Items[0].SubItems[6].Text;
                this.listView2.Items[0].SubItems[7].Text = this.listView2.Items[0].SubItems[7].Text;
                this.listView2.Items[0].SubItems[8].Text = this.textBox2.Text;
                this.listView2.Items[0].SubItems[9].Text = this.textBox3.Text;
                this.listView2.Items[0].SubItems[10].Text = this.textBox7.Text;
                this.listView2.Items[0].SubItems[11].Text = this.textBox8.Text;
                this.listView2.Items[0].SubItems[12].Text = this.textBox9.Text;


                string path = Application.StartupPath + "\\录入成绩" + comboBox1.Text + "#" + comboBox4.Text + ".txt";
                string con = "";
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("gb2312"));
                int count = File.ReadAllLines(path).Length;
                string[] lines = new string[count];
                while (con != null)
                {
                    for (int i = 0; i < count; i++)
                    {                       
                        con = sr.ReadLine();
                        if (con != null && !con.Equals(""))
                        {
                            if (con.Contains(this.listView2.Items[0].SubItems[1].Text))
                            {
                                con = con.Replace(con, this.listView2.Items[0].SubItems[0].Text + "#" + this.listView2.Items[0].SubItems[1].Text + "#" + this.listView2.Items[0].SubItems[2].Text + "#" + this.listView2.Items[0].SubItems[3].Text + "#" + this.listView2.Items[0].SubItems[4].Text + "#" + this.listView2.Items[0].SubItems[5].Text + "#" + this.listView2.Items[0].SubItems[6].Text + "#" + this.listView2.Items[0].SubItems[7].Text + "#" + this.textBox2.Text + "#" + this.textBox3.Text + "#" + this.textBox7.Text + "#" + this.textBox8.Text + "#" + this.textBox9.Text);

                            }
                            lines[i] = con;
                        }
                    }
                }
                sr.Close();
                fs.Close();
                System.IO.File.WriteAllLines(path, lines, Encoding.GetEncoding("gb2312"));
            }
            else
            {
            }
        }

        private void ResultInput_FormClosing(object sender, FormClosingEventArgs e)
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
