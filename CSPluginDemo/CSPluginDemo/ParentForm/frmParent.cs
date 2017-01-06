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

namespace ParentForm
{
    public partial class frmParent : Form
    {
        private List<Type> lstTypes;

        public frmParent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void 卸载插件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lst = this.MdiChildren.ToList();
            foreach (Form f in lst)
            {
                f.MdiParent = null;
                f.Close();
            }
            this.IsMdiContainer = false;
        }

        private List<Type> GetExeTypes()
        {
            var lst = new List<Type>();
            foreach (string fileName in Directory.GetFiles(Environment.CurrentDirectory, "*.exe"))
            {
                try
                {
                    Assembly assembly = Assembly.LoadFrom(fileName);
                    var t = assembly.GetTypes().FirstOrDefault(x => x.IsSubclassOf(typeof(Form)));
                    if (t != null && !lst.Contains(t) && t!=this.GetType())
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
            this.listBox1.Items.Clear();
            foreach (Type t in this.lstTypes)
            {
                this.listBox1.Items.Add(t.ToString());
            }
            this.listBox1.Items.AddRange(this.lstTypes.OfType<Form>().ToArray());
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sel = this.listBox1.SelectedItem as string;
            if (sel == null)
                return;
            Type t = this.lstTypes.First(x => x.ToString() == sel);
            Form instance = (Form)Activator.CreateInstance(t);
            this.IsMdiContainer = true;
            instance.MdiParent = this;
            instance.Show();
        }
    }
}
