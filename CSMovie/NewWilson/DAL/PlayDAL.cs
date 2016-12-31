using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class PlayDAL
    {
        public Play FromSqlDataReader(SqlDataReader reader)
        {
            Play obj = new Play();
            if (reader["id"] is DBNull == false)
            {
                obj.Id = Convert.ToString(reader["id"]);
            }
            if (reader["hallId"] is DBNull == false)
            {
                obj.HallId = Convert.ToInt16(reader["hallId"]);
            }
            if (reader["date"] is DBNull == false)
            {
                obj.Date = Convert.ToDateTime(reader["date"]);
            }
            if (reader["beginTime"] is DBNull == false)
            {
                obj.BeginTime = Convert.ToDateTime(reader["beginTime"]);
            }
            if (reader["movieScheduleId"] is DBNull == false)
            {
                obj.MovieScheduleId = Convert.ToString(reader["movieScheduleId"]);
            }
            if (reader["hallName"] is DBNull == false)
            {
                obj.HallName = Convert.ToString(reader["hallName"]);
            }
            if (reader["layoutId"] is DBNull == false)
            {
                obj.LayoutId = Convert.ToInt32(reader["layoutId"]);
            }
            if (reader["layoutStyle"] is DBNull == false)
            {
                obj.LayoutStyle = Convert.ToString(reader["layoutStyle"]);
            }
            if (reader["movieId"] is DBNull == false)
            {
                obj.MovieId = Convert.ToString(reader["movieId"]);
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
            if (reader["scheduleId"] is DBNull == false)
            {
                obj.ScheduleId = Convert.ToInt32(reader["scheduleId"]);
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
        /// 获取所有场次信息
        /// </summary>
        /// <returns></returns>
        public List<Play> GetAllFromSqlSever()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获取 某一天, 某一场电影的所有场次
        /// </summary>
        /// <param name="date">查询的日期</param>
        /// <param name="movieId">查询的电影标识</param>
        /// <returns></returns>
        public List<Play>Search(DateTime date, string movieId)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获取某一场次的详细信息
        /// </summary>
        /// <param name="playId"></param>
        /// <returns></returns>
        public Play Search(string playId)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 增加一个场次
        /// </summary>
        /// <param name="play"></param>
        /// <returns></returns>
        public string Insert(Play play)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 删除一个场次
        /// </summary>
        /// <param name="playId"></param>
        public void Delete(string playId)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 更新一个场次
        /// </summary>
        /// <param name="play"></param>
        public void Update(Play play)
        {
            throw new NotImplementedException();
        }
    }
}
