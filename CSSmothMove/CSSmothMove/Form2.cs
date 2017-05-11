using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MrSmarty.CodeProject
{
    public partial class Form2 : Form
    {
        FloatingOSDWindow osd = new FloatingOSDWindow();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        int x = 10;
        private void timer1_Tick(object sender, EventArgs e)
        {
            x += 1;
            this.osd.Show(new Point(x, 1), 90,
                Color.Green,
                new Font("Microsoft Sans Serif", 72f, FontStyle.Regular),
                1800,
                //FloatingWindow.AnimateMode.Blend,
                //FloatingWindow.AnimateMode.RollTopToBottom,
                FloatingWindow.AnimateMode.SlideRightToLeft,
                0, "hello world!");
        }
    }
}
