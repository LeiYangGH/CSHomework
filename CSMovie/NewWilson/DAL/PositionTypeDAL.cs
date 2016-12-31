using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class PositionTypeDAL
    {
        public PositionType FromSqlDataReader(SqlDataReader reader)
        {
            PositionType obj = new PositionType();
            if (reader["id"] is DBNull == false)
            {
                obj.Id = Convert.ToByte(reader["id"]);
            }
            if (reader["name"] is DBNull == false)
            {
                obj.Name = Convert.ToString(reader["name"]);
            }
            return obj;
        }
        public List<PositionType> GetALL()
        {
            List<PositionType> ptypes = new List<PositionType>();
            SqlDataReader reader = SqlHelper.ExecuteReader(
                SqlHelper.ConnString
                ,CommandType.Text
                ,"SELECT * FROM positionType"
                );
            while (reader.Read())
            {
                ptypes.Add(FromSqlDataReader(reader));
            }
            return ptypes;
        }
        public int Insert(PositionType pType)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@name", SqlDbType.NVarChar,50) {Value=pType.Name }
            };
            object id = SqlHelper.ExecuteScalar(
                SqlHelper.ConnString
                , CommandType.Text
                , "INSERT INTO positionType VALUES(@name)"
                , parms
                );
            return Convert.ToByte(id);
        }
        public void Delete(byte id)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@id", SqlDbType.TinyInt) {Value=id }
            };
            SqlHelper.ExecuteNonQuery(
                SqlHelper.ConnString
                ,CommandType.Text
                ,"DELETE FROM positionType WHERE id = @id"
                ,parms
                );
        }
        public void Update(PositionType pType)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@id", SqlDbType.TinyInt) {Value=pType.Id }
                ,new SqlParameter("@name",SqlDbType.NVarChar,50) {Value=pType.Name }
            };
            SqlHelper.ExecuteNonQuery(
                SqlHelper.ConnString
                , CommandType.Text
                , "UPDATE positionType SET name = @name WHERE id = @id"
                , parms
                );
        }
        public void Update(int id, string name)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@id", SqlDbType.TinyInt) {Value=id }
                ,new SqlParameter("@name",SqlDbType.NVarChar,50) {Value=name }
            };
            SqlHelper.ExecuteNonQuery(
                SqlHelper.ConnString
                , CommandType.Text
                , "UPDATE positionType SET name = @name WHERE id = @id"
                , parms
                );
        }
        public List<PositionType> Search(string unclearName)
        {
            List<PositionType> ptypes = new List<PositionType>();
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@name", SqlDbType.NVarChar,50) {Value=unclearName }
            };
            SqlDataReader reader = SqlHelper.ExecuteReader(
                SqlHelper.ConnString
                ,CommandType.Text 
                ,"SELECT * FROM positionType WHERE name LIKE N'%@name'"
                ,parms
                );
            while (reader.Read())
            {
                ptypes.Add(FromSqlDataReader(reader));
            }
            return ptypes;
        }
    }
}
