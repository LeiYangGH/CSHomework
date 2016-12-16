using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bank
{
    class Bank
    {

        //对象数组保存用户信息
        User[] user = new User[100];



        //开户
        public void CreatAccount()
        {    
           Console.WriteLine("请输入你的账户");
           user[j] = Console.ReadLine();
           Console.WriteLine("请输入你的密码");
           Mima[k] = Console.ReadLine();
           Console.WriteLine("你的账户是:{0},你的密码是{1}", user[j], Mima[k]);
        }


        //取款
        public void TakeMoney()
        {

        }


        //存款
        public void SaveMoney()
        {

        }


        //转账
        public void Transfer()
        {

        }


        //查询余额
        public void Search()
        {

        }


        //修改密码
        public void EditPwd()
        {


        }


        public void showMian()
        {
            Console.WriteLine("=========================欢迎进入205班银行系统========================");
            Console.WriteLine("1.开户     2.存款   3.取款   4.转账   5.查询余额   6.修改密码   0.退出");
             Console.WriteLine("====================================================================");
            Console.WriteLine("请选择");
            int chose;
            bool flag=false;

            do{
               chose =int.Parse(Console.ReadLine());
                if(chose>6||chose<0)
                {
                  Console.WriteLine("输入错误，请重选择(0-6):");
                    flag=true;
                }
                else{
                flag=false;
                }
            }while(flag);
        }


        //初始化用户信息
        public void Initial()
        {
            user[0] = new User();
            user[0].Name = "wilson";
            user[0].Account = "233333333";
            user[0].Id = "412121223232323";
            user[0].Mima = "123123";
            user[0].Balance = 666.6;


            user[1] = new User();
            user[1].Name = "wilso";
            user[1].Account = "233333333";
            user[1].Id = "41212122323232";
            user[1].Mima = "123123";
            user[1].Balance = 6666.6;


            user[2] = new User();
            user[2].Name = "wils";
            user[2].Account = "233333333";
            user[2].Id = "4121212232323";
            user[2].Mima = "123123";
            user[2].Balance = 66666.6;
        }

        public int cheakUser()
        {
            int index = -1;
            for (int i = 0; i < user.Length; i++)
            {
                if (user[i] == null)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }


        public void showUser()
        {

            Initial();
            int index = cheakUser();
            for (int i = 0; i < index; i++)
            {
                Console.WriteLine("用户名：[0],账号:[1],余额:[2]", user[i].Name, user[i].Account, user[i].Balance);
            }
        }

        public bool login()
        {
            string account;
            string pwd;
            int change=3;
            bool flag = false;
            bool state=false;
            Console.WriteLine("===============请登陆！================");
            do
            {
                Console.WriteLine("请输入账户:");
                account = Console.ReadLine();
                int index = searchNum(account);
                if (index == -1) {
                    Console.WriteLine("账户不存在，请重新输入:");
                    continue;
                }
                Console.WriteLine("请输入密码:");
                pwd = Console.ReadLine();
                if (pwd == user[index].Mima)
                {
                    return true;
                }
                else {
                    Console.WriteLine("密码有误！您还有｛0｝请重新输入：",change);
                    change--;
                    if (change >= 0)
                    {
                        Console.WriteLine("您的机会已用完，程序结束！");
                        flag = false;
                        state = false;
                    }
                    else {
                        flag = true;
                    }
                }
            } while (flag);
        }
        public int searchNum(string num)
        {

            int index = -1;
            int sum = cheakUser();
            for (int i = 0; i < sum; i++)
            {
                if (num == user[i].Account)
                {
                    index = i;
                    break;
                }
            }
            return index;

        }


    }
}