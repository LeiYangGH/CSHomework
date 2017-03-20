using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace 工资管理系统
{
    class DataAccess
    {
        public static DataRow LoginInfo;
        public static bool guanliyuan;

        public static bool Checkusers(string UserId, string Pwd)
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
                return true;
            }
            else
            {
                LoginInfo = null;
                return false;
            }
        }

        public static bool Checkguanliyuan(string UserId, string Pwd, out string userName)
        {
            using (OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.bysj))
            {
                string sql = "select 姓名 from guanliyuan where  员工编号=@UserId and 密码=@Pwd";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.Parameters.Add("@UserId", OleDbType.VarChar, 11).Value = UserId;
                cmd.Parameters.Add("@Pwd", OleDbType.VarChar, 6).Value = Pwd;
                conn.Open();
                string name = (string)cmd.ExecuteScalar();
                if (string.IsNullOrWhiteSpace(name))
                {
                    userName = "";
                    return false;
                }
                else
                {
                    userName = name;
                    return true;
                }
            }
        }
    }
}
