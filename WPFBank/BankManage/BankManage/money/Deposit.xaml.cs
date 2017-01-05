using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using BankManage.common;

namespace BankManage.money
{
    /// <summary>
    /// Deposit.xaml 的交互逻辑
    /// </summary>
    public partial class Deposit : Page
    {
        public Deposit()
        {
            InitializeComponent();
        }
        //存款
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            string str;int a = 0;
            Custom custom = DataOperation.GetCustom(this.txtAccount.Text);
            if (custom == null)
            {
                MessageBox.Show("帐号不存在！");
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
                 custom.MoneyInfo.accountNo = txtAccount.Text;
            else
            {
                MessageBox.Show("操作失败，请输入存款为数字");
                this.txtmount.Text = null; return;
                
            }
            
            custom.Diposit("存款", double.Parse(this.txtmount.Text));
            OperateRecord page = new OperateRecord();
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(page);
        }
        //取消存款
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            OperateRecord page = new OperateRecord();
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(page);
        }
    }
}
