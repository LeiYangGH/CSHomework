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
        Dictionary<string, Func<double, double>> dic1 =
        new Dictionary<string, Func<double, double>>()
        {
            { "√",(a)=> Math.Sqrt(a)},
            { "+ -",(a)=> a * (-1) }
        };
        Dictionary<string, Func<double, double, double>> dic2 =
        new Dictionary<string, Func<double, double, double>>()
        {
            { "+",(a,b)=> a + b  },
            { "-",(a,b)=> a - b  },
            { "*",(a,b)=> a * b  },
            { "/",(a,b)=> a / b  },
            { "x²",(a,b)=> Math.Pow(a, b)},
        };

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
            if (txtR.Text.Length <= 28)
            {
                if (op1 == true)
                    txtR.Text = "";
                op1 = false;
                if (txtR.Text != "0")
                {
                    if (op2 == false)
                        txtR.Text += b.Text;
                    else
                    {
                        txtR.Text = b.Text;
                        op2 = false;
                    }
                }
                else
                    txtR.Text = b.Text;
            }
        }

        private void OperatorClick(object sender, EventArgs e)
        {
            Button b = sender as Button;
            op = b.Text;
            re = Convert.ToDouble(txtR.Text);
            op1 = true;
            op2 = false;
            lastOp = "";
        }

        private void FuncClick(object sender, EventArgs e)
        {
            Button b = sender as Button;
            op = b.Text;
            re = Convert.ToDouble(txtR.Text);
            op1 = true;
            result = dic1[op](re);
            txtR.Text = result.ToString();
        }


        private void btnback_Click(object sender, EventArgs e)
        {
            if (op2 == false && lastOp == "")
            {
                if (txtR.Text.Length > 0 && txtR.Text != "0")
                    txtR.Text = txtR.Text.Remove(txtR.Text.Length - 1);
                if (txtR.Text == "")
                    txtR.Text = "0";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtR.Text = "0";
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
            op2 = true;
            double doubleresult = Convert.ToDouble(txtR.Text);
            if (lastOp == "")
                num = doubleresult;
            else
                re = doubleresult;
            lastOp = op;
            result = dic2[op](re, num);
            txtR.Text = Convert.ToString(result);
            this.history.Add(txtR.Text);
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
