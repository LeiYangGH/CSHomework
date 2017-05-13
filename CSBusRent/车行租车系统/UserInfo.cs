using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 车行租车系统
{
    static class UserInfo
    {
        public static string UserPWD;
        public static string getUserPWD
        {
            get { return UserPWD; }
        }

        public static string setUserPWD
        {
            set { UserPWD = value; }
        }


        public static string UserName;
        public static string getUserName
        {
            get { return UserName; }
        }

        public static string setUserName
        {
            set { UserName = value; }
        }
    }
}
