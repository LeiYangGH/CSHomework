using BigJob;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginLogDemo
{
    public static class Repository
    {
        public static string currentUserName;

        public static void AddLogin()
        {
            Repository.AddLog(Repository.currentUserName, "登录", DateTime.Now);
        }

        public static void AddLogout()
        {
            Repository.AddLog(Repository.currentUserName, "退出", DateTime.Now);
        }

        private static void AddLog(string u, string o, DateTime dt)
        {
            if (string.IsNullOrWhiteSpace(Repository.currentUserName))
                return;
            string sql = "insert into S_log (User_name,Situation,[Time]) values (@User_Name,@Situation,@Time) ";
            OleDbParameter[] prams ={
                                       new OleDbParameter("@User_Name",u),
                                       new OleDbParameter("@Situation",o),
                                       new OleDbParameter("@Time",dt.ToString())
                                   };

            AccessHelper.ExecuteNonQuery(sql, prams);
        }
    }
}
