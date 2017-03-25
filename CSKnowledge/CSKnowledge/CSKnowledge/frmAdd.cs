using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSKnowledge
{
    public partial class frmAdd : Form
    {
        private KB kb;
        public string NewTxt;
        public frmAdd()
        {
            InitializeComponent();
        }

        public frmAdd(KB kb) : this()
        {
            this.kb = kb;
        }



        private bool CheckLimits()
        {
            if (string.IsNullOrWhiteSpace(this.cboCategory.Text.Trim()))
            {
                MessageBox.Show("分类不能为空！");
                return false;
            }

            if (string.IsNullOrWhiteSpace(this.textBox1.Text.Trim()))
            {
                MessageBox.Show("知识文本不能为空！");
                return false;
            }

            if (this.kb == null && string.IsNullOrWhiteSpace(this.pictureBox1.ImageLocation))
            {
                MessageBox.Show("请选择图片！");
                return false;
            }
            return true;
        }

        private Image GetImageFromBytes(byte[] bytes)
        {
            Image img;
            using (var ms = new MemoryStream(bytes))
            {
                img = Image.FromStream(ms);
            }
            return img;
        }

        private void ShowKB()
        {
            if (this.kb != null)
            {
                this.btnSave.Text = "修改";
                this.cboCategory.Text = kb.Category;
                this.cboCategory.Enabled = false;
                this.textBox1.Text = kb.Txt;
                this.pictureBox1.Image = this.GetImageFromBytes(kb.Pic);
            }
        }

        private void frmAdd_Load(object sender, EventArgs e)
        {
            this.cboCategory.Items.Clear();
            foreach (string category in DBHelper.GetCategories())
            {
                this.cboCategory.Items.Add(category);
            }
            this.ShowKB();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "图片|*.jpg;*.png;*.bmp";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fileName = dlg.FileName;
                if (new FileInfo(fileName).Length > 1024 * 1024)
                {
                    MessageBox.Show("图片不能大于1M！");
                    return;
                }
                this.pictureBox1.ImageLocation = fileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.CheckLimits())
            {
                if (this.kb == null)
                {
                    DBHelper.Add(this.cboCategory.Text.Trim(), this.textBox1.Text.Trim(), this.pictureBox1.ImageLocation);
                }
                else
                {
                    int id = kb.ID;
                    if (DBHelper.Update(id, this.cboCategory.Text.Trim(), this.textBox1.Text.Trim(), this.pictureBox1.ImageLocation))
                        this.DialogResult = DialogResult.OK;
                }
                this.Close();
            }
        }
    }
}
