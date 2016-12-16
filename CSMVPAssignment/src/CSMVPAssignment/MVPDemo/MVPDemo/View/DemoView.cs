using MVPDemo.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVPDemo
{
    public partial class Demoview : Form
    { 
        public DemoPresenter Presenter { get; set; }
    
        public Demoview()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.OnOperand1Change(Int32.Parse(txtOperand1.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Fehler", "Falsches Datenformat", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtOperand2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.OnOperand2Change(Int32.Parse(txtOperand2.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Fehler", "Falsches Datenformat",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            Presenter.OnAddClicked();
        }


        public void UpdateView(Int32 operand1, Int32 operand2, Int32 result)
        {
            txtOperand1.Text = operand1.ToString();
            txtOperand2.Text = operand2.ToString();

            txtResult.Text = result.ToString();
        }

    }
}
