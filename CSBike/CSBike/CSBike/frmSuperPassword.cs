using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSBike
{
    public partial class frmSuperPassword : Form
    {
        private int leftTimes = 3;
        public frmSuperPassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.txtUserName.Text == "111" && this.txtPwd.Text == "111")
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.lblTimes.Text = (--this.leftTimes).ToString();
                if (this.leftTimes <= 0)
                {
                    this.lblMsg.Text = "抱歉，你被禁止登录超级管理员";
                    this.DialogResult = DialogResult.Cancel;
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmSuperPassword_Load(object sender, EventArgs e)
        {
            this.lblTimes.Text = (this.leftTimes).ToString();
        }
    }
}
