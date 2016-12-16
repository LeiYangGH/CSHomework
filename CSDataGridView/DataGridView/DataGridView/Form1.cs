using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace DataGridView
{
    public partial class Form1 : Form
    {
        private int count = 0;
        private string fileName = "data.txt";
        private List<Value4> lst = new List<Value4>();
        public Form1()
        {
            InitializeComponent();
        }

        private void InputSampleData()
        {
            string s = (++count).ToString();
            this.textBox1.Text = "t1 " + s;
            this.textBox2.Text = "t2 " + s;
            this.textBox3.Text = "t3 " + s;
            this.textBox4.Text = "t4 " + s;
        }

        private void BindAndRefresh()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = lst;
            this.dataGridView1.Update();
            this.ShowRowNumber();
            this.dataGridView1.Refresh();

        }

        private void ShowRowNumber()
        {
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                row.Cells[0].Value = (row.Index + 1).ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns[1].DataPropertyName = "V1";
            dataGridView1.Columns[2].DataPropertyName = "V2";
            dataGridView1.Columns[3].DataPropertyName = "V3";
            dataGridView1.Columns[4].DataPropertyName = "V4";
            this.ReadAll();
            this.BindAndRefresh();
        }

        private int GetFirstSelectedRowIndex()
        {
            var selRows = this.dataGridView1.SelectedRows.OfType<DataGridViewRow>();
            if (selRows == null)
                return this.dataGridView1.RowCount - 1;
            else
            {
                return selRows.First().Index;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Value4 v4 = new Value4(this.textBox1.Text, this.textBox2.Text, this.textBox3.Text, this.textBox4.Text);
            int insertAt = this.GetFirstSelectedRowIndex();
            this.lst.Insert(insertAt + 1, v4);
            this.BindAndRefresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var selRows = this.dataGridView1.SelectedRows.OfType<DataGridViewRow>();
            if (selRows == null)
                return;

            var indices = selRows.Select(x => x.Index).ToList();

            this.dataGridView1.DataSource = null;

            for (int i = indices.Count - 1; i >= 0; i--)
            {
                this.lst.RemoveAt(i);
            }
            this.dataGridView1.DataSource = lst;

        }

        private void SaveAll()
        {
            File.WriteAllLines(fileName, this.lst.Select(x => x.ToString()).ToArray(), Encoding.UTF8);
            MessageBox.Show("保存成功");
        }

        private void ReadAll()
        {
            if (File.Exists(fileName))
            {
                this.lst = File.ReadAllText(fileName, Encoding.UTF8)
                     .Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                     .Select(x => Value4.ConvertFromLine(x)).ToList();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.SaveAll();
        }

        private void button4_Click(object sender, EventArgs e)
        {
#if LYDEV
            InputSampleData();
#endif
        }
    }

    public class Value4
    {
        public Value4(string v1, string v2, string v3, string v4)
        {
            this.V1 = v1;
            this.V2 = v2;
            this.V3 = v3;
            this.V4 = v4;
        }
        public string V1 { get; set; }
        public string V2 { get; set; }
        public string V3 { get; set; }
        public string V4 { get; set; }

        public static Value4 ConvertFromLine(string line)
        {
            string[] ss = line.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
            return new Value4(ss[0], ss[1], ss[2], ss[3]);
        }

        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}",
                this.V1, this.V2, this.V3, this.V4);
        }
    }
}
