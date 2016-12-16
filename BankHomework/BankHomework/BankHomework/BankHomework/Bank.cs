using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace BankHomework
{
    class Bank
    {
        private string usersFile = @"users.txt";
        private string exchangesFile = @"money.txt";
        //用户列表
        List<User> usersList;
        //交易记录列表
        List<Exchange> exchangesList;
        User currentUser;

        public Bank()
        {
            this.ReadUsersFromFile();
            this.ReadExchangesFromFile();
            //#if DEBUG
            //            this.currentUser = this.usersList.FirstOrDefault(x => x.Name == "ly");
            //#endif
            this.Login();
            this.CalculateUserBalance();
        }

        /// <summary>
        /// 登录
        /// </summary>
        private void Login()
        {
            while (this.currentUser == null)
            {
                LoginOrCreatUser();
            }
        }

        //登录或开户
        public void LoginOrCreatUser()
        {
            Console.WriteLine("请输入你的账户");
            string name = Console.ReadLine().Trim();
            Console.WriteLine("请输入你的密码");
            string pwd = Console.ReadLine();

            User foundUser = this.usersList.FirstOrDefault(x => x.Name == name);
            if (foundUser == null)
            {
                this.currentUser = new User(name, pwd);
                this.usersList.Add(this.currentUser);
                this.SaveUsersToFile();
                Console.WriteLine("你的账户是:{0},你的密码是{1}", name, pwd);
            }
            else
            {
                if (foundUser.Password == pwd)
                {
                    this.currentUser = foundUser;
                    Console.WriteLine("你的账户是:{0},登录成功！", name);
                }
                else
                    Console.WriteLine("登录失败！");
            }
        }

        /// <summary>
        /// 保存用户文件
        /// </summary>
        private void SaveUsersToFile()
        {
            File.WriteAllLines(this.usersFile, this.usersList.Select(x => x.ToString()));
        }

        /// <summary>
        /// 保存交易记录
        /// </summary>
        private void SaveExchangesToFile()
        {
            File.WriteAllLines(this.exchangesFile, this.exchangesList.Select(x => x.ToString()));
        }

        /// <summary>
        /// 取款
        /// </summary>
        public void TakeMoney()
        {
            Console.WriteLine("请输入要取多少钱");
            double rmb = Convert.ToDouble(Console.ReadLine().Trim());
            if (rmb > this.currentUser.Balance)
            {
                Console.WriteLine("余额不足，你的帐户只剩下 {0}！", currentUser.Balance);
            }
            else
            {
                Exchange exch = new Exchange(currentUser.Name, -rmb, DateTime.Now);
                this.exchangesList.Add(exch);
                this.SaveExchangesToFile();
                this.CalculateUserBalance();
                Console.WriteLine("取钱成功，余额是{0}！", currentUser.Balance);
            }

        }


        /// <summary>
        /// 存款
        /// </summary>
        public void SaveMoney()
        {
            Console.WriteLine("请输入要存多少钱");
            double rmb = Convert.ToDouble(Console.ReadLine().Trim());
            Exchange exch = new Exchange(currentUser.Name, rmb, DateTime.Now);
            this.exchangesList.Add(exch);
            this.SaveExchangesToFile();
            this.CalculateUserBalance();
            Console.WriteLine("存钱成功，余额是{0}！", currentUser.Balance);
        }

        /// <summary>
        /// 计算当前用户的余额
        /// </summary>
        private void CalculateUserBalance()
        {
            currentUser.Balance = this.exchangesList
                .Where(x => x.Name == currentUser.Name)
                .Sum(x => x.RMB);
        }

        /// <summary>
        /// 转账
        /// </summary>
        public void Transfer()
        {
            Console.WriteLine("请输入收款方姓名");
            string desName = Console.ReadLine().Trim();
            if (!this.usersList.Any(x => x.Name == desName))
            {
                Console.WriteLine("用户{0}不存在！", desName);
                return;
            }
            else
            {
                Console.WriteLine("请输入转账金额");
                double rmb = Convert.ToDouble(Console.ReadLine().Trim());
                if (rmb > this.currentUser.Balance)
                {
                    Console.WriteLine("余额不足，你的帐户只剩下 {0}！", currentUser.Balance);
                    return;
                }
                else
                {
                    Exchange exchAdd = new Exchange(desName, rmb, DateTime.Now);
                    Exchange exchMinus = new Exchange(currentUser.Name, -rmb, DateTime.Now);
                    this.exchangesList.Add(exchAdd);
                    this.exchangesList.Add(exchMinus);
                    this.SaveExchangesToFile();
                    this.CalculateUserBalance();
                    Console.WriteLine("取钱成功，余额是{0}！", currentUser.Balance);
                }
            }

        }


        /// <summary>
        /// 余额和明细查询
        /// </summary>
        public void Query()
        {
            Console.WriteLine("余额是{0}！", currentUser.Balance);
            Console.WriteLine("下面是交易记录");
            foreach (Exchange exch in this.exchangesList
                .Where(x => x.Name == currentUser.Name))
            {
                Console.WriteLine("{0}\t{1}", exch.Time, exch.RMB);
            }

        }


        /// <summary>
        /// 修改密码
        /// </summary>
        public void EditPwd()
        {
            Console.WriteLine("请输入你的原密码");
            string oldPwd = Console.ReadLine();
            if (oldPwd == this.currentUser.Password)
            {

                Console.WriteLine("请输入你的新密码");
                string newPwd1 = Console.ReadLine();
                Console.WriteLine("请再次输入你的新密码");
                string newPwd2 = Console.ReadLine();
                if (newPwd1 == newPwd2)
                {
                    this.currentUser.Password = newPwd1;
                    this.SaveUsersToFile();
                    Console.WriteLine("修改成功！新密码是{0}", newPwd1);
                }
                else
                {
                    Console.WriteLine("输入的两次新密码不匹配！");
                }
            }
            else
            {
                Console.WriteLine("密码错误！");
            }
        }

        /// <summary>
        /// 判断输入的菜单选择是否合法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private int SelectedMenuIndex(string input)
        {
            int n;
            if (int.TryParse(input, out n)
                && n >= 0 && n <= 6)
                return n;
            return -1;
        }

        /// <summary>
        /// 显示菜单和接收用户选择
        /// </summary>
        /// <returns></returns>
        public int ShowMemuAndGetInput()
        {
            Console.WriteLine(
@"=========================欢迎进入205班银行系统========================
0.退出    1.登录或开户     2.存款   3.取款   4.转账   5.查询余额   6.修改密码   
====================================================================
请选择"
);
            int chose = -1;
            while (true)
            {
                string input = Console.ReadLine();
                chose = this.SelectedMenuIndex(input);
                if (chose == -1)
                    Console.WriteLine("输入错误，请重选择(0-6):");
                else
                {
                    Console.WriteLine("您选择了" + chose.ToString());
                    return chose;
                }
            }
        }


        /// <summary>
        /// 从users.txt读取用户列表
        /// </summary>
        public void ReadUsersFromFile()
        {
            this.usersList = File.ReadLines(this.usersFile)
                .Select(x => User.CreateUserFromLine(x))
                .ToList();
        }

        /// <summary>
        /// 从money.txt读取用户列表
        /// </summary>
        public void ReadExchangesFromFile()
        {
            this.exchangesList = File.ReadLines(this.exchangesFile)
                .Select(x => Exchange.CreateExchangeFromLine(x))
                .ToList();
        }
    }
}