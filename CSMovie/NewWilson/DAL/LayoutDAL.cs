using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class LayoutDAL
    {
        public Layout FromSqlDatalReader(SqlDataReader reader)
        {
            Layout obj = new Layout();
            if (reader["id"] is DBNull == false)
            {
                obj.Id = Convert.ToInt32(reader["id"]);
            }
            if (reader["style"] is DBNull == false)
            {
                obj.Style = Convert.ToString(reader["style"]);
            }
            if (reader["refNum"] is DBNull == false)
            {
                obj.RefNum = Convert.ToInt32(reader["refNum"]);
            }
            return obj;
        }
        public List<Layout> GetAllFromSqlServer()
        {
            List<Layout> layouts = new List<Layout>();
            SqlDataReader reader = SqlHelper.ExecuteReader(
                SqlHelper.ConnString
                , CommandType.Text
                , "select * from vw_layout");
            while (reader.Read())
            {
                Layout ly = FromSqlDatalReader(reader);
                layouts.Add(ly);
            }
            return layouts;
        }
        public int Insert(Layout layout)
        {
            SqlParameter spName = new SqlParameter("@name", SqlDbType.NVarChar, 50) { Value = layout.Style };

            object id = SqlHelper.ExecuteScalar(
                SqlHelper.ConnString
                , CommandType.Text
                , "INSERT layout VALUES (@name); SELECT SCOPE_IDENTITY()"
                , spName
                );
            return Convert.ToInt32(id);
        }
        public void Delete(int layoutId)
        {
            SqlParameter sp = new SqlParameter("@id", SqlDbType.Int) { Value = layoutId };
            SqlHelper.ExecuteNonQuery(
                SqlHelper.ConnString
                , CommandType.Text
                , "DELETE layout WHERE id = @id"
                ,sp
                );
        }
        public void Update(Layout layout)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                 new SqlParameter("@id", SqlDbType.Int) { Value = layout.Id }
                ,new SqlParameter("@name", SqlDbType.NVarChar, 50) { Value = layout.Style }
            };
            SqlHelper.ExecuteNonQuery(
                SqlHelper.ConnString
                , CommandType.Text
                , "UPDATE layout SET name= @name WHERE id= @id"
                ,parms
                );
        }
        public void Update(int id, string styleName)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                 new SqlParameter("@id", SqlDbType.Int) { Value = id }
                ,new SqlParameter("@name", SqlDbType.NVarChar, 50) { Value = styleName }
            };
            SqlHelper.ExecuteNonQuery(
                SqlHelper.ConnString
                , CommandType.Text
                , "UPDATE layout SET name= @name WHERE id= @id"
                , parms
                );
        }
        public List<Layout> Search(string unclearName)
        {
            List<Layout> layouts = new List<Layout>();
            SqlParameter sp = new SqlParameter("@name", SqlDbType.NVarChar, 50) { Value = unclearName };
            SqlDataReader reader = SqlHelper.ExecuteReader(
                SqlHelper.ConnString
                ,CommandType.Text
                ,"SELECT * FROM vw_layout WHERE name LIKE N'%@name%'"
                ,sp
                );
            while (reader.Read())
            {
                layouts.Add(FromSqlDatalReader(reader));
            }
            return layouts;
        }
    }
}
