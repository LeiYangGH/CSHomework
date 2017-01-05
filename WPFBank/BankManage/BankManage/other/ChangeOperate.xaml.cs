using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BankManage.other
{
    /// <summary>
    /// ChangeOperate.xaml 的交互逻辑
    /// </summary>
    public partial class ChangeOperate : Page
    {
        BankEntities1 context = new BankEntities1();
        public ChangeOperate()
        {
            InitializeComponent();
        }
        //更改密码
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            var query = from t in context.LoginInfo
                        where t.Bno == this.txtAccount.Text
                        select t;
            if (query.Count() > 0)
            {
                var q = query.First();
                if (txtNewPass.Password == txtPassConf.Password && txtPassConf.Password.Length!= 0)
                    q.Password= this.txtNewPass.Password;
                else if (txtPassConf.Password.Length == 0)
                {
                    MessageBox.Show("密码不能为空");
                    return;
                }
                else
                {
                    MessageBox.Show("两次输入的密码不一样");
                    this.txtNewPass.Clear();
                    this.txtPassConf.Clear();
                    return;
                }
                try
                {
                    context.SaveChanges();
                    MessageBox.Show("更改密码成功！");
                }
                catch
                {
                    MessageBox.Show("更改密码失败！");
                }
            }
            else
            {
                MessageBox.Show("此编号不存在");
                this.txtAccount.Clear();
            }
        }
        //取消更改
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.txtNewPass.Clear();
            this.txtPassConf.Clear();
        }
    }
}
