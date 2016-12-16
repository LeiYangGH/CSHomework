using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSPatient.DataSet1TableAdapters;

namespace CSPatient
{
    public partial class Form1 : Form
    {
        //这两者是负责读和存的组件
        TreatmentTableAdapter tAdapter = new TreatmentTableAdapter();
        PatientTableAdapter pAdapter = new PatientTableAdapter();

        //两个表，随着操作内容会更新
        private DataSet1.TreatmentDataTable tTable = new DataSet1.TreatmentDataTable();
        private DataSet1.PatientDataTable pTable = new DataSet1.PatientDataTable();

        //和pTable是一个对象，主要为了方便弹出对话框访问
        internal static DataSet1.PatientDataTable staticPTable;

        //选中的行的id和姓名
        private int selectedPid;
        private string selectedName;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 根据当前选择的pid，显示所有就诊历史日期
        /// </summary>
        /// <param name="pid"></param>
        private void ShowTreatHistory(int pid)
        {
            this.lstTreatDate.Items.Clear();
            foreach (var row in this.tTable.Where(x => Convert.ToInt32(x[0]) == pid))
            {
                this.lstTreatDate.Items.Add(row[1].ToString());
            }
        }

        //运行exe自动加载所有数据
        private void Form1_Load(object sender, EventArgs e)
        {
            tAdapter.Fill(tTable);
            pAdapter.Fill(this.pTable);
            staticPTable = this.pTable;
            this.dgvPatients.DataSource = pTable;
        }

        //表格选择不同的行，显示就诊日期
        private void dgvPatients_SelectionChanged(object sender, EventArgs e)
        {
            var selRows = this.dgvPatients.SelectedRows;
            string name = "";
            if (selRows != null && selRows.Count > 0)
            {
                this.selectedPid = Convert.ToInt32(selRows[0].Cells[0].Value);
                name = selRows[0].Cells[1].Value.ToString();
                this.ShowTreatHistory(this.selectedPid);
            }
            this.selectedName = name;
            this.lblName.Text = name;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmPatientEditor editor = new frmPatientEditor();
            if (editor.ShowDialog() == DialogResult.OK)
            {
                try//每个try内部的方法都是关键，保存数据的操作，下同不再赘述
                {
                    this.pTable.Rows.Add(editor.pRow);
                    this.pAdapter.Update(this.pTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                return;
            }
            var selRow = this.pTable.First(x => x[1].ToString() == this.selectedName);

            frmPatientEditor editor = new frmPatientEditor(selRow);
            if (editor.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.pAdapter.Update(selRow);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                return;
            }
            var selRow = this.pTable.First(x => x[1].ToString() == this.selectedName);

            try
            {
                selRow.Delete();
                this.pAdapter.Update(this.pTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
