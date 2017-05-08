using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSBike
{
    public partial class frmEditUser : Form
    {
        public User user;
        private bool isAdding;
        private bool isAdministrator;
        public frmEditUser()//never use
        {
            InitializeComponent();
            this.user = new User(false);
        }

        public frmEditUser(bool isAdministrator)
        {
            InitializeComponent();
            this.isAdministrator = isAdministrator;
            this.user = new User(isAdministrator);
            this.isAdding = true;
            this.txtId.Text = this.user.Id.ToString();
        }

        public frmEditUser(User user)
        {
            InitializeComponent();
            this.user = user;
            this.isAdministrator = user.IsAdministrator;
            this.isAdding = false;
            this.SyncToControl();
        }

        private void SetAdminControlsVisibility()
        {
            this.label6.Visible = this.isAdministrator;
            this.label7.Visible = this.isAdministrator;
            this.txtpwd1.Visible = this.isAdministrator;
            this.txtpwd2.Visible = this.isAdministrator;
            this.Text = (this.isAdding ? "添加" : "编辑") + (this.isAdministrator ? "管理员" : "用户");
        }

        private void SyncFromControl()
        {
            this.user.Name = this.txtName.Text.Trim();
            this.user.Gender = this.cboGender.Text.Trim();
            this.user.CardNumber = this.txtCardNumber.Text.Trim();
            this.user.Telephone = this.txtTelephone.Text.Trim();
        }

        private void SyncToControl()
        {
            this.txtId.Text = this.user.Id.ToString();
            this.txtName.Text = this.user.Name;
            this.cboGender.Text = this.user.Gender;
            this.txtCardNumber.Text = this.user.CardNumber;
            this.txtTelephone.Text = this.user.Telephone;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.SyncFromControl();
            this.DialogResult = DialogResult.OK;
        }

        private void frmEditUser_Load(object sender, EventArgs e)
        {
            this.SetAdminControlsVisibility();

        }
    }
}
