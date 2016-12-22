using System;
using System.Windows.Forms;

namespace MonkeyKing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int n = Convert.ToInt32(this.textBox1.Text.Trim());
                int m = Convert.ToInt32(this.textBox2.Text.Trim());
                int last = 0; // f(1) = 0
                for (int i = 2; i <= n; i++)
                {
                    last = (last + m) % i;
                    this.label5.Text += (last + 1).ToString() + ", ";
                }
                this.textBox3.Text = (last + 1).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
