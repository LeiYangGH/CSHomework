using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace CSCalculator
{
    public partial class frmCalc : Form
    {
        private List<string> history = new List<string>();
        private double re;
        private double num;
        private string op;
        private string lastOp;
        private double result;
        private bool op1 = false;
        private bool op2 = false;
        public frmCalc()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void NumClick(object sender, EventArgs e)
        {
            Button b = sender as Button;
            lastOp = "";
            if (txtResult.Text.Length <= 28)
            {
                if (op1 == true)
                    txtResult.Text = "";
                op1 = false;
                if (txtResult.Text != "0")
                {
                    if (op2 == false)
                        txtResult.Text = txtResult.Text + b.Text;
                    else
                    {
                        txtResult.Text = b.Text;
                        op2 = false;
                    }
                }
                else
                    txtResult.Text = b.Text;
            }
        }

        private void OperatorClick(object sender, EventArgs e)
        {
            Button b = sender as Button;
            op = b.Text;
            re = Convert.ToDouble(txtResult.Text);
            op1 = true;
            op2 = false;
            lastOp = "";
        }

        private void FuncClick(object sender, EventArgs e)
        {
            Button b = sender as Button;
            op = b.Text;
            re = Convert.ToDouble(txtResult.Text);
            op1 = true;
            switch (op)
            {
                case "√":
                    op2 = true;
                    lastOp = op;
                    result = Math.Sqrt(re);
                    txtResult.Text = Convert.ToString(result);
                    break;
                case "+ -":
                    op2 = true;
                    lastOp = op;
                    result = re * (-1);
                    txtResult.Text = Convert.ToString(result);
                    break;
                default:
                    break;
            }
        }


        private void btnback_Click(object sender, EventArgs e)
        {
            if (op2 == false && lastOp == "")
            {
                if (txtResult.Text.Length > 0 && txtResult.Text != "0")
                    txtResult.Text = txtResult.Text.Remove(txtResult.Text.Length - 1);
                if (txtResult.Text == "")
                    txtResult.Text = "0";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
            lastOp = "";
            op2 = false;
        }

        private void btnNegative_Click(object sender, EventArgs e)
        {
            this.FuncClick(sender, e);
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            this.FuncClick(sender, e);
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            this.OperatorClick(sender, e);
        }

        private void btnSqr_Click(object sender, EventArgs e)
        {
            this.OperatorClick(sender, e);
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            this.OperatorClick(sender, e);
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.OperatorClick(sender, e);
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            this.OperatorClick(sender, e);
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            switch (op)
            {
                case "+":
                    op2 = true;
                    if (lastOp == "")
                        num = Convert.ToDouble(txtResult.Text);
                    else
                        re = Convert.ToDouble(txtResult.Text);
                    lastOp = op;
                    result = re + num;
                    txtResult.Text = Convert.ToString(result);
                    break;

                case "-":
                    op2 = true;
                    if (lastOp == "")
                        num = Convert.ToDouble(txtResult.Text);
                    else
                        re = Convert.ToDouble(txtResult.Text);
                    lastOp = op;
                    result = re - num;
                    txtResult.Text = Convert.ToString(result);
                    break;
                case "*":
                    op2 = true;
                    if (lastOp == "")
                        num = Convert.ToDouble(txtResult.Text);
                    else
                        re = Convert.ToDouble(txtResult.Text);
                    lastOp = op;
                    result = re * num;
                    txtResult.Text = Convert.ToString(result);
                    break;
                case "/":
                    op2 = true;
                    if (lastOp == "")
                        num = Convert.ToDouble(txtResult.Text);
                    else
                        re = Convert.ToDouble(txtResult.Text);
                    lastOp = op;
                    result = re / num;
                    txtResult.Text = Convert.ToString(result);
                    break;
                case "x²":
                    op2 = true;
                    if (lastOp == "")
                        num = Convert.ToDouble(txtResult.Text);
                    else
                        re = Convert.ToDouble(txtResult.Text);
                    lastOp = op;
                    result = Math.Pow(re, num);
                    txtResult.Text = Convert.ToString(result);
                    break;
                default:
                    break;
            }
            this.history.Add(txtResult.Text);
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            this.NumClick(sender, e);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            this.NumClick(sender, e);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            this.NumClick(sender, e);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            this.NumClick(sender, e);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            this.NumClick(sender, e);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            this.NumClick(sender, e);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            this.NumClick(sender, e);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            this.NumClick(sender, e);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            this.NumClick(sender, e);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            this.NumClick(sender, e);
        }

        private void btnRem_Click(object sender, EventArgs e)
        {
            frmHistory frmH = new frmHistory();
            frmH.Show();
            frmH.ShowHistory(this.history);
        }
    }
}
