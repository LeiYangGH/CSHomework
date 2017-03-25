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
        public frmAdd()
        {
            InitializeComponent();
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

            if (string.IsNullOrWhiteSpace(this.pictureBox1.ImageLocation))
            {
                MessageBox.Show("请选择图片！");
                return false;
            }
            return true;
        }

        private void frmAdd_Load(object sender, EventArgs e)
        {
            this.cboCategory.Items.Clear();
            foreach (string category in DBHelper.GetCategories())
            {
                this.cboCategory.Items.Add(category);
            }
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
                DBHelper.Add(this.cboCategory.Text.Trim(), this.textBox1.Text.Trim(), this.pictureBox1.ImageLocation);
        }
    }
}
