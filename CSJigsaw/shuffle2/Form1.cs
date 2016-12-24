using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shuffle2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Button[] buttons = new Button[8];
        Arrangement[] arrArray = new Arrangement[9];
        int total=0;
        private void Form1_Load(object sender, EventArgs e)
        {
            int left = 30; int top = 30;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    arrArray[total] = new Arrangement();
                    arrArray[total].left = left;
                    arrArray[total].top = top;
                    arrArray[total].location = -1;
                    if (total != 8)
                    {
                        Button btn = new Button();
                        btn.Left = left;
                        btn.Top = top;
                        btn.Width = 50;
                        btn.Height = 50;
                        btn.Text = (total + 1).ToString();
                        buttons[total] = btn;
                        arrArray[total].location = total;
                        this.Controls.Add(btn);

                    }
                    total += 1;
                    left += 50;
                }
                left = 30;
                top += 50;
            }
        }
        class Arrangement
        {
            public int left;
            public int top;
            public int location;
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 8; i++)
            {
                arrArray[i].location = -1;
            }
            for (int i = 0; i <= 7; i++)
            {
                Random rand = new Random();
                int loc=0;
                do
                {
                   loc=rand.Next(9);
                }while(arrArray[loc].location!=-1);
                buttons[i].Left = arrArray[loc].left;
                buttons[i].Top = arrArray[loc].top;
                arrArray[loc].location = i;
            }
        }
    }
}
