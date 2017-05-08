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
        public frmEditUser()
        {
            InitializeComponent();
            this.user = new User();
        }

        public frmEditUser(User user) : this()
        {
            this.user = user;
            this.SyncToControl();
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
    }
}
