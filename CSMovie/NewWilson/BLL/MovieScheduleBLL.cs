using DAL;
using Model;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class MovieScheduleBLL
    {
        MovieScheduleDAL dal = new MovieScheduleDAL();
        /// <summary>
        /// 获取所有电影档期
        /// </summary>
        /// <returns></returns>
        public List<MovieSchedule> GetAllMovieSchedule()
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
        public string AddMovieSchedule(MovieSchedule movieSchedule)
        {
            throw new NotImplementedException();
        }
        public void DropMovieSchedule(string movieScheduleId)
        {
            dal.Delete(movieScheduleId);
        }
        public void ResetMovieSchedule(MovieSchedule movieSchedule)
        {
            throw new NotImplementedException();
        }
    }
}
