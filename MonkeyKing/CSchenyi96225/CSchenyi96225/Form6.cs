using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSchenyi96225
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float r;
            if (!float.TryParse(this.textBox1.Text.Trim(), out r) || r <= 0)
            {
                MessageBox.Show("输入的长度不合法，请重新输入!");
            }
            else
            {
                Rectangle rect = new Rectangle(r);
                double area = rect.GetS();
                double circle = rect.GetV();
                this.lblS.Text = area.ToString("f2");
                this.lblV.Text = circle.ToString("f2");
            }
        }
    }

    public class Rectangle
    {
        public Rectangle(float r)
        {
            this.R = r;
        }
        public float R { get; set; }

        public double GetS()
        {
            return 4 * Math.PI * this.R * this.R;
        }

        public double GetV()
        {
            return 4.0d / 3.0d * Math.PI * this.R * this.R * this.R;
        }
    }
}
