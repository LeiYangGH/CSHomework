using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace p22
{
    public partial class 界面 : Form
    {
        public 界面()
        {
            InitializeComponent();
        }

        private void 界面_Load(object sender, EventArgs e)
        {
            登录 frmSuper = new 登录();
            var result = frmSuper.ShowDialog();
            if (result != DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
