using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();

            while (true)
            {
                int index = bank.ShowMemuAndGetInput();
                switch (index)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        bank.LoginOrCreatUser();
                        break;
                    case 2:
                        bank.SaveMoney();
                        break;
                    case 3:
                        bank.TakeMoney();
                        break;
                    case 4:
                        bank.Transfer();
                        break;
                    case 5:
                        bank.Query();
                        break;
                    case 6:
                        bank.EditPwd();
                        break;
                    default:
                        break;
                }
            }

        }
    }
}
