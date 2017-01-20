using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSCalculator
{
    public partial class frmCalc : Form
    {
        public frmCalc()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public double primeironm;
        public double segundonm;
        public string operacao;
        public string lastOp;
        public double result;
        public bool temvirgula;
        public bool segundo = false;
        public bool eresultado = false;

        private void NumClick(object sender, EventArgs e)
        {
            Button b = sender as Button;
            lastOp = "";
            if (txtResult.Text.Length <= 28)
            {
                if (segundo == true) { txtResult.Text = ""; }
                segundo = false;
                if (txtResult.Text != "0")
                {
                    if (b.Text == ",")
                    {
                        if (temvirgula == false)
                        {
                            txtResult.Text = txtResult.Text + b.Text;
                            temvirgula = true;
                        }
                    }
                    else
                    {
                        if (eresultado == false)
                        {
                            txtResult.Text = txtResult.Text + b.Text;
                        }
                        else
                        {
                            txtResult.Text = b.Text;
                            eresultado = false;
                        }
                    }
                }
                else
                {
                    txtResult.Text = b.Text;
                }
            }
        }

        private void Operacao_Click(object sender, EventArgs e)
        {
            Button xXx_operacao_xXx = sender as Button;
            operacao = xXx_operacao_xXx.Text;
            Debug.Print(txtResult.Text + " | " + operacao);
            primeironm = double.Parse(txtResult.Text);
            Debug.Print(primeironm + " | " + operacao);
            temvirgula = false;
            segundo = true;
            eresultado = false;
            lastOp = "";
        }

        private void FuncClick(object sender, EventArgs e)
        {
            Button xXx_operacao_xXx = sender as Button;
            operacao = xXx_operacao_xXx.Text;
            Debug.Print(txtResult.Text + " | " + operacao);
            primeironm = double.Parse(txtResult.Text);
            Debug.Print(primeironm + " | " + operacao);
            temvirgula = false;
            segundo = true;
            switch (operacao)
            {
                case "√":
                    eresultado = true;
                    lastOp = operacao;
                    result = Math.Sqrt(primeironm);
                    txtResult.Text = Convert.ToString(result);
                    Debug.Print(primeironm + " | " + operacao + " | " + segundonm + " | " + result);
                    break;

                case "sen":
                    eresultado = true;
                    lastOp = operacao;
                    result = Math.Sin(primeironm * (Math.PI / 180.0));
                    txtResult.Text = Convert.ToString(result);
                    Debug.Print(primeironm + " | " + operacao + " | " + segundonm + " | " + result);
                    break;

                case "cos":
                    eresultado = true;
                    lastOp = operacao;
                    result = Math.Cos(primeironm * (Math.PI / 180.0));
                    txtResult.Text = Convert.ToString(result);
                    Debug.Print(primeironm + " | " + operacao + " | " + segundonm + " | " + result);
                    break;

                case "tg":
                    eresultado = true;
                    lastOp = operacao;
                    result = Math.Tan(primeironm * (Math.PI / 180.0));
                    txtResult.Text = Convert.ToString(result);
                    Debug.Print(primeironm + " | " + operacao + " | " + segundonm + " | " + result);
                    break;

                case "+ -":
                    eresultado = true;
                    lastOp = operacao;
                    result = primeironm * (-1);
                    txtResult.Text = Convert.ToString(result);
                    Debug.Print(primeironm + " | " + operacao + " | " + segundonm + " | " + result);
                    break;

                default:
                    break;
            }
        }


        private void btnback_Click(object sender, EventArgs e)
        {
            if (eresultado == false && lastOp == "")
            {
                if (txtResult.Text.Length > 0 && txtResult.Text != "0")
                {
                    txtResult.Text = txtResult.Text.Remove(txtResult.Text.Length - 1);
                }
                if (txtResult.Text == "")
                {
                    txtResult.Text = "0";
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
            lastOp = "";
            temvirgula = false;
            eresultado = false;
        }

        private void btnNegative_Click(object sender, EventArgs e)
        {
            this.Operacao_Click(sender, e);
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            this.FuncClick(sender, e);
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            this.Operacao_Click(sender, e);


        }

        private void btnSqr_Click(object sender, EventArgs e)
        {
            this.Operacao_Click(sender, e);

        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            this.Operacao_Click(sender, e);

        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.Operacao_Click(sender, e);

        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            this.Operacao_Click(sender, e);

        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            switch (operacao)
            {
                case "+":
                    eresultado = true;
                    if (lastOp == "") { segundonm = Convert.ToDouble(txtResult.Text); }
                    else { primeironm = Convert.ToDouble(txtResult.Text); }
                    lastOp = operacao;
                    result = primeironm + segundonm;
                    txtResult.Text = Convert.ToString(result);
                    Debug.Print(primeironm + " | " + operacao + " | " + segundonm + " | " + result);
                    break;

                case "-":
                    eresultado = true;
                    if (lastOp == "") { segundonm = Convert.ToDouble(txtResult.Text); }
                    else { primeironm = Convert.ToDouble(txtResult.Text); }
                    lastOp = operacao;
                    result = primeironm - segundonm;
                    txtResult.Text = Convert.ToString(result);
                    Debug.Print(primeironm + " | " + operacao + " | " + segundonm + " | " + result);
                    break;

                case "*":
                    eresultado = true;
                    if (lastOp == "") { segundonm = Convert.ToDouble(txtResult.Text); }
                    else { primeironm = Convert.ToDouble(txtResult.Text); }
                    lastOp = operacao;
                    result = primeironm * segundonm;
                    txtResult.Text = Convert.ToString(result);
                    Debug.Print(primeironm + " | " + operacao + " | " + segundonm + " | " + result);
                    break;

                case "/":
                    eresultado = true;
                    if (lastOp == "") { segundonm = Convert.ToDouble(txtResult.Text); }
                    else { primeironm = Convert.ToDouble(txtResult.Text); }
                    lastOp = operacao;
                    result = primeironm / segundonm;
                    txtResult.Text = Convert.ToString(result);
                    Debug.Print(primeironm + " | " + operacao + " | " + segundonm + " | " + result);
                    break;

                case "Resto":
                    eresultado = true;
                    if (lastOp == "") { segundonm = Convert.ToDouble(txtResult.Text); }
                    else { primeironm = Convert.ToDouble(txtResult.Text); }
                    lastOp = operacao;
                    result = primeironm % segundonm;
                    txtResult.Text = Convert.ToString(result);
                    Debug.Print(primeironm + " | " + operacao + " | " + segundonm + " | " + result);
                    break;

                case "%":
                    eresultado = true;
                    if (lastOp == "") { segundonm = Convert.ToDouble(txtResult.Text); }
                    else { primeironm = Convert.ToDouble(txtResult.Text); }
                    lastOp = operacao;
                    result = (primeironm / 100) * segundonm;
                    txtResult.Text = Convert.ToString(result);
                    Debug.Print(primeironm + " | " + operacao + " | " + segundonm + " | " + result);
                    break;

                case "x²":
                    eresultado = true;
                    if (lastOp == "") { segundonm = Convert.ToDouble(txtResult.Text); }
                    else { primeironm = Convert.ToDouble(txtResult.Text); }
                    lastOp = operacao;
                    result = Math.Pow(primeironm, segundonm);
                    txtResult.Text = Convert.ToString(result);
                    Debug.Print(primeironm + " | " + operacao + " | " + segundonm + " | " + result);
                    break;

                default:
                    break;
            }

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
    }
}
