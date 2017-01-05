using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using BankManage.common;
namespace BankManage.money
{
    /// <summary>
    /// Interaction logic for ReportLost.xaml
    /// </summary>
    public partial class ReportLost : Page
    {
        public ReportLost()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            string str; int a = 0;
            Custom custom = DataOperation.GetCustom(this.txtAccount.Text);
            if (custom == null)
            {
                MessageBox.Show("帐号不存在！");
                return;
            }
            if (custom.AccountInfo.IdCard != this.txtIDCard.Text)
            {
                MessageBox.Show("身份证不正确");
                return;
            }
            if (custom.AccountInfo.accountPass != this.txtPassword.Password)
            {
                MessageBox.Show("密码不正确");
                return;
            }
            custom.ReportLost();
            this.txtMsg.Text = "挂失成功!";
        }
        //取消开户
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.txtAccount.Clear();
            this.txtIDCard.Clear();
            this.txtPassword.Clear();
            this.txtMsg.Text = "";
        }
    }
}
