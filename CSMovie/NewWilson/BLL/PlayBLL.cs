using DAL;
using Model;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class PlayBLL
    {
        private PlayDAL dal = new PlayDAL();
        public List<Play> GetAllPlay()
        {
            return dal.GetAllFromSqlSever();
        }
        /// <summary>
        /// 获取 某一天, 某一场电影的所有场次
        /// </summary>
        /// <param name="date">查询的日期</param>
        /// <param name="movieId">查询的电影标识</param>
        /// <returns></returns>
        public List<Play> Search(DateTime date, string movieId)
        {
            return dal.Search(date, movieId);
        }
        public List<Play> Search(DateTime date)
        {
            return dal.Search(date);
        }
        /// <summary>
        /// 获取某一场次的详细信息
        /// </summary>
        /// <param name="playId"></param>
        /// <returns></returns>
        public Play Search(string playId)
        {
            return dal.Search(playId);
        }
        /// <summary>
        /// 增加一个场次
        /// </summary>
        /// <param name="play"></param>
        /// <returns></returns>
        public string AddPlay(Play play)
        {
            return dal.Insert(play);
        }
        /// <summary>
        /// 删除一个场次
        /// </summary>
        /// <param name="playId"></param>
        public void CancelPlay(string playId)
        {
            dal.Delete(playId);
        }
        /// <summary>
        /// 更新一个场次
        /// </summary>
        /// <param name="play"></param>
        public void ResetPlay(Play play)
        {
            dal.Update(play);
        }
    }
}
