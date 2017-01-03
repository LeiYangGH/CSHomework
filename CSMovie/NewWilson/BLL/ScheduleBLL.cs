using DAL;
using System;
using Model;
using System.Collections.Generic;

namespace BLL
{
    public class ScheduleBLL
    {
        private ScheduleDAL sl = new ScheduleDAL();
        public List<Schedule> GetAllSchedule()
        {
            return sl.GetAllFromSqlServer();
        }

        /// <summary>
        /// 查看某天属于哪些档期
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<Schedule> Search(DateTime date)
        {
            return sl.Search(date);
        }
        /// <summary>
        /// 获取某个档期的详细信息
        /// </summary>
        /// <param name="scheduleId"></param>
        /// <returns></returns>
        public Schedule Search(int scheduleId)
        {
            return sl.Search(scheduleId);
        }
        public int AddSchedule(Schedule schedule)
        {
            return sl.Insert(schedule);
        }
        public void ResetSchedule(Schedule schedule)
        {
            sl.Update(schedule);
        }
        /// <summary>
        /// 重置档期名称
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public void ChangeScheduleName(int id, string name)
        {
            sl.Update(id, name);
        }
        /// <summary>
        /// 重置档期开始日期
        /// </summary>
        /// <param name="id"></param>
        /// <param name="beginDate"></param>
        public void ChangeScheduleBeginDate(int id, DateTime beginDate)
        {
            sl.Update(id, beginDate);
        }
        /// <summary>
        /// 重置档期时限
        /// </summary>
        /// <param name="id"></param>
        /// <param name="duration"></param>
        public void ChangeScheduleDuration(int id, short duration)
        {
            sl.Update(id, duration);
        }
        public void DropSchedule(int schedule)
        {
            sl.Delete(schedule);
        }
    }
}
