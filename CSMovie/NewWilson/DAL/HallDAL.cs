﻿using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class HallDAL
    {
        public Hall FromSqlDataReader(SqlDataReader reader)
        {
            Hall obj = new Hall();
            if (reader["id"] is DBNull == false)
            {
                obj.Id = Convert.ToInt16(reader["id"]);
            }
            if (reader["layoutId"] is DBNull == false)
            {
                obj.LayoutId = Convert.ToInt32(reader["layoutId"]);
            }
            if (reader["name"] is DBNull == false)
            {
                obj.Name = Convert.ToString(reader["name"]);
            }
            if (reader["theme"] is DBNull == false)
            {
                obj.Theme = Convert.ToString(reader["theme"]);
            }
            if (reader["layoutStyle"] is DBNull == false)
            {
                obj.LayoutStyle = Convert.ToString(reader["layoutStyle"]);
            }
            return obj;
        }
        public List<Hall> GetAllFromSqlServer()
        {
            List<Hall> halls = new List<Hall>();
            SqlDataReader reader = SqlHelper.ExecuteReader(
                                        SqlHelper.ConnString
                                        , CommandType.Text
                                        , "SELECT * FROM vw_hall"
                                        );
            while (reader.Read())
            {
                halls.Add(FromSqlDataReader(reader));
            }
            return halls;
        }

        public Hall Get(short id)
        {
            Hall hall = null;
            SqlParameter sp = new SqlParameter("@id", SqlDbType.SmallInt) { Value = id };
            SqlDataReader reader = SqlHelper.ExecuteReader(
                                        SqlHelper.ConnString
                                        , CommandType.Text
                                        , "SELECT * FROM vw_hall WHERE id = @id"
                                        , sp
                                        );
            if (reader.Read())
            {
                hall = FromSqlDataReader(reader);
            }
            return hall;
        }

        public short Insert(Hall hall)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                 new SqlParameter("@layoutId", SqlDbType.Int) {Value=hall.LayoutId }
                ,new SqlParameter("@name",SqlDbType.NVarChar,50) {Value=hall.Name }
                ,new SqlParameter("@theme",SqlDbType.NVarChar,50) {Value=hall.Theme }
            };
            object id = SqlHelper.ExecuteScalar(
                SqlHelper.ConnString
                , CommandType.Text
                , "INSERT INTO hall VALUES (@layoutId,@name,@theme); SELECT SCOPE_IDENTITY()"
                , parms
                );
            return Convert.ToInt16(id);
        }
        public void Delete(short id)
        {
            SqlParameter sp = new SqlParameter("@id", SqlDbType.SmallInt) { Value = id };
            SqlHelper.ExecuteNonQuery(
                SqlHelper.ConnString
                ,CommandType.Text
                ,"DELETE FROM hall WHERE id = @id"
                ,sp
                );
        }
        public void Update(Hall hall)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@id", SqlDbType.SmallInt) {Value=hall.Id }
                ,new SqlParameter("@layoutId", SqlDbType.Int) {Value=hall.LayoutId }
                ,new SqlParameter("@name",SqlDbType.NVarChar,50) {Value=hall.Name }
                ,new SqlParameter("@theme",SqlDbType.NVarChar,50) {Value=hall.Theme }
            };
            SqlHelper.ExecuteNonQuery(
                    SqlHelper.ConnString
                    , CommandType.Text
                    , "UPDATE hall SET layoutId = @layoutId, name = @name, theme = @theme WHERE id = @id"
                    , parms
                );
        }
        public void Update(short id, string theme)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@id", SqlDbType.SmallInt) {Value=id }
                ,new SqlParameter("@theme",SqlDbType.NVarChar,50) {Value=theme }
            };
            SqlHelper.ExecuteNonQuery(
                    SqlHelper.ConnString
                    , CommandType.Text
                    , "UPDATE hall SET theme = @theme WHERE id = @id"
                    , parms
                );
        }
        public void Update(short id, int layoutId)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@id", SqlDbType.SmallInt) {Value=id }
                ,new SqlParameter("@layoutId", SqlDbType.Int) {Value=layoutId }
            };
            SqlHelper.ExecuteNonQuery(
                    SqlHelper.ConnString
                    , CommandType.Text
                    , "UPDATE hall SET layoutId = @id WHERE id = @id"
                    , parms
                );
        }
        public List<Hall> Search(string unclearThemeName)
        {
            List<Hall> halls = new List<Hall>();
            string name = string.Format("%{0}%", unclearThemeName);
            SqlParameter sp = new SqlParameter("@theme", SqlDbType.NVarChar, 50) { Value = name };
            SqlDataReader reader = SqlHelper.ExecuteReader(
                                        SqlHelper.ConnString
                                        , CommandType.Text
                                        , "SELECT * FROM vw_hall WHERE theme LIKE @theme"
                                        ,sp
                                        );
            while (reader.Read())
            {
                halls.Add(FromSqlDataReader(reader));
            }
            return halls;
        }
        public List<Hall> Search(int layoutId)
        {
            List<Hall> halls = new List<Hall>();
            SqlParameter sp = new SqlParameter("@layoutId", SqlDbType.Int) { Value = layoutId };
            SqlDataReader reader = SqlHelper.ExecuteReader(
                                        SqlHelper.ConnString
                                        , CommandType.Text
                                        , "SELECT * FROM vw_hall WHERE layoutId = @layoutId"
                                        ,sp
                                        );
            while (reader.Read())
            {
                halls.Add(FromSqlDataReader(reader));
            }
            return halls;
        }
        public List<Hall> Search(int layoutId, string theme)
        {
            List<Hall> halls = new List<Hall>();
            SqlParameter[] parms = new SqlParameter[]
            {
                 new SqlParameter("@theme", SqlDbType.NVarChar, 50) { Value = string.Format("%{0}%",theme) }
                ,new SqlParameter("@layoutId", SqlDbType.Int) { Value = layoutId }

            };
            SqlDataReader reader = SqlHelper.ExecuteReader(
                        SqlHelper.ConnString
                        , CommandType.Text
                        , "SELECT * FROM vw_hall WHERE theme layoutId = @layoutId AND theme LIKE @theme"
                        ,parms
                        );
            while (reader.Read())
            {
                halls.Add(FromSqlDataReader(reader));
            }
            return halls;
        }
    }
}
