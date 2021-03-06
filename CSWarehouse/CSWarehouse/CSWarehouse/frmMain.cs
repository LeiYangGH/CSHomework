﻿using System;
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
    public partial class frmMain : Form
    {
        private BindingList<VIn> lstVIns;
        private BindingList<VOut> lstVOuts;


        public frmMain()
        {
            InitializeComponent();
            frmMaterial frm = new frmMaterial();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //e.Cancel = true;

        }

        private void ViewAll()
        {
            using (WareHouseEntities en = new WareHouseEntities())
            {
                this.lstVIns = new BindingList<VIn>(en.VIns.ToList());
                this.dgvIn.DataSource = this.lstVIns;

                this.lstVOuts = new BindingList<VOut>(en.VOuts.ToList());
                this.dgvOut.DataSource = this.lstVOuts;
            }
            this.dgvIn.Columns[0].HeaderText = "配件名称";
            this.dgvIn.Columns[1].HeaderText = "价格";
            this.dgvIn.Columns[2].HeaderText = "数量";
            this.dgvIn.Columns[3].HeaderText = "时间";
            this.dgvOut.Columns[0].HeaderText = "配件名称";
            this.dgvOut.Columns[1].HeaderText = "价格";
            this.dgvOut.Columns[2].HeaderText = "数量";
            this.dgvOut.Columns[3].HeaderText = "时间";
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.ViewAll();
        }

        private void btnAddIn_Click(object sender, EventArgs e)
        {
            frmInOut editor = new frmInOut(true);
            if (editor.ShowDialog() == DialogResult.OK)
            {
                if (DAL.AddInOut(editor.InOut))
                {
                    this.ViewAll();
                }
            }
        }

        private VIn GetFirstSelectedVIn()
        {
            var selectedRows = this.dgvIn.SelectedRows;
            if (selectedRows == null)
                return null;
            else
            {
                return selectedRows[0].DataBoundItem as VIn;
            }
        }

        private VOut GetFirstSelectedVOut()
        {
            var selectedRows = this.dgvOut.SelectedRows;
            if (selectedRows == null)
                return null;
            else
            {
                return selectedRows[0].DataBoundItem as VOut;
            }
        }




        private void Delete(DataGridView dgv)
        {

        }
        private void btnEditIn_Click(object sender, EventArgs e)
        {
            VIn vIn = this.GetFirstSelectedVIn();
            if (vIn != null)
            {
                InOut inOut = DAL.GetInOutByVIn(vIn);
                int oldId = inOut.ID;
                frmInOut editor = new frmInOut(inOut);
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    if (DAL.EditInOut(oldId, inOut))
                    {
                        this.ViewAll();
                    }
                }
            }
        }

        private void btnDelIn_Click(object sender, EventArgs e)
        {
            VIn vIn = this.GetFirstSelectedVIn();
            InOut inOut = DAL.GetInOutByVIn(vIn);

            if (vIn != null)
            {
                if (DAL.DeleteInOut(inOut))
                {
                    this.ViewAll();
                }
            }
        }

        private void btnAddOut_Click(object sender, EventArgs e)
        {
            frmInOut editor = new frmInOut(false);
            if (editor.ShowDialog() == DialogResult.OK)
            {
                if (DAL.AddInOut(editor.InOut))
                {
                    this.ViewAll();
                }
            }
        }

        private void btnEditOut_Click(object sender, EventArgs e)
        {
            VOut vOut = this.GetFirstSelectedVOut();
            if (vOut != null)
            {
                InOut inOut = DAL.GetInOutByVOut(vOut);
                int oldId = inOut.ID;
                frmInOut editor = new frmInOut(inOut);
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    if (DAL.EditInOut(oldId, inOut))
                    {
                        this.ViewAll();
                    }
                }
            }
        }

        private void btnDeleteOut_Click(object sender, EventArgs e)
        {
            VOut vOut = this.GetFirstSelectedVOut();
            InOut inOut = DAL.GetInOutByVOut(vOut);

            if (vOut != null)
            {
                if (DAL.DeleteInOut(inOut))
                {
                    this.ViewAll();
                }
            }
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuery frm = new frmQuery();
            frm.ShowDialog();
        }
    }
}
