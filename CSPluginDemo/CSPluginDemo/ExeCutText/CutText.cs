using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IPlugin;
namespace ExeCutText
{
    public partial class CutText : Form, IMenuPlugin
    {
        public CutText()
        {
            InitializeComponent();
        }

        private void CutText_Load(object sender, EventArgs e)
        {

        }

        public Dictionary<string, Action<TextBox>> GetMenus()
        {
            return new Dictionary<string, Action<TextBox>>()
            {
                {
                    "Cut", (tb)=>
                            {
                                tb.SelectedText="";
                            }
                }
            };
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.GetMenus()["Cut"].Invoke(this.textBox1);
        }
    }
}
