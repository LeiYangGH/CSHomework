﻿using System.Linq;
using System.Windows.Controls;

namespace BankManage.money
{
    /// <summary>
    /// OperateRecord.xaml 的交互逻辑
    /// </summary>
    public partial class OperateRecord : Page
    {
        public OperateRecord()
        {
            InitializeComponent();
            BankEntities1 context = new BankEntities1();
            var query = from t in context.MoneyInfo
                        select t;
            this.datagrid1.ItemsSource = query.ToList();
        }
    }
}
