using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSExam
{
    public partial class frmExam : Form
    {
        public int score;
        public int time = 60 * 3;
        public frmExam()
        {
            InitializeComponent();
        }

        private void Submit()
        {
            this.score = new Random().Next(80, 100);
            MessageBox.Show("考试结束");
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Submit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lblLeftSec.Text = this.time.ToString();
            if (this.time-- <= 0)
            {
                this.timer1.Enabled = false;
                this.Submit();
            }
        }

        private void frmExam_Load(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
        }
    }
}
