using System.Collections.Generic;
using System.Windows.Forms;

namespace CSCalculator
{
    public partial class frmHistory : Form
    {
        public frmHistory()
        {
            InitializeComponent();
        }

        public void ShowHistory(List<string> history)
        {
            foreach (string s in history)
                this.listBox1.Items.Add(s);
        }
    }
}
