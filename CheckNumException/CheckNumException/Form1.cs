using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CheckNumException
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                CalcTotal calcTotal = new CalcTotal();
                double total = calcTotal.GetTotal(
                    this.txtPrice.Text.Trim(),
                    this.txtQuantity.Text.Trim()
                    );
                this.lblMsg.Text = "总价= " + total.ToString();
            }
            catch (CalcTotalException ex)
            {
                this.lblMsg.Text = ex.Message;
            }
        }
    }
}
