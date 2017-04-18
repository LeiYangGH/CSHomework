using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSWarehouse
{
    public partial class frmMaterial : Form
    {
        private bool isUserGo;
        public frmMaterial()
        {
            InitializeComponent();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            string txt = this.txtName.Text.Trim();
            this.btnAdd.Enabled = txt.Length > 0 && !this.listBox1.Items.Contains(txt);
        }

        private void frmMaterial_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isUserGo)
            {
                MessageBox.Show("请点击按钮跳转，一旦进入，将无法再编辑配件！");
                e.Cancel = true;
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            this.isUserGo = true;
            this.DialogResult = DialogResult.OK;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            object o = this.listBox1.SelectedItem;
            if (o == null)
            {
                this.btnDelete.Enabled = false;
            }
            else
            {
                this.btnDelete.Enabled = true;
            }
        }

        private void DisplayAllMaterials()
        {
            using (WareHouseEntities en = new WareHouseEntities())
            {
                this.listBox1.Items.Clear();
                foreach (Material m in en.Materials)
                {
                    this.listBox1.Items.Add(m.Name);
                }
            }
        }

        private void frmMaterial_Load(object sender, EventArgs e)
        {
            this.DisplayAllMaterials();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnAdd.Enabled = false;
                using (WareHouseEntities en = new WareHouseEntities())
                {
                    Material m = new Material();
                    m.Name = this.txtName.Text.Trim();
                    m.Price = this.numPrice.Value;
                    en.Materials.Add(m);
                    en.SaveChanges();
                }
                this.DisplayAllMaterials();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string name = this.listBox1.SelectedItem.ToString();
            try
            {
                this.btnDelete.Enabled = false;
                using (WareHouseEntities en = new WareHouseEntities())
                {
                    Material m = en.Materials.First(x => x.Name == name);
                    int id = m.ID;
                    foreach (InOut io in en.InOuts
                        .Where(x => x.MID == id))
                        en.InOuts.Remove(io);
                    en.SaveChanges();

                    en.Materials.Remove(m);
                    en.SaveChanges();

                }
                this.DisplayAllMaterials();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
