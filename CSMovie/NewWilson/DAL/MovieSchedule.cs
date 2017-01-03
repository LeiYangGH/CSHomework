using Model;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class MovieScheduleDAL
    {
        public MovieSchedule FromSqlDataReader(SqlDataReader reader)
        {
            MovieSchedule obj = new MovieSchedule();
            if (reader["id"] is DBNull == false)
            {
                obj.Id = Convert.ToString(reader["id"]);
            }
            if (reader["movieId"] is DBNull == false)
            {
                obj.MovieId = Convert.ToString(reader["movieId"]);
            }
            if (reader["scheduleId"] is DBNull == false)
            {
                obj.ScheduleId = Convert.ToInt32(reader["scheduleId"]);
            }
            if (reader["movieName"] is DBNull == false)
            {
                obj.MovieName = Convert.ToString(reader["movieName"]);
            }
            if (reader["movieDuration"] is DBNull == false)
            {
                obj.MovieDuration = Convert.ToByte(reader["movieDuration"]);
            }
            if (reader["movieTypeId"] is DBNull == false)
            {
                obj.MovieTypeId = Convert.ToByte(reader["movieTypeId"]);
            }
            if (reader["movieTypeName"] is DBNull == false)
            {
                obj.MovieTypeName = Convert.ToString(reader["movieTypeName"]);
            }
            if (reader["scheduleName"] is DBNull == false)
            {
                obj.ScheduleName = Convert.ToString(reader["scheduleName"]);
            }
            if (reader["scheduleBeginDate"] is DBNull == false)
            {
                obj.ScheduleBeginDate = Convert.ToDateTime(reader["scheduleBeginDate"]);
            }
            if (reader["scheduleDuration"] is DBNull == false)
            {
                obj.ScheduleDuration = Convert.ToInt16(reader["scheduleDuration"]);
            }
            return obj;
        }
        /// <summary>
        /// 获取所有电影档期
        /// </summary>
        /// <returns></returns>
        public List<MovieSchedule> GetAllFromSqlSever()
        {
            List<MovieSchedule> MovieSchedules = new List<MovieSchedule>();
            SqlDataReader reader = SqlHelper.ExecuteReader(
                SqlHelper.ConnString
                , CommandType.Text
                , "SELECT * FROM vw_movieSchedule");
            while (reader.Read())
            {
                MovieSchedules.Add(FromSqlDataReader(reader));
            }
            return MovieSchedules;
        }
        /// <summary>
        /// 按电影查询所有电影档期
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        public List<MovieSchedule> SearchByMovieId(string movieId)
        {
            List<MovieSchedule> ms = new List<MovieSchedule>();
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@id",SqlDbType.NVarChar,50)
            };
            SqlDataReader reader = SqlHelper.ExecuteReader(
                SqlHelper.ConnString
                , CommandType.Text
                , "SELECT * FROM movieSchedule WHERE id LIKE I'@id@'"
                , parms);
            while (reader.Read())
            {
                ms.Add(FromSqlDataReader(reader));
            }
            return ms;
        }
        /// <summary>
        ///  按档期查询所有电影档期
        /// </summary>
        /// <param name="scheduleId"></param>
        /// <returns></returns>
        public List<MovieSchedule> SearchByScheduleId(string scheduleId)
        {
            List<MovieSchedule> mse = new List<MovieSchedule>();
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@id",SqlDbType.NVarChar,50)
            };
            SqlDataReader reader = SqlHelper.ExecuteReader(
                SqlHelper.ConnString
                , CommandType.Text
                , "SELECT * FROM movieSchedule WHERE id LIKE I'@id@'"
                , parms);
            while (reader.Read())
            {
                mse.Add(FromSqlDataReader(reader));
            }
            return mse;
        }
        public string Insert(MovieSchedule movieSchedule)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@id",SqlDbType.NVarChar,36) { Value=movieSchedule.Id}
                ,new SqlParameter("@movieId",SqlDbType.NVarChar,36) {Value=movieSchedule.MovieId }
                ,new SqlParameter("@scheduleId",SqlDbType.Int) { Value=movieSchedule.MovieTypeId}
            };
            object id = SqlHelper.ExecuteScalar(
                SqlHelper.ConnString
                , CommandType.Text
                , "INSERT INTO MovieSchedule VALUES(@id)"
                , parms);
            return Convert.ToString(id);
        }
        public void Delete(string movieScheduleId)
        {
            SqlParameter parms = new SqlParameter("@id", SqlDbType.Int) { Value = movieScheduleId };
            SqlHelper.ExecuteNonQuery(
                SqlHelper.ConnString
                , CommandType.Text
                , "DELECT FROM movieSchedule WHERE id=@id"
                , parms);
        }
        public void Update(MovieSchedule movieSchedule)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@id",SqlDbType.NVarChar,36) { Value=movieSchedule.Id}
                ,new SqlParameter("@movieId",SqlDbType.NVarChar,36) { Value=movieSchedule.MovieId}
                ,new SqlParameter("@scheduleId",SqlDbType.Int) { Value=movieSchedule.ScheduleId}
            };
            SqlHelper.ExecuteNonQuery(
                SqlHelper.ConnString
                , CommandType.Text
                , "UPDATE movieSchedule SET id=@id WHERE movieId=@movieId WHERE scheduleId=@scheduleId"
                , parms);
        }
    }
}
