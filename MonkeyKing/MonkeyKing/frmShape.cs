using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonkeyKing
{
    public partial class frmShape : Form
    {
        public frmShape()
        {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            float w;
            float l;
            if (!float.TryParse(this.textBox1.Text.Trim(), out l) || l <= 0)
            {
                MessageBox.Show("输入的长度不合法，请重新输入!");
            }
            else if (!float.TryParse(this.textBox2.Text.Trim(), out w) || w <= 0)
            {
                MessageBox.Show("输入的宽度不合法，请重新输入!");
            }
            else
            {
                Rectangle rect = new Rectangle(l, w);
                float area = rect.GetArea();
                float circle = rect.GetCircle();
                this.lblArea.Text = area.ToString();
                this.lblCircle.Text = circle.ToString();
            }
        }
    }

    public class Rectangle
    {
        public Rectangle(float l, float w)
        {
            this.Length = l;
            this.Width = w;
        }
        public float Length { get; set; }
        public float Width { get; set; }

        public float GetArea()
        {
            return this.Length * this.Width;
        }

        public float GetCircle()
        {
            return 2 * (this.Length + this.Width);
        }
    }
}
