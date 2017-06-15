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
        public 路线选择()
        {
            InitializeComponent();

        }

        private void SetButtonEnable()
        {
            bool b = !string.IsNullOrWhiteSpace(this.cboR.Text.Trim())
                && !string.IsNullOrWhiteSpace(this.cboT.Text.Trim());
            this.btnAdd.Enabled = b;
        }

        private string GetActivityString(Activity x)
        {
            return string.Format("{0}{1}", x.TouristName, x.RouteDescriptions);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.btnAdd.Enabled = false;
            Activity t = new Activity(this.cboT.Text.Trim(), this.cboR.Text.Trim());
            if (Repository.dataActivity.Add(t, x => this.GetActivityString(x)))
            {
                this.AddOneToListView(t);
                //MessageBox.Show("添加成功！");
            }
            else
            {
                MessageBox.Show("不能重复添加！");
            }
        }

        public void AddAllToListView()
        {
            this.listView1.BeginUpdate();
            this.listView1.Items.Clear();
            foreach (Activity t in Repository.dataActivity.lst)
            {
                Tourist tou = Repository.GetTouristByName(t.TouristName);
                Route r = Repository.GetRouteByDesc(t.RouteDescriptions);
                ListViewItem item = new ListViewItem(tou.Name);
                item.SubItems.Add(tou.Gender);
                item.SubItems.Add(tou.Id);
                item.SubItems.Add(tou.Tel);
                item.SubItems.Add(r.Descriptions);
                item.SubItems.Add(r.Price.ToString());
                item.SubItems.Add(r.Date.ToString());
                item.Tag = t;
                this.listView1.Items.Add(item);
            }
            this.listView1.EndUpdate();
        }


        public void AddOneToListView(Activity t)
        {

            this.listView1.BeginUpdate();
            Tourist tou = Repository.GetTouristByName(t.TouristName);
            Route r = Repository.GetRouteByDesc(t.RouteDescriptions);
            ListViewItem item = new ListViewItem(tou.Name);
            item.SubItems.Add(tou.Gender);
            item.SubItems.Add(tou.Id);
            item.SubItems.Add(tou.Tel);
            item.SubItems.Add(r.Descriptions);
            item.SubItems.Add(r.Price.ToString());
            item.SubItems.Add(r.Date.ToString());
            item.Tag = t;
            this.listView1.Items.Add(item);
            this.listView1.EndUpdate();
        }

        private void FillCombo()
        {
            this.cboT.Items.Clear();
            this.cboT.Items.AddRange(Repository.dataTourist.lst.Select(x => x.Name).ToArray());
            this.cboR.Items.Clear();
            this.cboR.Items.AddRange(Repository.dataRoute.lst.Select(x => x.Descriptions).ToArray());
        }

        private void 路线选择_Load(object sender, EventArgs e)
        {
            this.FillCombo();
            this.AddAllToListView();
        }

        private void 路线选择_FormClosing(object sender, FormClosingEventArgs e)
        {
            Repository.dataActivity.SaveFile();

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
            Repository.dataActivity.lst.Remove(sel);
            this.listView1.Items.Remove(this.listView1.SelectedItems[0]);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }



        //private void HighlightItem(string name)
        //{
        //    foreach (ListViewItem it in this.listView1.Items)
        //    {
        //        Activity a = it.Tag as Activity;
        //        if (a.Name.Contains(name))
        //            it.ForeColor = Color.Blue;
        //        else
        //            it.ForeColor = Color.Black;
        //    }
        //}

        //private void txtSearch_TextChanged(object sender, EventArgs e)
        //{
        //    this.HighlightItem(this.txtSearch.Text.Trim());
        //}

        private void cboT_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetButtonEnable();

        }

        private void cboR_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetButtonEnable();

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sel = this.listView1.SelectedItems;
            this.btnDel.Enabled = !(sel == null || sel.Count == 0);
        }
    }
}
