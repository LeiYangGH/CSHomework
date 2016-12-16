using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankHomework
{
    class User
    {
        public User(string name, string pwd)
        {
            this.Name = name;
            this.Password = pwd;
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get;
            set;
        }

        /// <summary>
        /// 余额
        /// </summary>
        public double Balance
        {
            get;
            set;
        }

        /// <summary>
        /// 从txt的一行解析出各个字段
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static User CreateUserFromLine(string line)
        {
            string[] ss = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            return new User(ss[0], ss[1]);
        }

        /// <summary>
        /// 从各个字段组合成一行
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0},{1}", this.Name, this.Password);
        }
    }
}
