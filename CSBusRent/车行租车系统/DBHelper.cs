using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;

namespace 车行租车系统
{
    public class DBHelper
    {

        public DBHelper()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }


        /// <summary>
        /// 获得数据库连接字符串
        /// </summary>
        /// <returns></returns>
        public static string GetConnStr()
        {
            return "Data Source=.;Initial Catalog=CheHang;Integrated Security=True";
        }



        /// <summary>
        /// 由sql变量（select语句）得到DataSet类型查询记录集合
        /// </summary>
        /// <param name="sql">select语句，字符串类型</param>
        /// <returns></returns>
        public static DataSet GetDate(string sql)
        {
            SqlConnection conn = new SqlConnection(GetConnStr());
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            conn.Close();
            return ds;
        }


        public static DataSet GetView(string viewName)
        {
            SqlConnection conn = new SqlConnection(GetConnStr());
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from " + viewName, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            conn.Close();
            return ds;
        }



        /// <summary>
        /// 执行sql语句，主要是insert、update、delete语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int Exec(string sql)
        {
            SqlConnection conn = new SqlConnection(GetConnStr());
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                return 0;
            }
            return 1;
        }
    }
}
