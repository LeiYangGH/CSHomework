using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
namespace ReadSheetsSpecialName
{
    class Program
    {
        static void Main(string[] args)
        {
            string connStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=test.xls;Extended Properties=""Excel 8.0""";
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                string sql = "select * from ['#Ticker$$']";
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                //DataTable dt  = conn.GetSchema("Tables");//check dt's contents
                da.Fill(dt);
                foreach (DataRow r in dt.Rows)
                {
                    Console.WriteLine($"{r[0]} {r[1]}");
                }
            }
            Console.ReadKey();
        }
    }
}
