using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IPlugin;
namespace CSPluginDemo
{
    public partial class frmContainer : Form
    {
        private List<Type> lstTypes;
        public frmContainer()
        {
            InitializeComponent();
        }

        private void 容器菜单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("容器自带菜单而已");
        }

        private List<Type> GetExeTypes()
        {
            var lst = new List<Type>();
            foreach (string fileName in Directory.GetFiles(Environment.CurrentDirectory, "*.exe"))
            {
                try
                {
                    Assembly assembly = Assembly.LoadFrom(fileName);
                    var t = assembly.GetTypes().FirstOrDefault(x => typeof(IMenuPlugin).IsAssignableFrom(x));
                    if (t != null && !lst.Contains(t))
                        lst.Add(t);
                }
                catch (Exception)
                {
                    continue;
                }
            }
            return lst;
        }

        private void 刷新插件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.lstTypes = this.GetExeTypes();
            this.menuStrip1.Items.Clear();
            foreach (var t in this.lstTypes)
            {
                IMenuPlugin instance = (IMenuPlugin)Activator.CreateInstance(t);
                foreach (var kv in instance.GetMenus())
                {
                    ToolStripMenuItem item = new ToolStripMenuItem(kv.Key);
                    item.Click += (s, ee) =>
                      {
                          kv.Value.Invoke(this.textBox1);
                      };
                    this.menuStrip1.Items.Add(item);
                }
            }
        }
    }
}
