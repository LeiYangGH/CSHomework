using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class ScheduleDAL
    {
        public Schedule FromSqlDataReader(SqlDataReader reader)
        {
            Schedule obj = new Schedule();
            if (reader["id"] is DBNull == false)
            {
                obj.Id = Convert.ToInt32(reader["id"]);
            }
            if (reader["name"] is DBNull == false)
            {
                obj.Name = Convert.ToString(reader["name"]);
            }
            if (reader["beginDate"] is DBNull == false)
            {
                obj.BeginDate = Convert.ToDateTime(reader["beginDate"]);
            }
            if (reader["duration"] is DBNull == false)
            {
                obj.Duration = Convert.ToInt16(reader["duration"]);
            }
            return obj;
        }

        public List<Schedule> GetAllFromSqlServer()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 查看某天属于哪些档期
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<Schedule> Search(DateTime date)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获取某个档期的详细信息
        /// </summary>
        /// <param name="scheduleId"></param>
        /// <returns></returns>
        public Schedule Search(int scheduleId)
        {
            throw new NotImplementedException();
        }
        public int Insert(Schedule schedule)
        {
            throw new NotImplementedException();
        }
        public void Update(Schedule schedule)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 重置档期名称
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public void Update(int id, string name)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 重置档期开始日期
        /// </summary>
        /// <param name="id"></param>
        /// <param name="beginDate"></param>
        public void Update(int id, DateTime beginDate)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 重置档期时限
        /// </summary>
        /// <param name="id"></param>
        /// <param name="duration"></param>
        public void Update(int id, short duration)
        {
            throw new NotImplementedException();
        }
        public void Delete(int schedule)
        {
            throw new NotImplementedException();
        }
    }
}
