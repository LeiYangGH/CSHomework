using DAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class ScheduleBLL
    {
        public List<ScheduleDAL> GetAllSchedule()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 查看某天属于哪些档期
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<ScheduleDAL> Search(DateTime date)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获取某个档期的详细信息
        /// </summary>
        /// <param name="scheduleId"></param>
        /// <returns></returns>
        public ScheduleDAL Search(int scheduleId)
        {
            throw new NotImplementedException();
        }
        public int AddSchedule(ScheduleDAL schedule)
        {
            throw new NotImplementedException();
        }
        public void ResetSchedule(ScheduleDAL schedule)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 重置档期名称
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public void ChangeScheduleName(int id, string name)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 重置档期开始日期
        /// </summary>
        /// <param name="id"></param>
        /// <param name="beginDate"></param>
        public void ChangeScheduleBeginDate(int id, DateTime beginDate)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 重置档期时限
        /// </summary>
        /// <param name="id"></param>
        /// <param name="duration"></param>
        public void ChangeScheduleDuration(int id, short duration)
        {
            throw new NotImplementedException();
        }
        public void DropSchedule(int schedule)
        {
            throw new NotImplementedException();
        }
    }
}
