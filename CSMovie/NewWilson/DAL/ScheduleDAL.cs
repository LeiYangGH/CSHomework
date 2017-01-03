using Model;
using System;
using System.Collections.Generic;
using System.Data;
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
            List<Schedule> sh = new List<Schedule>();
            SqlDataReader reader = SqlHelper.ExecuteReader(
                SqlHelper.ConnString
                , CommandType.Text
                , "select * from Schedule");
                while (reader.Read())
            {
                Schedule s = FromSqlDataReader(reader);
                sh.Add(s);
            }
            return sh;
        }

        /// <summary>
        /// 查看某天属于哪些档期
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<Schedule> Search(DateTime date)
        {
            List<Schedule> schedules = new List<Schedule>();
            SqlParameter sp = new SqlParameter("@date", SqlDbType.DateTime) { Value = date };
            SqlDataReader reader = SqlHelper.ExecuteReader(
                SqlHelper.ConnString
                , CommandType.Text
                , "select * from schedule where theme date=@date"
                , sp);
            while (reader.Read())
            {
                schedules.Add(FromSqlDataReader(reader));
            }
            return schedules;
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
            SqlParameter spName = new SqlParameter("@name", SqlDbType.Int) { Value = schedule };
            object id = SqlHelper.ExecuteScalar(
                SqlHelper.ConnString
                , CommandType.Text
                , "INSERT layout VALUES (@name)"
                , spName);
            return Convert.ToInt32(id);
        }
        public void Update(Schedule schedule)
        {
            SqlParameter[] parms = new SqlParameter[]
                {
                    new SqlParameter("@id",SqlDbType.Int) { Value=schedule.Id}
                    ,new SqlParameter("@name",SqlDbType.NVarChar,50) {Value=schedule}
                };
            SqlHelper.ExecuteNonQuery(
                SqlHelper.ConnString
                , CommandType.Text
                , "UPDATE schedule SET name=@name WHERE id=@id"
                , parms);
        }
        /// <summary>
        /// 重置档期名称
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public void Update(int id, string name)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@id",SqlDbType.Int) { Value = id }
                ,new SqlParameter("@name",SqlDbType.NVarChar,50) { Value=name}
            };
            SqlHelper.ExecuteNonQuery(
                SqlHelper.ConnString
                , CommandType.Text
                , "UPDATE schedule SET name=@name WHERE id=@id"
                , parms
                );
        }
        /// <summary>
        /// 重置档期开始日期
        /// </summary>
        /// <param name="id"></param>
        /// <param name="beginDate"></param>
        public void Update(int id, DateTime beginDate)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@id",SqlDbType.Int) { Value=id}
                ,new SqlParameter("@Date",SqlDbType.DateTime) { Value=beginDate}
            };
            SqlHelper.ExecuteNonQuery(
                SqlHelper.ConnString
                , CommandType.Text
                , "UPDATE schedule SET date=@date WHERE id=@id"
                , parms);        
        }
        /// <summary>
        /// 重置档期时限
        /// </summary>
        /// <param name="id"></param>
        /// <param name="duration"></param>
        public void Update(int id, short duration)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@id",SqlDbType.Int) { Value=id}
                ,new SqlParameter("@duration",SqlDbType.NVarChar,50) { Value=duration}
            };
            SqlHelper.ExecuteNonQuery(
                SqlHelper.ConnString
                , CommandType.Text
                , "UPDATE schedule SET duration=@duration WHERE id=@id"
                , parms);
        }
        public void Delete(int schedule)
        {
            SqlParameter sp = new SqlParameter("@id", SqlDbType.Int) { Value = schedule };
            SqlHelper.ExecuteNonQuery(
                SqlHelper.ConnString
                , CommandType.Text
                , "DELETE FROM schedule WHERE id=@id");
        }
    }
}
