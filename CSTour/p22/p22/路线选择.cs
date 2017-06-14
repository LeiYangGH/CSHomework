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
    public partial class 路线选择 : Form
    {
        private data<Activity> data;
        public 路线选择()
        {
            InitializeComponent();
            this.data = new data<Activity>("Activity",
            (x) =>
            {
                return new string[] {
                                x.Name,
                                x.Date.ToString(),
                                x.State
            };
            });
        }

        private void SetButtonEnable()
        {
            bool b = !string.IsNullOrWhiteSpace(this.txtName.Text.Trim())
                && !string.IsNullOrWhiteSpace(this.cboState.Text.Trim());
            this.btnAdd.Enabled = b;
            this.btnUpdate.Enabled = b;
        }

        private string GetActivityString(Activity x)
        {
            return string.Format("{0}{1}{2}", x.Name, x.Date, x.State);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.btnAdd.Enabled = false;
            Activity t = new Activity(this.txtName.Text.Trim(), this.dtpGo.Value, this.cboState.Text);
            if (this.data.Add(t, x => this.GetActivityString(x)))
            {
                this.data.AddOneToListView(this.listView1, t);
                //MessageBox.Show("添加成功！");
            }
            else
            {
                MessageBox.Show("不能重复添加！");
            }
        }

        private void 路线选择_Load(object sender, EventArgs e)
        {
            this.data.ReadFile();
            this.data.AddAllToListView(this.listView1);
        }

        private void 路线选择_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.data.SaveFile();

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            this.SetButtonEnable();

        }

        private void cboState_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetButtonEnable();

        }

        private Activity GetSelectedActivity()
        {
            var sel = this.listView1.SelectedItems;
            if (sel == null || sel.Count == 0)
                return null;
            return sel[0].Tag as Activity;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            Activity sel = this.GetSelectedActivity();
            if (sel == null)
                return;
            this.data.lst.Remove(sel);
            this.listView1.Items.Remove(this.listView1.SelectedItems[0]);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Activity sel = this.GetSelectedActivity();
            if (sel == null)
                return;
            this.btnAdd.Enabled = false;
            Activity t = new Activity(this.txtName.Text.Trim(), this.dtpGo.Value, this.cboState.Text);
            if (this.GetActivityString(t) == this.GetActivityString(sel))
            {
                MessageBox.Show("修改前后的值不能一样！");
                return;
            }
            sel.Name = t.Name;
            sel.Date = t.Date;
            sel.State = t.State;
            var item = this.listView1.SelectedItems[0];
            item.SubItems.Clear();
            item.Text = sel.Name;
            item.SubItems.Add(t.Date.ToString());
            item.SubItems.Add(t.State);
        }

        private void HighlightItem(string name)
        {
            foreach (ListViewItem it in this.listView1.Items)
            {
                Activity a = it.Tag as Activity;
                if (a.Name.Contains(name))
                    it.ForeColor = Color.Blue;
                else
                    it.ForeColor = Color.Black;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.HighlightItem(this.txtSearch.Text.Trim());
        }
    }
}
