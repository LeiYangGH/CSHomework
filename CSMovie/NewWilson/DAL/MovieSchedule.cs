using Model;
using System;
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
            throw new NotImplementedException();
        }
        /// <summary>
        /// 按电影查询所有电影档期
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        public List<MovieSchedule> SearchByMovieId(string movieId)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        ///  按档期查询所有电影档期
        /// </summary>
        /// <param name="scheduleId"></param>
        /// <returns></returns>
        public List<MovieSchedule> SearchByScheduleId(string scheduleId)
        {
            throw new NotImplementedException();
        }
        public string Insert(MovieSchedule movieSchedule)
        {
            throw new NotImplementedException();
        }
        public void Delete(string movieScheduleId)
        {
            throw new NotImplementedException();
        }
        public void Update(MovieSchedule movieSchedule)
        {
            throw new NotImplementedException();
        }
    }
}
