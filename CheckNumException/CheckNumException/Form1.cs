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

    public class CalcTotalException : Exception
    {
        public CalcTotalException()
        {

        }

        public CalcTotalException(string message) : base(message)
        {

        }

        public CalcTotalException(string message, Exception innerException) : base(message, innerException)
        {

        }

        public override string Message //Message属性的重载
        {
            get
            {
                return "警告！" + base.Message;
            }
        }
    }

    public class CalcTotal
    {
        //计算总价
        public double GetTotal(string strPrice, string strQuantity)
        {
            double price;
            double quatity;
            //如果转换为double成功
            if (double.TryParse(strPrice, out price)
                && double.TryParse(strQuantity, out quatity))
            {
                //如果是正数
                if (price > 0 && quatity > 0)
                    return price * quatity;
                else
                    throw new CalcTotalException("单价或数量不能为负数！");
            }
            else
            {
                throw new CalcTotalException("单价或数量必须为数字！");
            }

        }


    }
}
