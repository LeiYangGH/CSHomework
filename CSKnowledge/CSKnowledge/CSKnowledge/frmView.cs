using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSKnowledge
{
    public partial class frmView : Form
    {
        public frmView()
        {
            InitializeComponent();
        }

        private void RefreshKBInCategory()
        {
            this.listBox1.Items.Clear();
            foreach (string txt in DBHelper.GetTxtUnderCategory(this.cboCategory.Text.Trim()))
            {
                this.listBox1.Items.Add(txt);
            }
        }

        private void frmView_Load(object sender, EventArgs e)
        {
            this.cboCategory.Items.Clear();
            foreach (string category in DBHelper.GetCategories())
            {
                this.cboCategory.Items.Add(category);
            }
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.RefreshKBInCategory();
        }

        private KB GetSelectedKB()
        {
            if (this.listBox1.SelectedItem == null)
                return null;
            string txt = this.listBox1.SelectedItem.ToString();
            return DBHelper.GetKBByTxt(txt);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            KB kb = this.GetSelectedKB();
            if (kb != null)
            {
                frmAdd frm = new frmAdd(kb);
                if (frm.ShowDialog() == DialogResult.OK)
                    this.RefreshKBInCategory();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            KB kb = this.GetSelectedKB();
            if (kb != null)
            {
                if (DBHelper.DeleteKBById(kb.ID))
                    this.RefreshKBInCategory();
            }
        }
    }
}
