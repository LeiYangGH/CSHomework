using IPlugin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExeCountText
{
    public partial class CountText : Form, IMenuPlugin
    {
        public CountText()
        {
            InitializeComponent();
        }

        public Dictionary<string, Action<TextBox>> GetMenus()
        {

            return new Dictionary<string, Action<TextBox>>()
            {
                {
                    "Count", (tb)=>
                            {
                                MessageBox.Show( tb.Text.Length.ToString());
                            }
                }
            };

        }

        private void countToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.GetMenus()["Count"].Invoke(this.textBox1);

        }
    }
}
