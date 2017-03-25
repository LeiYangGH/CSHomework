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
            this.listBox1.Items.Clear();
            foreach (string txt in DBHelper.GetTxtUnderCategory(this.cboCategory.Text.Trim()))
            {
                this.listBox1.Items.Add(txt);
            }
        }
    }
}
