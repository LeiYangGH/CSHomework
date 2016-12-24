using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main_interface
{
    public partial class @interface : Form
    {
        public @interface()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registration_information frm2 = new Registration_information();
            frm2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sign frm2 = new sign();
            frm2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Site_information frm2 = new Site_information();
            frm2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists("site.txt"))
            {
                ResultInput frm2 = new ResultInput();
                frm2.Show();
            }
            else 
            {
                MessageBox.Show("无选手或场地信息！", "导入失败");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            score frm2 = new score();
            frm2.Show();
        }
       
    }
}
