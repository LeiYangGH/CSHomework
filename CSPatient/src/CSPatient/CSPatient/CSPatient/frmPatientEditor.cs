using System;
using System.Linq;
using System.Windows.Forms;

namespace CSPatient
{
    public partial class frmPatientEditor : Form
    {
        public DataSet1.PatientRow pRow;//增加或编辑的病人
        private bool isAdding;//在增加，而不是在编辑，如果false就是在编辑
        private string name;//病人姓名
        public frmPatientEditor()//增加时候调用
        {
            InitializeComponent();
            this.pRow = Form1.staticPTable.NewPatientRow();
            this.isAdding = true;
        }
        //编辑时候调用，所以要传一个病人信息进来
        public frmPatientEditor(DataSet1.PatientRow pRow) : this()
        {
            this.pRow = pRow;
            this.isAdding = false;
            this.ShowPatientInfo();
        }

        //编辑时候，打开界面显示病人信息
        private void ShowPatientInfo()
        {
            this.name= this.pRow.NAME;
            this.txtName.Text = this.pRow.NAME;
            this.txtAddress.Text = this.pRow.Address;
            this.cboGender.Text = this.pRow.Gender;
            this.txtTel.Text = this.pRow.Tel;
        }

        //增加的时候病人姓名是否已经存在
        //其实编辑的时候也应该有类似验证，懒得写了
        private bool IsPatientConstraintCollision()
        {
            if (this.isAdding)
            {
                if (Form1.staticPTable.Any(x => x[1].ToString().Contains(this.txtName.Text.Trim())))
                    return true;
            }
            return false;
        }

        //把界面的数据保存在病人对象里
        private void SetValuesForRow()
        {
            this.pRow.Pid = Form1.staticPTable.Max(x => Convert.ToInt32(x[0])) + 1;

            this.name = this.txtName.Text.Trim();
            this.pRow.NAME = this.name;
            this.pRow.Gender = this.cboGender.Text.Trim();
            this.pRow.Address = this.txtAddress.Text.Trim();
            this.pRow.Tel = this.txtTel.Text.Trim();

        }

        //点击确定
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.name = this.txtName.Text.Trim();
            if (string.IsNullOrWhiteSpace(this.name))
            {
                MessageBox.Show("姓名为空，不能保存。");
            }
            else if (IsPatientConstraintCollision())
            {
                MessageBox.Show(string.Format("姓名{0}已经存在，不能添加。", this.name));
            }
            else
            {
                this.SetValuesForRow();
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
