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

namespace ExePasteText
{
    public partial class PasteText : Form, IMenuPlugin
    {
        public PasteText()
        {
            InitializeComponent();
        }

        public Dictionary<string, Action<TextBox>> GetMenus()
        {
            return new Dictionary<string, Action<TextBox>>()
            {
                {
                    "Paste", (tb)=>
                            {
                                tb.Paste("粘贴的文本");
                            }
                }
            };
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.GetMenus()["Paste"].Invoke(this.textBox1);
        }
    }
}
