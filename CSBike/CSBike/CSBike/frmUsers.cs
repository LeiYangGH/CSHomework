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
    public partial class frmUsers : Form
    {
        private Repository repository = new Repository();
        private BindingList<User> lstUsers;
        private bool isAdministrator;
        public frmUsers()//never call
        {
            InitializeComponent();
        }

        public frmUsers(bool isAdministrator)
        {
            InitializeComponent();
            this.isAdministrator = isAdministrator;
        }

        private void ViewAll()
        {
            var users = this.repository.GetAllUsers().Where(x => x.IsAdministrator == this.isAdministrator).ToList();
            this.lstUsers = new BindingList<User>(users);
            this.dataGridView1.DataSource = this.lstUsers;
        }

        private User GetFirstSelectedUser()
        {
            var selectedRows = this.dataGridView1.SelectedRows;
            if (selectedRows == null)
                return null;
            else
            {
                return selectedRows[0].DataBoundItem as User;
            }
        }



        private void frmUsers_Load(object sender, EventArgs e)
        {
            this.repository.ReadUsers();
            this.ViewAll();
            this.Text = this.isAdministrator ? "管理员管理" : "用户管理";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User User = this.GetFirstSelectedUser();
            if (User != null)
            {
                int oldId = User.Id;
                frmEditUser editor = new frmEditUser(User);
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    this.repository.EditUser(oldId, User);
                    {
                        this.ViewAll();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            User User = this.GetFirstSelectedUser();
            if (User != null)
            {
                this.repository.DeleteUser(User);

                this.ViewAll();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmEditUser editor = new frmEditUser(this.isAdministrator);
            if (editor.ShowDialog() == DialogResult.OK)
            {
                this.repository.AddUser(editor.user);
                {
                    this.ViewAll();
                }
            }
        }

        private void frmUsers_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.repository.SaveUsers();
        }
    }
}
