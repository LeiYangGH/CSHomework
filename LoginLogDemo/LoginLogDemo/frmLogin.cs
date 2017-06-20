using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginLogDemo
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Repository.currentUserName = this.textBox1.Text.Trim();
            if (!string.IsNullOrWhiteSpace(Repository.currentUserName))
            {
                Repository.AddLogin();
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
