using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class UCFoodMenu : UserControl
    {
        public UCFoodMenu()
        {
            InitializeComponent();
        }

        public UCFoodMenu(string s1, string s2, string s3) : this()
        {
            this.labname = s1;
            this.labid = s2;
            this.lablsj = s3;
        }

        public string labname
        {
            get { return mylabname.Text; }
            set { mylabname.Text = value; }
        }
        public string labid
        {
            get { return mylabid.Text; }
            set { mylabid.Text = value; }
        }
        public string lablsj
        {
            get { return mylablsj.Text; }
            set { mylablsj.Text = value; }
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            this.BackColor = Color.Blue;
        }
    }
}
