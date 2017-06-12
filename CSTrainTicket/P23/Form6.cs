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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            this.btnBuy.Enabled = false;
            if (History.IsPassengerExist(this.txtP.Text.Trim()))
            {
                if (History.Buy(this.txtT.Text.Trim(), this.txtP.Text.Trim()))
                {
                    MessageBox.Show("售票成功！");
                }
                else
                    MessageBox.Show("此票不存在或已经售出！");
            }
            else
            {
                MessageBox.Show("此乘客不存在！");
            }


        }

        private void SetButtonEnable()
        {
            this.btnBuy.Enabled = !string.IsNullOrWhiteSpace(this.txtT.Text)
                && !string.IsNullOrWhiteSpace(this.txtP.Text);
        }

        private void txtT_TextChanged(object sender, EventArgs e)
        {
            this.SetButtonEnable();
        }

        private void txtP_TextChanged(object sender, EventArgs e)
        {
            this.SetButtonEnable();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
