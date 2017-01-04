using Model;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class SaleDAL
    {
        public List<Position> GetSoldPositionsByMovieName(string movieName)
        {
            DataTable pdt = new DataTable();
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnString))
            {
                string psql = string.Format("select * from [saleseat] where [moviename] = '{0}'", movieName);
                SqlDataAdapter pda = new SqlDataAdapter(psql, conn);
                pda.Fill(pdt);
            }
            return pdt.Rows.OfType<DataRow>().Select(x =>
            new Position((int)(x[1]), (int)(x[2]))).ToList();
        }

        public bool InsertSale(Sale sale)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnString))
                {
                    conn.Open();
                    string sql1 = string.Format("insert into [sale]([moviename], [custtype],[price]) values ('{0}','{1}',{2})", sale.MovieName, sale.CustomerTypeName, sale.Price);
                    SqlCommand cmd1 = new SqlCommand(sql1, conn);
                    cmd1.ExecuteNonQuery();
                    foreach (Position p in sale.SoldPositions)
                    {
                        string sql2 = string.Format("insert into [saleseat]([moviename], [seatrow],[seatcol]) values ('{0}',{1},{2})", sale.MovieName, p.RowNum, p.ColNum);
                        SqlCommand cmd2 = new SqlCommand(sql2, conn);
                        cmd2.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }

        }
    }
}

