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

namespace BankManage.query
{
    /// <summary>
    /// TotalQuery.xaml 的交互逻辑
    /// </summary>
    public partial class TotalQuery : Page
    {
        
        public TotalQuery()
        {
            InitializeComponent();
            this.Unloaded += TotalQuery_Unloaded;
        }

        void TotalQuery_Unloaded(object sender, RoutedEventArgs e)
        {
          
           
        }
        //查询当前账号的所有记录信息
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BankEntities1 context = new BankEntities1();
            var query = from t in context.MoneyInfo
                        where t.accountNo == txtID.Text
                        select t;
            if(query.Count()>0)
            datagrid1.ItemsSource = query.ToList();
            else
            {
                MessageBox.Show("此账号不存在");
                this.txtID.Clear();
            }
            context.Dispose();
        }
    }
}
