using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using BankManage.common;

namespace BankManage.money
{
    /// <summary>
    /// Withdraw.xaml 的交互逻辑
    /// </summary>
    public partial class Withdraw : Page
    {
        public Withdraw()
        {
            InitializeComponent();
        }
        //取款
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            string str; int a = 0;
            Custom custom = DataOperation.GetCustom(this.txtAccount.Text);
            if (custom == null)
            {
                MessageBox.Show("帐号不存在！");
                return;
            }
            if (custom.AccountInfo.accountPass != this.txtPassword.Password)
            {
                MessageBox.Show("密码不正确");
                return;
            }
            str = this.txtmount.Text;
            a = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsNumber(str[i]))
                    a++;
            }
            if (a == str.Length && a != 0)
                custom.Withdraw(double.Parse(this.txtmount.Text));
            else
            {
                MessageBox.Show("操作失败，请输入取款为数字");
                this.txtmount.Text = null; return;

            }
            OperateRecord page = new OperateRecord();
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(page);
        }
        //取消取款
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            OperateRecord page = new OperateRecord();
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(page);
        }
    }
}
