using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YYBroadcast;
namespace YYBroadCastCracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FakeFormYYBroadast frm = new FakeFormYYBroadast();
            frm.Show();
        }
    }

    #region  fake
    sealed class FakeFormYYBroadast : FormYYBroadast
    {
        private  void FormYYBroadast_Load(object sender, EventArgs e)
        {

        }
    }
    #endregion
}
