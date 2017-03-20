using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace 工资管理系统
{
    class CPublic
    {
        public static DataRow LoginInfo;
        public static bool guanliyuan;

        public static void Checkusers(string UserId, string Pwd)
        {
            OleDbConnection cn = new OleDbConnection(Properties.Settings.Default.bysj);
            OleDbDataAdapter da = new OleDbDataAdapter("select * from users where  ygbh=@UserId and pwd=@Pwd", cn);
            da.SelectCommand.Parameters.Add("@UserId", OleDbType.VarChar, 20).Value = UserId;
            da.SelectCommand.Parameters.Add("@Pwd", OleDbType.VarChar, 20).Value = Pwd;
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                LoginInfo = ds.Tables[0].Rows[0];

            }
            else
                LoginInfo = null;
        }

        public static void Checkguanliyuan(string UserId, string Pwd)
        {
            OleDbConnection cn = new OleDbConnection(Properties.Settings.Default.bysj);
            OleDbDataAdapter da = new OleDbDataAdapter("select * from guanliyuan where  员工编号=@UserId and 密码=@Pwd", cn);
            da.SelectCommand.Parameters.Add("@UserId", OleDbType.VarChar, 11).Value = UserId;
            da.SelectCommand.Parameters.Add("@Pwd", OleDbType.VarChar, 6).Value = Pwd;
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                LoginInfo = ds.Tables[0].Rows[0];
                guanliyuan = false;
            }
            else
                LoginInfo = null;
       }
    }
}
