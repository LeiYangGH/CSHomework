using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BankManage.employee
{
    /// <summary>
    /// EmployeeBase.xaml 的交互逻辑
    /// </summary>
    public partial class EmployeeBase : Page
    {
        public EmployeeBase()
        {
            InitializeComponent();
            this.Unloaded += Page_Unloaded;

        }
        int i = 0;
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            comboBox.Items.Add("全部"); comboBox.Items.Add("姓名"); comboBox.Items.Add("编号"); comboBox.Items.Add("性别"); comboBox.Items.Add("ID");
            comboBox.Items.Add("电话"); 


        }
        BankEntities1 context = new BankEntities1();
        private void button_Click(object sender, RoutedEventArgs e)
        {
            
            context = new BankEntities1();
            if (comboBox.SelectedItem == null)
                MessageBox.Show("选择查找类别");
            else
            {
                i = 0;
                string s1 = comboBox.SelectedItem.ToString();
                string s2 = textBox.Text;               
                if (s1 == "编号")
                {
                    if (s2 == "")
                    {
                        MessageBox.Show("请输入查找的编号");
                    }else
                    {
                        var q = from t in context.EmployeeInfo
                                where t.EmployeeNo == s2
                                select t;
                        dataGrid.ItemsSource = q.ToList();
                    }
                    
                }
                if (s1 == "姓名")
                {
                    if (s2 == "")
                    {
                        MessageBox.Show("请输入查找的姓名");
                    }
                    else
                    {
                        var q = from t in context.EmployeeInfo
                                where t.EmployeeName == s2
                                select t;
                        dataGrid.ItemsSource = q.ToList();
                    }
                       
                }
                if (s1 == "性别")
                {
                    if (s2 == "")
                    {
                        MessageBox.Show("请输入查找的性别");
                    }
                    else
                    {
                        var q = from t in context.EmployeeInfo
                                where t.sex == s2
                                select t;
                        dataGrid.ItemsSource = q.ToList();
                    }                       
                }
                if (s1 == "ID")
                {
                    if (s2 == "")
                    {
                        MessageBox.Show("请输入查找的ID");
                    }
                    else
                    {
                        var q = from t in context.EmployeeInfo
                                where t.idCard == s2
                                select t;
                        dataGrid.ItemsSource = q.ToList();
                    }                       
                }
                if (s1 == "全部")
                {                   
                        var q = from t in context.EmployeeInfo
                                select t;
                        dataGrid.ItemsSource = q.ToList();                        
                }
                if (s1 == "电话")
                {
                    if (s2 == "")
                    {
                        MessageBox.Show("请输入查找的电话");
                    }
                    else {
                        var q = from t in context.EmployeeInfo
                                where t.telphone == s2
                                select t;
                        dataGrid.ItemsSource = q.ToList();
                    }
                        
                }
                
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (i == 0)
            {
                try
                {
                    context.SaveChanges();
                    MessageBox.Show("保存成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "保存失败");
                }
            }
            else {
               
                try
                {
                    context.SaveChanges();
                    MessageBox.Show("保存成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "保存失败");
                }
                
                var q1 = from t in context.Salary
                        select t;
                this.dataGrid.ItemsSource = q1.ToList();
            }

        }
        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            context.Dispose();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            
            context = new BankEntities1();
            if (i == 0)
            {
                EmployeeInfo p = new EmployeeInfo()
                {
                    EmployeeName = null,
                    EmployeeNo = textBox2.Text,
                    idCard = null,
                    telphone = null,
                    workDate = null,
                    sex = null,
                    photo = null
                };
                LoginInfo l = new LoginInfo() { Bno = textBox2.Text, Password = "123456" };
                try
                {
                    context.EmployeeInfo.Add(p);
                    context.LoginInfo.Add(l);
                    context.SaveChanges();
                    textBox2.Text = "";
                }
                catch (Exception e2)
                {
                    MessageBox.Show("添加失败" + e2.Message);
                    textBox2.Text = "";
                }
                var q = from t in context.EmployeeInfo

                        select t;
                this.dataGrid.ItemsSource = q.ToList();
            }
            else {
                Salary sa = new Salary() {
                    Id =textBox2.Text,
                    姓名=null,
                    基本工资 = null,
                    车补贴 = null,
                    房补贴 = null,
                    奖金 = null,
                    罚款 = null,
                    总和 = null,
                };
                try
                {
                    context.Salary.Add(sa);
                    context.SaveChanges();
                    textBox2.Text = "";
                }
                catch (Exception e2)
                {
                    MessageBox.Show("添加失败" + e2.Message);
                    textBox2.Text = "";
                }
                var q = from t in context.Salary

                        select t;
                this.dataGrid.ItemsSource = q.ToList();
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (i == 0)
            {
                context = new BankEntities1();
                var q = from t in context.EmployeeInfo
                        where t.EmployeeNo == textBox2.Text
                        select t;
                var q1= from t in context.LoginInfo
                        where t.Bno == textBox2.Text
                        select t;
                foreach (var w in q)
                {
                    context.EmployeeInfo.Remove(w);
                }
                foreach (var w in q1)
                {
                    context.LoginInfo.Remove(w);
                }
                context.SaveChanges();
                textBox2.Text = "";
                var s = from t in context.EmployeeInfo

                        select t;
                this.dataGrid.ItemsSource = s.ToList();
            }
            else {
                context = new BankEntities1();
                var q = from t in context.Salary
                        where t.Id== textBox2.Text
                        select t;
                foreach (var w in q)
                {
                    context.Salary.Remove(w);
                }
                context.SaveChanges();
                textBox2.Text = "";
                var s = from t in context.Salary

                        select t;
                this.dataGrid.ItemsSource = s.ToList();

            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            i = 1;
            button.IsEnabled = false;
                     
            context = new BankEntities1();        
            var q = from t in context.Salary  
                    select t;
            dataGrid.ItemsSource = q.ToList();                       
        }
        private void button5_Click(object sender, RoutedEventArgs e)
        {           
            button.IsEnabled = true ;
                  
            i = 0;
            comboBox.SelectedIndex = 0;
            var q = from t in context.EmployeeInfo
                    select t;
            dataGrid.ItemsSource = q.ToList();
        }
    }
}
