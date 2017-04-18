using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;


namespace CSWarehouse
{
    public partial class frmQuery : Form
    {
        public frmQuery()
        {
            InitializeComponent();
        }

        private List<Result> SearchResults(string op, string name, DateTime sdate, DateTime edate)
        {
            try
            {
                using (WareHouseEntities en = new WareHouseEntities())
                {
                    var lstInOut = en.InOuts.Include(p => p.Material)
                        .Where(x => x.Material.Name.Contains(name))
                        .Where(x => x.Date >= sdate && x.Date <= edate);
                    if (op == "入库")
                    {
                        lstInOut = lstInOut.Where(x => x.IsIn);
                    }
                    else
                    {
                        lstInOut = lstInOut.Where(x => !x.IsIn);
                    }
                    return lstInOut.Select(x => new Result()
                    {
                        Type = op,
                        Name = x.Material.Name,
                        Price = x.Material.Price,
                        Quantity = x.Quantity,
                        Date = x.Date
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<Result>();
            }
        }
        private void SearchAndDisplay()
        {
            var lstR = this.SearchResults(this.cboType.Text, this.txtName.Text.Trim(), this.dtpStart.Value, this.dtpEnd.Value);
            this.dataGridView1.DataSource = new BindingList<Result>(lstR);
            this.dataGridView1.Columns[0].HeaderText = "操作类别";
            this.dataGridView1.Columns[1].HeaderText = "配件名称";
            this.dataGridView1.Columns[2].HeaderText = "价格";
            this.dataGridView1.Columns[3].HeaderText = "数量";
            this.dataGridView1.Columns[4].HeaderText = "时间";

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.SearchAndDisplay();
        }
    }


}
