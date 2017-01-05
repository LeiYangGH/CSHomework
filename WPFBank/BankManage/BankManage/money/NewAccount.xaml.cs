using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using BankManage.common;

namespace BankManage.money
{
    /// <summary>
    /// NewAccount.xaml 的交互逻辑
    /// </summary>
    public partial class NewAccount : Page
    {
        public NewAccount()
        {
            InitializeComponent();
            InitComboBox();
        }

        private void InitComboBox()
        {
            string[] items = Enum.GetNames(typeof(MoneyAccountType));
            foreach (var s in items)
            {
                comboBoxAccountType.Items.Add(s);
            }
            comboBoxAccountType.SelectedIndex = 0;
        }
        //开户
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            string str;
            int a = 0, b = 0;
            Custom custom = DataOperation.CreateCustom(comboBoxAccountType.SelectedItem.ToString());
            custom.AccountInfo.accountNo = this.txtAccountNo.Text;
            str = this.txtIDCard.Text;
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsNumber(str[i]))
                    a++;
            }
            if (a == str.Length && a == 18)
                custom.AccountInfo.IdCard = this.txtIDCard.Text;
            else
            {
                MessageBox.Show("操作失败,身份证号请输入18位数字");
                this.txtIDCard.Text = null;
                b++;
                return;
            }
            str = this.txtAccountName.Text;
            a = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsNumber(str[i]))
                    a++; 
            }
            if (a == 0)
                custom.AccountInfo.accountName = this.txtAccountName.Text;
            else
            {

                MessageBox.Show("操作失败,姓名不能有数字");
                this.txtAccountName.Text = null;
                b++; return;
            }
           
                custom.AccountInfo.accountPass = this.txtPass.Password;       
            str = this.txtMoney.Text;
            a = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsNumber(str[i]))
                    a++;
            }
            if (a == str.Length&&a!=0)
                custom.Create(this.txtAccountNo.Text, double.Parse(this.txtMoney.Text));
            else
            {
                MessageBox.Show("操作失败，请输入存款为数字");
                this.txtMoney.Text = null; return;
                b++;
            }
            if (b == 0)
            {
                OperateRecord page = new OperateRecord();
                NavigationService ns = NavigationService.GetNavigationService(this);
                ns.Navigate(page);
            }
        }
        //取消开户
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.txtAccountName.Clear();
            this.txtIDCard.Clear();
            this.txtAccountName.Clear();
            this.txtPass.Clear();
            this.txtMoney.Clear();
            OperateRecord page = new OperateRecord();
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(page);
        }

        private void comboBoxAccountType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string s = comboBoxAccountType.SelectedItem.ToString();
            using(BankEntities1 c = new BankEntities1())
            {
                var q = from t in c.AccountInfo
                        where t.accountType == s
                        select t;
                if (q.Count() > 0)
                {
                    this.txtAccountNo.Text = string.Format("{0}", int.Parse(q.Max(x => x.accountNo)) + 1);
                }
                else
                {
                    txtAccountNo.Text = string.Format("{0}00001", comboBoxAccountType.SelectedIndex + 1);
                }
            }
        }
    }
}
