﻿using System;
using System.Linq;
using System.Windows;

namespace BankManage
{
    /// <summary>
    /// 保存客户发生的最新业务信息
    /// </summary>
    public class Custom
    {
        BankEntities1 context = new BankEntities1();
        public Custom()
        {
            AccountInfo = new AccountInfo();
            MoneyInfo = new MoneyInfo();
        }


        /// <summary>
        /// 存款客户的帐户基本信息
        /// </summary>
        public AccountInfo AccountInfo { get; set; }
        /// <summary>
        /// 存款发生信息
        /// </summary>
        public MoneyInfo MoneyInfo { get; set; }
        /// <summary>
        /// 帐户余额
        /// </summary>
        public double AccountBalance { get; set; }



        public bool CheckLost()
        {
            return context.Lost.Any(x => x.accountNo == this.AccountInfo.accountNo);
        }

        public void ReportLost()
        {
            try
            {
                Lost lost = new Lost();
                lost.accountNo = this.AccountInfo.accountNo;
                context.Lost.Add(lost);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                //添加dialog，money需大于零
                MessageBox.Show(ex.Message);
            }
        }

        /// 开户
        /// </summary>
        /// <param name="accountNumber">帐号</param>
        /// <param name="money">开户金额</param>
        public virtual void Create(string accountNumber, double money)
        {
            this.AccountBalance = money;
            //插入到数据库
            try
            {
                context.AccountInfo.Add(AccountInfo);
                context.SaveChanges();
            }
            catch
            {
                MessageBox.Show("开户失败！");
            }
            this.MoneyInfo.accountNo = accountNumber;
            InsertData("开户", money);
        }

        /// <summary>
        ///存款 
        /// </summary>
        /// <param name="genType">类型</param>
        /// <param name="money">金额</param>
        public virtual void Diposit(string genType, double money)
        {
            if (money <= 0)
            {
                try
                {
                    throw new Exception("存款金额不能为零或负值");
                }
                catch
                {
                    //添加dialog，money需大于零
                    MessageBox.Show("存款金额需大于0！");
                }
            }
            else
            {
                //修改余额
                if (this.CheckLost())
                {
                    MessageBox.Show("账户已挂失不能使用！");
                }
                else
                {
                    AccountBalance += money;
                    InsertData(genType, money);
                }
            }
        }

        /// <summary>
        ///检查是否允许取款，允许返回true，否则返回false
        /// </summary>
        /// <param name="money">取款金额</param>
        public bool ValidBeforeWithdraw(double money)
        {
            if (money <= 0)
            {
                MessageBox.Show("取款金额不能为零或负值");
                return false;
            }
            if (money > AccountBalance)
            {
                MessageBox.Show("取款数不能比余额大");
                return false;
            }
            return true;
        }

        /// <summary>
        ///取款 
        /// </summary>
        /// <param name="money">取款金额</param>
        public virtual void Withdraw(double money)
        {
            AccountBalance -= money;
            InsertData("取款", -money);
        }

        /// <summary>
        /// 在表中添加新记录
        /// </summary>
        /// <param name="genType">发生类别</param>
        /// <param name="money">发生金额</param>
        public void InsertData(string genType, double money)
        {

            MoneyInfo.accountNo = this.AccountInfo.accountNo;
            MoneyInfo.dealDate = DateTime.Now;
            MoneyInfo.dealType = genType;
            MoneyInfo.dealMoney = money;
            MoneyInfo.balance = AccountBalance;
            try
            {
                context.MoneyInfo.Add(MoneyInfo);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加失败：" + ex.Message);
            }

        }
    }
}
