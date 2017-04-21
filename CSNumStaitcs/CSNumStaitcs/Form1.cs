using System;
using System.IO;
using System.Windows.Forms;

namespace CSNumStaitcs
{
    public partial class Form1 : Form
    {
        NumGenerator gen;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            this.gen = new NumGenerator(new int[]
              {
                   (int) this.numericUpDown1.Value,
                   (int) this.numericUpDown2.Value,
                   (int) this.numericUpDown3.Value,
                   (int) this.numericUpDown4.Value,
                   (int) this.numericUpDown5.Value,
                   (int) this.numericUpDown6.Value,
              });
            this.txtLine4.Text = this.gen.GetTxt4Lines();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string fn = @"results.txt";
                File.AppendAllText(fn, this.gen.GetNum6String());
                File.AppendAllText(fn, Environment.NewLine);
                File.AppendAllText(fn, this.txtLine4.Text);
                File.AppendAllText(fn, Environment.NewLine);
                File.AppendAllText(fn, Environment.NewLine);
                MessageBox.Show("已保存");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
