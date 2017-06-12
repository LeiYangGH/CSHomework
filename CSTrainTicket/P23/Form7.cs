using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P23
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void SetButtonEnable()
        {
            this.btnReturn.Enabled = !string.IsNullOrWhiteSpace(this.txtT.Text);

        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.btnReturn.Enabled = false;

            if (History.Return(this.txtT.Text.Trim()))
            {
                MessageBox.Show("退票成功！");
            }
            else
                MessageBox.Show("此票不存在或尚未售出！");
        }

        private void txtT_TextChanged(object sender, EventArgs e)
        {
            this.SetButtonEnable();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
