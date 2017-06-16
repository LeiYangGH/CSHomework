using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace BigJob
{
    class database
    {
        public string sql;
        //与SQL Server的连接字符串设

        //public string strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =kpsdatabase2.mdb";
        public string strCon = ConfigurationManager.ConnectionStrings["kpsdatabase2"].ConnectionString;
        //与数据库的连接
        public OleDbConnection acecon;
        public OleDbDataAdapter aceda;
        public OleDbCommand acecom;
        public OleDbCommandBuilder aceComBld;
        public DataSet ds = new DataSet();

        public database()
        {
            //构造函数
        }
        //操作脱机数据库(创建了该类的实例时直接用) 
        //根据输入的SQL语句检索数据库数据
        public DataSet SelectDataBase(string tempsql, string tempTableName)
        {
            sql = tempsql;
            acecon = new OleDbConnection(strCon);
            aceda = new OleDbDataAdapter(this.sql, this.acecon);
            ds.Clear();
            aceda.Fill(ds, tempTableName);
            return ds;//返回填充了数据的DataSet，其中数据表以tempTableName给出的字符串命名
        }

        //数据库数据更新(传DataSet和DataTable的对象)
        public DataSet UpdateDataBase(DataSet changedDataSet, string tableName)
        {
            acecon = new OleDbConnection(strCon);
            aceda = new OleDbDataAdapter(sql, acecon);
            aceComBld = new OleDbCommandBuilder(aceda);
            aceda.Update(changedDataSet, tableName);
            return changedDataSet;//返回更新了的数据库表
        }

        //直接操作数据库(未创建该类的实例时直接用)
        //检索数据库数据(传字符串,直接操作数据库)
        public DataTable SelectDataBase(string tempsql)
        {
            acecon = new OleDbConnection(strCon);
            DataSet tempDataSet = new DataSet();
            aceda = new OleDbDataAdapter(tempsql, acecon);
            aceda.Fill(tempDataSet);
            return tempDataSet.Tables[0];
        }

        //数据库数据更新(传字符串，直接操作数据库)
        public int UpdateDataBase(string tempsql)
        {
            acecon = new OleDbConnection(strCon);
            //使用Command之前一定要先打开连接,后关闭连接,而DataAdapter则会自动打开关闭连接
            acecon.Open();
            acecom = new OleDbCommand(tempsql, acecon);
            int intNumber = acecom.ExecuteNonQuery();//返回数据库中影响的行数
            acecon.Close();
            return intNumber;
        }

        public OleDbDataReader UpdateDataBase2(string tempsql)
        {
            acecon = new OleDbConnection(strCon);
            //使用Command之前一定要先打开连接,后关闭连接,而DataAdapter则会自动打开关闭连接
            acecon.Open();
            acecom = new OleDbCommand(tempsql, acecon);
            int intNumber = acecom.ExecuteNonQuery();//返回数据库中影响的行数
            OleDbDataReader dr = acecom.ExecuteReader();
            acecon.Close();
            return dr;
        }

        public int UpdateDataBase(string tempsql, OleDbParameter [] temparray)
        {
            acecon = new OleDbConnection(strCon);
            acecon.Open();
            //使用Command之前一定要先打开连接,后关闭连接,而DataAdapter则会自动打开关闭连接
            acecom = new OleDbCommand(tempsql, acecon);
            acecom.Parameters.AddRange(temparray);
            int intNumber = acecom.ExecuteNonQuery();//返回数据库中影响的行数
            acecon.Close();
            return intNumber;
        }

    }
}
