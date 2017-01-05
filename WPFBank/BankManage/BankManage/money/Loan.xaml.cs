using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BankManage.common;
namespace BankManage.money
{
    /// <summary>
    /// Interaction logic for Loan.xaml
    /// </summary>
    public partial class Loan : Page
    {
        public Loan()
        {
            InitializeComponent();
        }

        private double GetLoadRateOfYear(int year)
        {
            using (BankEntities1 context = new BankEntities1())
            {
                var rates = context.LoadRate.ToList();
                //下面的写死了不太好，要彻底解决需要改进数据库结构，但由于存款利息表也是这样设计就没改
                if (year <= 1)
                    return rates.First(x => x.rationType == "1年以内").rationValue.Value;
                else if (year > 5)
                    return rates.First(x => x.rationType == "5年以上").rationValue.Value;
                else
                    return rates.First(x => x.rationType == "1年到5年").rationValue.Value;
            }
        }

        private double CheckLoadMax(string accountNo)
        {
            using (BankEntities1 context = new BankEntities1())
            {
                double historySum = context.MoneyInfo.Where(x => x.accountNo == accountNo)
                    .Sum(x => x.dealMoney);
                double hisSum10 = historySum * 10;
                return hisSum10 > 100 ? hisSum10 : 100;
            }
        }



        private void CalcAndShowTotalInterest(double amount, double rate, double year)
        {
            double interest = amount * rate * year;//简单计算，没考虑复利之类
            MessageBox.Show(string.Format("总利息：{0}", interest));
        }

        private bool CheckAlreadyLoan(string accountNo)
        {
            using (BankEntities1 context = new BankEntities1())
            {
                return context.MoneyInfo.Any(x =>
                x.accountNo == accountNo
                && x.dealType == "贷款");
            }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {

            Custom custom = DataOperation.GetCustom(this.txtAccount.Text);
            if (custom == null)
            {
                MessageBox.Show("帐号不存在！");
                return;
            }

            if (custom.CheckLost())
            {
                MessageBox.Show("账户已挂失不能使用！");
                return;
            }

            if (custom.AccountInfo.accountPass != this.txtPassword.Password)
            {
                MessageBox.Show("密码不正确");
                return;
            }

            if (this.CheckAlreadyLoan(this.txtAccount.Text))
            {
                MessageBox.Show("您已经贷款，每个客户只能贷一次！");
                return;
            }

            double loanAmount;
            if (!double.TryParse(this.txtmount.Text.Trim(), out loanAmount))
            {
                MessageBox.Show("输入的金额格式不正确");
                return;
            }

            if (loanAmount > this.CheckLoadMax(this.txtAccount.Text.Trim()))
            {
                MessageBox.Show("贷款金额超出信用额度（历史交易额总和的10倍）");
                return;
            }

            int loanYear;
            if (!int.TryParse(this.txtYear.Text.Trim(), out loanYear))
            {
                MessageBox.Show("输入的贷款年限格式不正确");
                return;
            }

            double rate = this.GetLoadRateOfYear(loanYear);
            CalcAndShowTotalInterest(loanAmount, rate, loanYear);
            custom.Diposit("贷款", loanAmount);
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
